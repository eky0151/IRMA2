import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Album } from "./models/album";
import 'rxjs/add/operator/map';

@Injectable()
export class DataService {

    constructor(private http: HttpClient) {

    }

    public albums: Album[] = [];

    loadAlbums(): Observable<boolean> {
        return this.http.get("/api/album/get")
            .map((data: any[]) => {
                this.albums = data;
                return true;
            })
    }

    createAlbum(albumName: string) {
        let params = new URLSearchParams();
        params.append("albumName", albumName);
        this.http.post("/api/album/create", params)
            .subscribe(data => {
                alert("Album created!")
                return true;
            }, error => {
                console.log("error");
            }
            );
        }
}