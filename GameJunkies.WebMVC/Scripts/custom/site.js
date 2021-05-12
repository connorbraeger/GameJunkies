const search = function () {
    let model = {
        type: document.getElementById("inlineFormCustomSelectPref").options[document.getElementById("inlineFormCustomSelectPref").selectedIndex].value,
        searchText: document.getElementById("searchText").value
    };
    if (!model.searchText == "") {
        let searchString = 'Type=' + model.type + '&SearchText=' + model.searchText;
        //self.location = "https://localhost:44316/search/?" + searchString;
        self.location = "https://" + window.location.hostname +":" + window.location.port +"/search/?" + searchString;
    };
}
let searchBtn = document.getElementById("universalSearch");
searchBtn.addEventListener("click", search);
$('.carousel').carousel({
    interval: false
})
    
