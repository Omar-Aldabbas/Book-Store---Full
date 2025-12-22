import { Component } from '@angular/core';
import { routes } from '../../app-routing.module';
import { Route } from '@angular/router';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css'],
})
export class NavbarComponent {
  navRoutes: Route[] = [];
  isOpen: boolean = false;

  constructor() {
    const mainLayoutRoute = routes[2];

    this.navRoutes =
      mainLayoutRoute.children?.filter(r => r.data?.['showInNav']) || [];

    console.log(this.navRoutes);
  }


  onClick() {
    this.isOpen = !this.isOpen;
  }
}
