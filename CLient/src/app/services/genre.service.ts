import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Genre } from "../models/genre.model";


@Injectable({
    providedIn: "root",

})
export class genreService {
    
    constructor(private http: HttpClient) {}

    getGenres(): Observable<Genre[]>{
        return this.http.get<Genre[]>("http://localhost:5082/api/Genres")
    }
}