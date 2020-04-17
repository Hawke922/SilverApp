import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Dungeon } from '../_models/dungeon';
import { Observable, BehaviorSubject } from 'rxjs';
import { Enemy } from '../_models/enemy';

@Injectable({
  providedIn: 'root'
})
export class DungeonService {
  baseUrl = environment.apiUrl;

  private selectedAreaSource = new BehaviorSubject<any>(null);
  selectedArea = this.selectedAreaSource.asObservable();

  private modeSource = new BehaviorSubject<any>({});
  currentMode = this.modeSource.asObservable();

  constructor(private http: HttpClient) { }

  getDungeon(id): Observable<Dungeon> {
  return this.http.get<Dungeon>(this.baseUrl + 'dungeon/' + id);
  }

  getEncounter(id): Observable<Enemy> {
    return this.http.get<Enemy>(this.baseUrl + 'dungeon/encounter/' + id);
  }

  loadSelectedArea(data: any) {
    this.selectedAreaSource.next(data);
  }

  loadMode(data: any) {
    this.modeSource.next(data);
  }
}
