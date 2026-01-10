import { Injectable } from '@angular/core';
import { genreService } from '../services/genre.service';
import { Genre } from '../models/genre.model';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class genreStateService {
  private genresubject = new BehaviorSubject<Genre[]>([]);
  genres$ = this.genresubject.asObservable();

  constructor(private genreService: genreService) {}

  loadGenres() {
    this.genreService.getGenres().subscribe({
      next: (data) => this.genresubject.next(data),
      error: (err) =>
        console.log('Error in state/ genre.state.service.ts', err),
    });
  }
}
