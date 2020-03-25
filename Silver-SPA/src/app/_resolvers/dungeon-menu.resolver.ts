import { Injectable } from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Dungeon } from '../_models/dungeon';
import { DungeonService } from '../_services/dungeon.service';

@Injectable()
export class DungeonMenuResolver implements Resolve<Dungeon> {
    constructor(private dungeonService: DungeonService, private router: Router) {}

    resolve(route: ActivatedRouteSnapshot): Observable<Dungeon> {
        return this.dungeonService.getDungeon(+route.params['id']).pipe(catchError( error => {
            console.log('Problem retrieving dungeon data');
            console.log(route.params);
            this.router.navigate(['/charselect']);
            return of(null);
        }));
    }
}
