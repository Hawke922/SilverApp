import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Dungeon } from '../_models/dungeon';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DungeonService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getDungeon(id): Observable<Dungeon> {
  return this.http.get<Dungeon>(this.baseUrl + 'dungeon/' + id);
  }
}
