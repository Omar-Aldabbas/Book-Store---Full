import { Component, ViewChild } from '@angular/core';
import { Book } from '../../models/book.model';

@Component({
  selector: 'app-add-book-form',
  templateUrl: './add-book-form.component.html',
  styleUrl: './add-book-form.component.css'
})
export class AddBookFormComponent {

  Book : Book = {
    Id: 0,
    Title: '',
    Author: '',
    AddDate: new Date(),
    MainGenre: '',
    Language: '',
    ThumbnailUrl: '',
  }

}
