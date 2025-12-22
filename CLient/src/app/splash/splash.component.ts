import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-splash',
  templateUrl: './splash.component.html',
  styleUrl: './splash.component.css',
})
export class SplashComponent implements OnInit {
  splashDuration = 2000;

  constructor(private router: Router) {}

  ngOnInit(): void {
    const hasSeenSplash = sessionStorage.getItem('hasSeenSplash');

    if (hasSeenSplash) {
      this.navigateNext();
    } else {
      sessionStorage.setItem('hasSeenSplash', 'true');

      setTimeout(() => this.navigateNext(), this.splashDuration);
    }
  }

  private navigateNext() {
    const isLoggedIn = !!localStorage.getItem('authToken');
    if (isLoggedIn) {
      this.router.navigate(['/home']);
    } else {
      this.router.navigate(['/login']);
    }
  }
}
