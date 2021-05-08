const search = function () {
    let model = {
        type: document.getElementById("inlineFormCustomSelectPref").options[document.getElementById("inlineFormCustomSelectPref").selectedIndex].value,
        searchText: document.getElementById("searchText").value
    };
    if (!model.searchText == "") {
        let searchString = 'Type=' + model.type + '&SearchText=' + model.searchText;
        self.location = "https://localhost:44316/search/?" + searchString;
    };
}
let searchBtn = document.getElementById("universalSearch");
searchBtn.addEventListener("click", search);

    
