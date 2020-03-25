import { Routes } from '@angular/router';
import { LandingComponent } from './landing/landing.component';
import { CharacterSelectionComponent } from './character-selection/character-selection.component';
import { CharacterCreationComponent } from './character-creation/character-creation.component';
import { CharacterMenuComponent } from './character-menu/character-menu.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { AuthGuard } from './_guards/auth.guard';
import { CharacterSelectionResolver } from './_resolvers/character-selection.resolver';
import { CharacterDetailResolver } from './_resolvers/character-detail.resolver';
import { DungeonMenuComponent } from './dungeon-menu/dungeon-menu.component';
import { DungeonMenuResolver } from './_resolvers/dungeon-menu.resolver';

export const appRoutes: Routes = [
    { path: 'landing', component: LandingComponent, data: { animation: 'isLeft' }},
    { path: 'login', component: LoginComponent, data: { animation: 'isRight' }},
    { path: 'register', component: RegisterComponent, data: { animation: 'isRight' }},
    { path: 'charselect', component: CharacterSelectionComponent, canActivate: [AuthGuard], resolve: { user: CharacterSelectionResolver }},
    { path: 'charselect/:id', component: CharacterMenuComponent, canActivate: [AuthGuard], resolve: { character: CharacterDetailResolver }},
    { path: 'dungmenu/:id', component: DungeonMenuComponent, canActivate: [AuthGuard], resolve: { dungeon: DungeonMenuResolver }},
    { path: 'charcreate', component: CharacterCreationComponent, canActivate: [AuthGuard]},
    { path: '**', redirectTo: 'login', pathMatch: 'full'}
];
