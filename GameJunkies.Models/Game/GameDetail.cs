﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJunkies.Models.Game
{
    public class GameDetail
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ParentalRating { get; set; }
        public string Genre { get; set; }
        public string Developer { get; set; }
        public string Publisher { get; set; }
        public float? Rating { get; set; }
        [DisplayName("Release Date")]
        public DateTimeOffset ReleaseDate { get; set; }
        [DisplayName("Date added to database")]
        public DateTimeOffset CreatedUtc { get; set; }
        [ DisplayName("Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}