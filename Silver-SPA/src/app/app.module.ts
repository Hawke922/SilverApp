import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { JwtModule } from '@auth0/angular-jwt';
import { RouterModule } from '@angular/router';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppComponent } from './app.component';
import { LandingComponent } from './landing/landing.component';
import { AuthService } from './_services/auth.service';
import { ErrorInterCeptorProvider } from './_services/error.interceptor';
import { CharacterSelectionComponent } from './character-selection/character-selection.component';
import { CharacterCreationComponent } from './character-creation/character-creation.component';
import { CharacterMenuComponent } from './character-menu/character-menu.component';
import { appRoutes } from './routes';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { CharacterSelectionResolver } from './_resolvers/character-selection.resolver';
import { ProfileComponent } from './profile/profile.component';
import { CharacterDetailResolver } from './_resolvers/character-detail.resolver';
import { DungeonMenuComponent } from './dungeon-menu/dungeon-menu.component';

export function tokenGetter() {
   return localStorage.getItem('token');
}

@NgModule({
   declarations: [
      AppComponent,
      LandingComponent,
      CharacterSelectionComponent,
      CharacterCreationComponent,
      CharacterMenuComponent,
      LoginComponent,
      RegisterComponent,
      ProfileComponent,
      DungeonMenuComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      FormsModule,
      RouterModule.forRoot(appRoutes),
      JwtModule.forRoot({
         config: {
            tokenGetter: tokenGetter,
            whitelistedDomains: ['localhost:5000'],
            blacklistedRoutes: ['localhost:5000/api/auth']
         }
}),
      NgbModule,
      BrowserAnimationsModule
   ],
   providers: [
      AuthService,
      ErrorInterCeptorProvider,
      CharacterSelectionResolver,
      CharacterDetailResolver
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
