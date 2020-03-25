import { Injectable } from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { UserService } from '../_services/user.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Character } from '../_models/character';

@Injectable()
export class CharacterDetailResolver implements Resolve<Character> {
    constructor(private userService: UserService, private router: Router) {}

    resolve(route: ActivatedRouteSnapshot): Observable<Character> {
        return this.userService.getCharacter(route.params['id']).pipe(catchError( error => {
            console.log('Problem retrieving character data')
            this.router.navigate(['/charselect']);
            return of(null);
        }));
    }
}
