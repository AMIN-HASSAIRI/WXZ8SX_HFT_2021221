////fetch('http://localhost:49755/genre')
////    .then(x => x.json())
////    .then(y => console.log(y));

let genres = [];

getData();

async function getData() {
    await fetch('http://localhost:49755/genre')
        .then(x => x.json())
        .then(y => {
            genres = y;
            //console.log(albums);
            display();
        });
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    genres.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.genreId + "</td><td>" + t.genreName + "</td><td>"
            + `<button type="button" onclick="remove(${t.genreId})">Delete</button>` + "</td><td>"
            + `<button type="button" onclick="update(${t.genreId})">Update</button>`
            + "</td></tr>";
    });
}

function remove(id) {
    fetch('http://localhost:49755/genre/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getData();
        })
        .catch((error) => { console.error('Error:', error); });
}

function create() {
    let _genrename = document.getElementById('_genrename').value;

    fetch('http://localhost:49755/genre', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(
            {
                genreName: _genrename,
            }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getData();
        })
        .catch(error => { console.error('Error:', error); });
}

function update(id) {
    let _genrename = document.getElementById('_genrename').value;

    fetch('http://localhost:49755/genre', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(
            {
                genreId: id,
                genreName: _genrename,
            }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getData();
        })
        .catch(error => { console.error('Error:', error); });
}