using GameJunkies.Data;
using GameJunkies.Models;
using GameJunkies.Models.Game;
using IGDB;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.DirectoryServices.Protocols;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJunkies.Services
{
    public class GameService
    {
        public bool CreateGame(GameCreate model)
        {
            var entity = new Game()
            {
                Title = model.Title,
                Description = model.Description,
                ParentalRating = model.ParentalRating,
                GenreId = model.GenreId,
                DeveloperId = model.DeveloperId,
                PublisherId = model.PublisherId,
                ReleaseDate = model.ReleaseDate,
                CreatedUtc = DateTimeOffset.Now,
                Rating = -1
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Games.Add(entity);
                return ctx.SaveChanges() == 1;
            }

        }

        //public async Task<IEnumerable<GameCard>> RandomGames()
        //{
        //    var igdb = new IGDBClient("mfxz2v59vm1kedq1enbbl4hdkum42p", "vqrdpllaqq9ajd1uofn7gls11e5cig");
        //    List<GameCard> cards = new List<GameCard>();
        //    Random ranNum = new Random();
        //    for (int i = 0; i < 5; i++)
        //    {
        //        int random = ranNum.Next(1, 1000);
        //        string query = $"fields id,name,summary,rating,artworks.image_id; where id = {random};";
        //        var games =  await igdb.QueryAsync<IGDB.Models.Game>(IGDBClient.Endpoints.Games, query);
        //        var game = games.First();
        //        var artWorkId = game.Artworks.Values.First().ImageId;
        //        var url = IGDB.ImageHelper.GetImageUrl(imageId: artWorkId, size: ImageSize.CoverSmall, retina: false);
        //        var model = new GameCard()
        //        {
        //            Name = game.Name,
        //            Summary = game.Summary,
        //            Rating = game.Rating,
        //            CoverURL = url
        //        };
        //        cards.Add(model);

        //    }
        //    return cards;
        //}
        public async Task<IEnumerable<GameCard>> RandomGames(int numberOfGames = 5)
        {
            //Init list
            List<GameCard> cards = new List<GameCard>();
            //init random number
            Random ranNum = new Random();

            //set up token request
            string ClientId =
                "mfxz2v59vm1kedq1enbbl4hdkum42p";
            string clientSecret = "qz9o9vm9q8qa1vwhbp29ttp25tzp27";
            var client = new RestClient("https://id.twitch.tv/oauth2");
            client.UseNewtonsoftJson();
            
            var tokenRequest = new RestRequest("token?").AddParameter("client_id", ClientId).AddParameter("client_secret", clientSecret).AddParameter("grant_type","client_credentials");
            var response = client.Post<TwitchAuth>(tokenRequest);

            //set up game resquest
            client.AddDefaultHeader("Client-ID", "mfxz2v59vm1kedq1enbbl4hdkum42p");
            client.AddDefaultHeader("Authorization", "Bearer " + response.Data.AccessToken);
            client.BaseUrl = new UriBuilder("https://api.igdb.com/v4/games").Uri;

            for (int i = 0; i < numberOfGames; i++)
            {
                int random = ranNum.Next(1,2500);
                var gameRequest = new RestRequest().AddParameter("", $"fields id,name,summary,rating,cover.*; where id = {random};", ParameterType.RequestBody);

                var gameResponse = client.Post<IList<IGDBGame>>(gameRequest);
                var model = new GameCard()
                {
                    Name = gameResponse.Data[0].Name,
                    Summary = gameResponse.Data[0].Summary,
                    Rating = gameResponse.Data[0].Rating,
                    CoverURL = GameService.UrlManipulator(gameResponse.Data[0].Cover.Url, "t_cover_big")
                };
              
                cards.Add(model);
            }
            
            return cards;
        }


        public IEnumerable<GameListItem> GetGames()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Games.Select(e => new GameListItem { Id = e.Id, Title = e.Title, Created = e.CreatedUtc });

                return query.ToArray();
            }

        }
        public GameDetail GetGameById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {

                try
                {
                    var entity = ctx.Games.Single(e => e.Id == id);
                    return new GameDetail
                    {
                        Id = entity.Id,
                        Title = entity.Title,
                        Description = entity.Description,
                        ParentalRating = entity.ParentalRating,
                        Genre = entity.Genre.Name,
                        Developer = entity.Developer.Name,
                        Publisher = entity.Publisher.Name,
                        Rating = entity.Rating,
                        ReleaseDate = entity.ReleaseDate,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
                }
                catch (Exception e)
                {
                    Debug.Print("Exception thrown while looking for game");
                    Debug.Print(e.Message);
                    return null;
                }

            }
        }
        public GameEdit GetGameEditById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var edit = ctx.Games.Where(e => e.Id == id).Select(model => new GameEdit
                {
                    GameId = id,
                    Title = model.Title,
                    Description = model.Description,
                    ParentalRating = model.ParentalRating,
                    GenreId = model.GenreId,
                    DeveloperId = model.DeveloperId,
                    PublisherId = model.PublisherId,
                    Rating = model.Rating,
                    ReleaseDate = model.ReleaseDate
                }
                ).ToList();
                return edit[0];
            }
        }
        public bool UpdateGame(GameEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                try
                {
                    var entity = ctx.Games.Single(e => e.Id == model.GameId);
                    entity.Title = model.Title;
                    entity.Description = model.Description;
                    entity.ParentalRating = model.ParentalRating;
                    entity.GenreId = model.GenreId;
                    entity.DeveloperId = model.DeveloperId;
                    entity.PublisherId = model.PublisherId;
                    entity.Rating = model.Rating;
                    entity.ReleaseDate = model.ReleaseDate;
                    entity.ModifiedUtc = DateTimeOffset.Now;
                    return ctx.SaveChanges() >= 1;

                }
                catch (Exception e)
                {
                    Debug.Print("Exception thrown while looking for game");
                    Debug.Print(e.Message);
                    return false;
                }
            }
        }
        public bool DeleteGame(int gameId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Games.Single(e => e.Id == gameId);
                ctx.Games.Remove(entity);

                return ctx.SaveChanges() >= 1;
            }
        }
        static string UrlManipulator(string url, string size)
        {
            string[] words = url.Split('/');
            words[6] = size;
            return string.Join("/", words);
        }

    }
    class TwitchAuth
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }
    }
    class IGDBGame
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("cover")]
        public Cover Cover { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("rating")]
        public double Rating { get; set; }

        [JsonProperty("summary")]
        public string Summary { get; set; }
    }
    class Cover
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("alpha_channel")]
        public bool AlphaChannel { get; set; }

        [JsonProperty("animated")]
        public bool Animated { get; set; }

        [JsonProperty("game")]
        public int Game { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("image_id")]
        public string ImageId { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }

        [JsonProperty("checksum")]
        public string Checksum { get; set; }
    }
    

}
