import { Component, OnInit, ViewChild } from '@angular/core';
import { Book } from '../../models/book.model';
import { genreStateService } from '../../state/genre.state.service';
import { Genre } from '../../models/genre.model';

@Component({
  selector: 'app-add-book-form',
  templateUrl: './add-book-form.component.html',
  styleUrl: './add-book-form.component.css',
})
export class AddBookFormComponent implements OnInit {
  book: Book = {
    Id: 0,
    Title: '',
    Author: '',
    AddDate: new Date(),
    MainGenre: '',
    Language: '',
    ThumbnailUrl: '',
    ISBN: '',
  };

  genres: Genre[] = [];

  constructor(private genreState: genreStateService) {}

  ngOnInit(): void {
    this.genreState.loadGenres();

    this.genreState.genres$.subscribe({
      next: (data) => (this.genres = data),
    });
  }
}
