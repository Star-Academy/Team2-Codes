function findPageNumber(doesSearchPage) {
    let pageNumber = 1;
    if (doesSearchPage) {
        let pageNumberElement = document.getElementById('page-number');
        if (!isNaN(pageNumberElement.value) && typeof pageNumberElement.value == "number") {
            pageNumber = pageNumberElement.value;
        }
    }
    return pageNumber;
}

function search(event, doesSearchPage = false) {
    if (event.key === 'Enter') {
        let query = document.getElementById("query").value;
        let xhttp = new XMLHttpRequest()
        xhttp.onreadystatechange = function () {
            if (this.readyState === 4 && this.status === 200) {
                sessionStorage.setItem("docs", xhttp.response.toString());
                sessionStorage.setItem('query-string', query);
                let base = changeLastPartOfUrl(window.location.href)

                window.location.href = base + "/result.html";
            }
        };
        let pageNumber = findPageNumber(doesSearchPage);

        xhttp.open("GET", `http://localhost:13649/api/InvertedIndex/documents/search?query=${query}&size=10&page=${pageNumber}`)
        xhttp.responseType = 'json';
        xhttp.send();
    }
}

function changeLastPartOfUrl(url) {
    var arr = url.split('/');
    arr.pop();
    return (arr.join('/'));
}