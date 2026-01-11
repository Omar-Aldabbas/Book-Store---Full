import { Component, OnInit } from '@angular/core';

interface Author {
  id: number;
  name: string;
  imageUrl: string;
  bio: string;
  popularBook: {
    title: string;
  };
}

@Component({
  selector: 'app-author-section',
  templateUrl: './author-section.component.html',
  styleUrls: ['./author-section.component.css']
})
export class AuthorSectionComponent implements OnInit {

  authors: Author[] = [
    {
      id: 1,
      name: 'J.K. Rowling',
      imageUrl: '/assets/authors/jk_rowling.jpg',
      bio: 'British author best known for the Harry Potter series.',
      popularBook: { title: "Harry Potter and the Philosopher's Stone" }
    },
    {
      id: 2,
      name: 'George R.R. Martin',
      imageUrl: '/assets/authors/grrm.jpg',
      bio: 'American novelist famous for A Song of Ice and Fire series.',
      popularBook: { title: 'A Game of Thrones' }
    },
    {
      id: 3,
      name: 'Agatha Christie',
      imageUrl: '/assets/authors/agatha.jpg',
      bio: 'Prolific English writer known for detective novels.',
      popularBook: { title: 'Murder on the Orient Express' }
    }
  ];

  currentAuthorIndex = 0;
  author!: Author;

  ngOnInit(): void {
    this.author = this.authors[this.currentAuthorIndex];
    this.rotateAuthors();
  }

  rotateAuthors() {
    setInterval(() => {
      this.currentAuthorIndex = (this.currentAuthorIndex + 1) % this.authors.length;
      this.author = this.authors[this.currentAuthorIndex];
    }, 5000); 
  }
}
