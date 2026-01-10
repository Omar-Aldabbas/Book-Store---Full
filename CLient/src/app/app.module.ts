import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ModeSwitchComponent } from './shared/mode-switch/mode-switch.component';
import { SplashComponent } from './splash/splash.component';
import { BackgroundEffectComponent } from './shared/background-effect/background-effect.component';
import { AuthComponent } from './auth/auth.component';
import { LoginComponent } from './auth/login/login.component';
import { RegisterComponent } from './auth/register/register.component';
import { PasswordComponent } from './auth/password/password.component';
import { MainLayoutComponent } from './layout/main-layout/main-layout.component';
import { AuthLayoutComponent } from './layout/auth-layout/auth-layout.component';
import { ProfileComponent } from './user/profile/profile.component';
import { WishlistComponent } from './user/wishlist/wishlist.component';
import { LibraryComponent } from './user/library/library.component';
import { StoreComponent } from './store/store/store.component';
import { HomeComponent } from './home/home.component';
import { NavbarComponent } from './shared/navbar/navbar.component';
import { HeroComponent } from './home/hero/hero.component';
import { SearchBarComponent } from './shared/search-bar/search-bar.component';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { FaqComponent } from './home/faq/faq.component';
import { NewestComponent } from './home/newest/newest.component';
import { AddBookFormComponent } from './home/add-book-form/add-book-form.component';
import { genreStateService } from './state/genre.state.service';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
    ModeSwitchComponent,
    SplashComponent,
    BackgroundEffectComponent,
    NavbarComponent,
    AuthComponent,
    LoginComponent,
    RegisterComponent,
    PasswordComponent,
    MainLayoutComponent,
    AuthLayoutComponent,
    ProfileComponent,
    WishlistComponent,
    LibraryComponent,
    StoreComponent,
    HomeComponent,
    HeroComponent,
    SearchBarComponent,
    FaqComponent,
    NewestComponent,
    AddBookFormComponent,
  ],
  imports: [BrowserModule, AppRoutingModule, CommonModule, FormsModule, BrowserAnimationsModule, HttpClientModule],
  providers: [
    provideAnimationsAsync()
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
