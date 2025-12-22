import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-hero',
  templateUrl: './hero.component.html',
  styleUrl: './hero.component.css',
})
export class HeroComponent implements OnInit {
  isMobile: boolean = false;
  user = {
    name: 'Omar',
  };

  ngOnInit(): void {
    this.isMobile = window.innerWidth <= 640;
  }
}
