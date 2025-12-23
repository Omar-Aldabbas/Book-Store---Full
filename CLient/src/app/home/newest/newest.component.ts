import { Component, OnInit } from '@angular/core';
import { BooksService } from '../../services/books.service';
import { Book } from '../../models/book.model';

@Component({
  selector: 'app-newest',
  templateUrl: './newest.component.html',
  styleUrl: './newest.component.css'
})
export class NewestComponent implements OnInit{
  book!: Book;

  constructor(private books: BooksService) {}

  ngOnInit(): void {
    this.books.getNewest().subscribe({
      next:  (data: Book) => {
        this.book = data
      },
      error: (err) => {
        console.log(err)
      }
    })
  }
}
