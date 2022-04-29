////fetch('http://localhost:49755/song')
////    .then(x => x.json())
////    .then(y => console.log(y));

let songs = [];

getData();

async function getData() {
    await fetch('http://localhost:49755/song')
        .then(x => x.json())
        .then(y => {
            songs = y;
            //console.log(albums);
            display();
        });
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    songs.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.songId + "</td><td>" + t.name + "</td><td>" + t.length
            + "</td><td>" + t.writer + "</td><td>" + t.singer + "</td><td>" + t.albumId
            + "</td><td>" + `<button type="button" onclick="remove(${t.songId})">Delete</button>`
            + "</td><td>" + `<button type="button" onclick="update(${t.songId})">Update</button>`
            + "</td></tr>";
    });
}

function remove(id) {
    fetch('http://localhost:49755/song/' + id, {
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
    let _songname = document.getElementById('_songname').value;
    let _songlength = document.getElementById('_songlength').value;
    let _songwriter = document.getElementById('_songwriter').value;
    let _songsinger = document.getElementById('_songsinger').value;
    let _albumid = document.getElementById('_albumid').value;

    fetch('http://localhost:49755/song', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(
            {
                name: _songname,
                length: _songlength,
                writer: _songwriter,
                singer: _songsinger,
                albumId: _albumid,
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
    let _songname = document.getElementById('_songname').value;
    let _songlength = document.getElementById('_songlength').value;
    let _songwriter = document.getElementById('_songwriter').value;
    let _songsinger = document.getElementById('_songsinger').value;
    let _albumid = document.getElementById('_albumid').value;

    fetch('http://localhost:49755/song', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(
            {
                songId: id,
                name: _songname,
                length: _songlength,
                writer: _songwriter,
                singer: _songsinger,
                albumId: _albumid,
            }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getData();
        })
        .catch(error => { console.error('Error:', error); });
}