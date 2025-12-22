import { Component, OnInit, HostListener } from '@angular/core';

@Component({
  selector: 'app-background-effect',
  templateUrl: './background-effect.component.html',
  styleUrl: './background-effect.component.css',
})
export class BackgroundEffectComponent implements OnInit {
  circles: any[] = [];
  screenWidth!: number;
  circlesNo: number = 3;
  isMobile: boolean = false

  ngOnInit(): void {
    this.updateCircles();
    this.isMobile = window.innerWidth <= 640;
  }

  @HostListener('window:resize', ['$event'])
  onResize(event: any) {
    this.updateCircles();
  }

  private updateCircles() {
    this.screenWidth = window.innerWidth;
    this.circlesNo = Math.max(Math.floor(this.screenWidth / 200), 5);

    const circlesColors = [
      'var(--primary)',
      'var(--accent)',
      'var(--violet)',
      'var(--violetb)',
    ];

    this.circles = [];

    for (let i = 0; i < this.circlesNo; i++) {
      const sizeVW = Math.random() * 10 + 15;
      this.circles.push({
        size: this.isMobile ? sizeVW + 30 : sizeVW + 'vw',
        top: Math.random() * 100 + 'vh',
        left: Math.random() * 100 + 'vw',
        color: circlesColors[Math.floor(Math.random() * circlesColors.length)],
        animation: `pulse ${
          Math.random() * 5 + 5
        }s ease-in-out infinite alternate`,
      });
    }
  }
}
