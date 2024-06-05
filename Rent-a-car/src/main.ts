import { bootstrapApplication } from '@angular/platform-browser';
import { AppComponent } from './app/app.component';
import { importProvidersFrom } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app/app.routes';

bootstrapApplication(AppComponent, {
  providers: [
    importProvidersFrom(BrowserModule), // Ensure BrowserModule is imported correctly
    importProvidersFrom(AppRoutingModule),
    importProvidersFrom(HttpClientModule),
    importProvidersFrom(ReactiveFormsModule)
  ]
}).catch(err => console.error(err));
