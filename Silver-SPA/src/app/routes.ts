import { Routes } from '@angular/router';
import { LandingComponent } from './landing/landing.component';
import { CharacterSelectionComponent } from './character-selection/character-selection.component';
import { CharacterCreationComponent } from './character-creation/character-creation.component';
import { CharacterMenuComponent } from './character-menu/character-menu.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { AuthGuard } from './_guards/auth.guard';

export const appRoutes: Routes = [
    { path: 'landing', component: LandingComponent},
    { path: 'login', component: LoginComponent},
    { path: 'register', component: RegisterComponent},
    { path: 'charselect', component: CharacterSelectionComponent, canActivate: [AuthGuard]},
    { path: 'charmenu', component: CharacterMenuComponent, canActivate: [AuthGuard]},
    { path: 'charcreate', component: CharacterCreationComponent, canActivate: [AuthGuard]},
    { path: '**', redirectTo: 'landing', pathMatch: 'full'}
];
