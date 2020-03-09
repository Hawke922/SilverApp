import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { LandingComponent } from './landing/landing.component';
import { AuthService } from './_services/auth.service';
import { ErrorInterCeptorProvider } from './_services/error.interceptor';

@NgModule({
   declarations: [
      AppComponent,
      LandingComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      FormsModule
   ],
   providers: [
      AuthService,
      ErrorInterCeptorProvider
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
