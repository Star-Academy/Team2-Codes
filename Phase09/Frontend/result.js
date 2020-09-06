function loadFromSession() {
    let queryString = sessionStorage.getItem("query-string");
    if (queryString != null) {
        document.getElementById('query').value = queryString;
    }
    let docStorage = sessionStorage.getItem("docs");
    document.getElementById("result-box").innerHTML = " "
    if (docStorage != null && docStorage.length !== 0) {
        let docs = sessionStorage.getItem("docs").split(",");
        for (let doc of docs) {
            FindDocumentAndAdd(doc);
        }
    }
}


function FindDocumentAndAdd(id) {
    let resultBox = document.getElementById("result-box")
    let xhttp = new XMLHttpRequest()
    xhttp.onreadystatechange = function () {
        if (this.readyState === 4 && this.status === 200) {
            resultBox.innerHTML = resultBox.innerHTML + `<div class="result-card"> ${xhttp.response.content} </div>`;
        }
    };

    xhttp.open("GET", `http://localhost:13649/api/InvertedIndex/documents/get/${id}`)
    xhttp.responseType = 'json';
    xhttp.send();

}