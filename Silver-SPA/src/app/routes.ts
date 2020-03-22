import { Routes } from '@angular/router';
import { LandingComponent } from './landing/landing.component';
import { CharacterSelectionComponent } from './character-selection/character-selection.component';
import { CharacterCreationComponent } from './character-creation/character-creation.component';
import { CharacterMenuComponent } from './character-menu/character-menu.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { AuthGuard } from './_guards/auth.guard';
import { CharacterSelectionResolver } from './_resolvers/character-selection.resolver';
import { CharacterFemaleGalleryComponent } from './character-creation/character-female-gallery/character-female-gallery.component';
import { CharacterMaleGalleryComponent } from './character-creation/character-male-gallery/character-male-gallery.component';
import { MainComponent } from './main/main.component';

export const appRoutes: Routes = [
    { path: 'landing', component: LandingComponent, data: { animation: 'isLeft'}},
    { path: 'main', component: MainComponent},
    { path: 'login', component: LoginComponent, data: { animation: 'isRight'}},
    { path: 'register', component: RegisterComponent, data: { animation: 'isRight'}},
    { path: 'charmalegallery', component: CharacterMaleGalleryComponent, canActivate: [AuthGuard]},
    { path: 'charselect', component: CharacterSelectionComponent, canActivate: [AuthGuard], resolve: {user: CharacterSelectionResolver}},
    { path: 'charmenu', component: CharacterMenuComponent, canActivate: [AuthGuard], resolve: {user: CharacterSelectionResolver}},
    { path: 'charcreate', component: CharacterCreationComponent, canActivate: [AuthGuard], children: [
        { path: 'charfemalegallery', component: CharacterFemaleGalleryComponent, canActivate: [AuthGuard]}]},
    { path: '**', redirectTo: 'login', pathMatch: 'full'}
];
