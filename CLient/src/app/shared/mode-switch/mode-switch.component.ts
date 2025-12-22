import { Component, ElementRef, OnInit, ViewChild, AfterViewInit } from '@angular/core';

@Component({
  selector: 'app-mode-switch',
  templateUrl: './mode-switch.component.html',
  styleUrls: ['./mode-switch.component.css'],
})
export class ModeSwitchComponent implements OnInit, AfterViewInit {
  @ViewChild('toggleCircle') toggleCircle!: ElementRef;

  isDarkMode: boolean = false;

  ngOnInit() {
    this.isDarkMode = localStorage.getItem('darkMode') === 'true';
  }

  ngAfterViewInit() {
    this.updateTheme(); // now toggleCircle exists
  }

  toggleDarkMode() {
    this.isDarkMode = !this.isDarkMode;
    localStorage.setItem('darkMode', this.isDarkMode.toString());
    this.updateTheme();
  }

  updateTheme() {
    if (this.isDarkMode) {
      document.documentElement.classList.add('dark');
    } else {
      document.documentElement.classList.remove('dark');
    }

    if (this.toggleCircle) {
      this.toggleCircle.nativeElement.style.transform = this.isDarkMode
        ? 'translateX(28px)'
        : 'translateX(0)';
    }
  }
}
