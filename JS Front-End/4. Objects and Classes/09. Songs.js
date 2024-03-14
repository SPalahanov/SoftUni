function solve(input) {
    class Song {
        constructor( name, time) {
            this.name = name;
            this.time = time;
        }
    }
    
    const collection = {};
    const allSongs = [];

    const numberOfSong = input.shift();

    for (let i = 0; i < numberOfSong; i++) {
        const [typeList, name, time] = input.shift().split('_');

        if (!collection[typeList]) {
            collection[typeList] = [];
        }

        const song = new Song(name, time);
        collection[typeList].push(song)
        allSongs.push(song);
    }

    const typeList = input.shift();

    if (typeList === 'all') {
        allSongs.forEach(song => console.log(song.name));
    } else {
        collection[typeList].forEach(song => console.log(song.name));
    }
}

solve([3, 'favourite_DownTown_3:14', 'favourite_Kiss_4:16', 'favourite_Smooth Criminal_4:01', 'favourite']);