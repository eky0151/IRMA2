import { Component, OnInit } from "@angular/core";
import { DataService } from "../shared/dataService";
import { Album } from "../shared/models/album";

@Component({
    selector: "album-list",
    templateUrl: "albumlist.component.html",
    styleUrls:[]
})
export class AlbumList implements OnInit{
    public albums: Album[];

    constructor(private data: DataService) {
        this.albums = data.albums;
    }

    ngOnInit(): void {
        this.data.loadAlbums()
            .subscribe(success => {
                if (success) {
                    this.albums = this.data.albums;
                }
            });
    }
}