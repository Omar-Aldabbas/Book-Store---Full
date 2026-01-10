import { Component, OnInit, ViewChild } from '@angular/core';
import { Book } from '../../models/book.model';
import { genreStateService } from '../../state/genre.state.service';
import { Genre } from '../../models/genre.model';
import { Language } from '../../models/language.model';
import { LangguageStateService } from '../../state/language.state.service';
import { NgForm } from '@angular/forms';

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
  languages: Language[] = [];

  @ViewChild('bookForm') bookForm!: NgForm;

  constructor(
    private genreState: genreStateService,
    private languageState: LangguageStateService
  ) {}

  ngOnInit(): void {
    this.genreState.loadGenres();

    this.genreState.genres$.subscribe({
      next: (data) => (this.genres = data),
    });
    console.log(this.genres)
    this.languageState.loadLanguages();

    this.languageState.languages$.subscribe({
      next: (data) => (this.languages = data),
    });

    console.log(this.languages)

  }

  onSubmit(bookForm: NgForm) {
    if (bookForm.valid) {
      console.log(this.book);
      bookForm.reset();
    }
  }
}
