////fetch('http://localhost:49755/album')
////    .then(x => x.json())
////    .then(y => console.log(y));

let albums = [];

getData();

async function getData() {
    await fetch('http://localhost:49755/album')
        .then(x => x.json())
        .then(y => {
            albums = y;
            //console.log(albums);
            display();
        });
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    albums.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.albumId + "</td><td>" + t.albumName + "</td><td>"
            + t.releasedDate + "</td><td>" + t.numberOfSongs + "</td><td>"
            + t.rating + "</td><td>" + t.artistId + "</td><td>" + t.genreId
            + "</td><td>" + `<button type="button" onclick="remove(${t.albumId})">Delete</button>`
            + "</td><td>" + `<button type="button" onclick="update(${t.albumId})">Update</button>`
            + "</td></tr>";
    });
}

function remove(id) {
    fetch('http://localhost:49755/album/' + id, {
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
    let _albumname = document.getElementById('_albumname').value;
    let _datereleased = document.getElementById('_datereleased').value;
    let _numberOfsongs = document.getElementById('_numberofsongs').value;
    let _rating = document.getElementById('_rating').value;
    let _artistid = document.getElementById('_artistid').value;
    let _genreid = document.getElementById('_genreid').value;

    fetch('http://localhost:49755/album', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(
            {
                albumName: _albumname,
                releasedDate: _datereleased,
                numberOfSongs: _numberOfsongs,
                rating: _rating,
                artistId: _artistid,
                genreId: _genreid
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
    let _albumname = document.getElementById('_albumname').value;
    let _datereleased = document.getElementById('_datereleased').value;
    let _numberOfsongs = document.getElementById('_numberofsongs').value;
    let _rating = document.getElementById('_rating').value;
    let _artistid = document.getElementById('_artistid').value;
    let _genreid = document.getElementById('_genreid').value;

    fetch('http://localhost:49755/album', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(
            {
                albumId: id,
                albumName: _albumname,
                releasedDate: _datereleased,
                numberOfSongs: _numberOfsongs,
                rating: _rating,
                artistId: _artistid,
                genreId: _genreid
            }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getData();
        })
        .catch(error => { console.error('Error:', error); });
}