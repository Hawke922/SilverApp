import { Injectable } from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { Observable, of, forkJoin } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { UserService } from '../_services/user.service';
import { Character } from '../_models/character';
import { DungeonService } from '../_services/dungeon.service';

@Injectable()
export class CombatResolver implements Resolve<Character> {
    constructor(private userService: UserService, private router: Router, private dungeonService: DungeonService) {}

    resolve(route: ActivatedRouteSnapshot): Observable<any> {
        const data = forkJoin({
            enemy: this.dungeonService.getEncounter(+route.queryParams['dung']),
            character: this.userService.getCharacter(+route.params['id']).pipe(catchError( error => {
                console.log('Problem retrieving character data');
                this.router.navigate(['/charselect']);
                return of(null);
            }))
        });
        return data;
        }

    // resolve(route: ActivatedRouteSnapshot): Observable<Character> {
    //     return this.userService.getCharacter(route.params['id']).pipe(catchError( error => {
    //         console.log('Problem retrieving character data');
    //         this.router.navigate(['/charselect']);
    //         return of(null);
    //     }));
    // }
}
