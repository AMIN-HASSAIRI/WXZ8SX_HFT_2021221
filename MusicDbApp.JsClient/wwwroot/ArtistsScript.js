////fetch('http://localhost:49755/artist')
////    .then(x => x.json())
////    .then(y => console.log(y));

let artists = [];

getData();

async function getData() {
    await fetch('http://localhost:49755/artist')
        .then(x => x.json())
        .then(y => {
            artists = y;
            //console.log(albums);
            display();
        });
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    artists.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.artistId + "</td><td>" + t.artistName
            + "</td><td>" + t.dateOfBirth + "</td><td>" + t.numberOfAlbums
            + "</td><td>" + `<button type="button" onclick="remove(${t.artistId})">Delete</button>`
            + "</td><td>" + `<button type="button" onclick="update(${t.artistId})">Update</button>`
            + "</td></tr>";
    });
}

function remove(id) {
    fetch('http://localhost:49755/artist/' + id, {
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
    let _artistname = document.getElementById('_artistname').value;
    let _dateofbirth = document.getElementById('_dateofbirth').value;
    let _numberofalbums = document.getElementById('_numberofalbums').value;

    fetch('http://localhost:49755/artist', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(
            {
                artistName: _artistname,
                dateOfBirth: _dateofbirth,
                numberOfAlbums: _numberofalbums,
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
    let _artistname = document.getElementById('_artistname').value;
    let _dateofbirth = document.getElementById('_dateofbirth').value;
    let _numberofalbums = document.getElementById('_numberofalbums').value;

    fetch('http://localhost:49755/artist', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(
            {
                artistId: id,
                artistName: _artistname,
                dateOfBirth: _dateofbirth,
                numberOfAlbums: _numberofalbums,
            }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getData();
        })
        .catch(error => { console.error('Error:', error); });
}