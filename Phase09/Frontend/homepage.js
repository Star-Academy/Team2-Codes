function search(event) {
    if (event.key === 'Enter') {
        let xhttp = new XMLHttpRequest()
        xhttp.onreadystatechange = function () {
            if (this.readyState === 4 && this.status === 200) {
                console.log(xhttp.response)
                sessionStorage.setItem("docs", xhttp.response.toString());
                let base = changeLastPartOfUrl( window.location.href)

                window.location.href = base+"/result.html";
            }
        };
        let query = document.getElementById("query").value;
        xhttp.open("GET", `http://localhost:13649/api/InvertedIndex/documents/search?query=${query}&size=10&page=1`)
        xhttp.responseType = 'json';
        xhttp.send();
    }
}

function changeLastPartOfUrl(url) {
    var arr = url.split('/');
    arr.pop();
    return (arr.join('/'));
}