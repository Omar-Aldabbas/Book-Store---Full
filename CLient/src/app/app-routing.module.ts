import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { SplashComponent } from './splash/splash.component';
import { HomeComponent } from './home/home.component';
import { PasswordComponent } from './auth/password/password.component';
import { RegisterComponent } from './auth/register/register.component';
import { WishlistComponent } from './user/wishlist/wishlist.component';
import { ProfileComponent } from './user/profile/profile.component';
import { LibraryComponent } from './user/library/library.component';
import { AuthLayoutComponent } from './layout/auth-layout/auth-layout.component';
import { LoginComponent } from './auth/login/login.component';
import { MainLayoutComponent } from './layout/main-layout/main-layout.component';
import { StoreComponent } from './store/store/store.component';

export const routes: Routes = [
  { path: '', component: SplashComponent },

  {
    path: '',
    component: AuthLayoutComponent,
    children: [
      { path: 'login', component: LoginComponent },
      { path: 'register', component: RegisterComponent },
      { path: 'password', component: PasswordComponent },
    ],
  },

  {
    path: '',
    component: MainLayoutComponent,
    // canActivate: [AuthGuard],
    children: [
      {
        path: 'home',
        component: HomeComponent,
        data: { label: 'Home', showInNav: true },
      },
      {
        path: 'store',
        component: StoreComponent,
        data: { label: 'Store', showInNav: true },
      },
      {
        path: 'wishlist',
        component: WishlistComponent,
        data: { label: 'Wishlist', showInNav: true },
      },
      {
        path: 'profile',
        component: ProfileComponent,
        data: { label: 'Profile', showInNav: true },
      },
      {
        path: 'library',
        component: LibraryComponent,
        data: { label: 'Library', showInNav: true },
      },
    ],
  },

  { path: '**', redirectTo: '' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {

  
}
