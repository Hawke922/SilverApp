import { Injectable } from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { Observable, of, forkJoin } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Dungeon } from '../_models/dungeon';
import { DungeonService } from '../_services/dungeon.service';
import { UserService } from '../_services/user.service';
import { AuthService } from '../_services/auth.service';

@Injectable()
export class DungeonMenuResolver implements Resolve<Dungeon> {
    constructor(private dungeonService: DungeonService, private userService: UserService, private authService: AuthService, private router: Router) {}

    resolve(route: ActivatedRouteSnapshot): Observable<any> {
        const data = forkJoin({
            user: this.userService.getUser(this.authService.decodedToken.nameid),
            dungeon: this.dungeonService.getDungeon(+route.params['id']).pipe(catchError( error => {
                console.log('Problem retrieving dungeon data');
                console.log(error);
                this.router.navigate(['/charselect']);
                return of(null);
            }))});
        return data;
        }

    // resolve(route: ActivatedRouteSnapshot): Observable<Dungeon> {
    //     return this.dungeonService.getDungeon(+route.params['id']).pipe(catchError( error => {
    //         console.log('Problem retrieving dungeon data');
    //         console.log(route.params);
    //         this.router.navigate(['/charselect']);
    //         return of(null);
    //     }));
    // }
}
