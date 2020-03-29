import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable, BehaviorSubject } from 'rxjs';
import { User } from '../_models/user';
import { Character } from '../_models/character';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  baseUrl = environment.apiUrl;
  private characterSource = new BehaviorSubject<number>(999);
  activeCharacter = this.characterSource.asObservable();

  constructor(private http: HttpClient) {}

  getUser(id): Observable<User> {
    return this.http.get<User>(this.baseUrl + 'users/' + id);
  }

  getCharacter(id): Observable<Character> {
    return this.http.get<Character>(this.baseUrl + 'characters/' + id);
  }

  selectCharacter(model: any): Observable<Character> {
    return this.http.patch<Character>(this.baseUrl + 'characters/select', model);
  }

  createCharacter(model: any) {
    return this.http.post(this.baseUrl + 'characters/create', model);
  }

  setActiveCharacter(characterId: number) {
    this.characterSource.next(characterId);
  }
}
