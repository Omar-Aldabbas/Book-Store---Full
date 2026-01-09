import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Language } from '../models/language.model';

Injectable({
  providedIn: 'root',
});
export class LanguageService {
  constructor(private http: HttpClient) {}

  getLanguages(): Observable<Language[]> {
    return this.http.get<Language[]>('http://localhost:5082/api/Languages');
  }
}
