import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Book } from '../models/book.model';

export const baseUrl = "http://localhost:5082"
@Injectable({
  providedIn: 'root'
})
export class BooksService {


  constructor(private http: HttpClient) { }

  getNewest(): Observable<Book>{
    return this.http.get<Book>(`${baseUrl}/api/books/newest`)
  }


}
