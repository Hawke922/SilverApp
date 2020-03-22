import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../_models/user';
import { Character } from '../_models/character';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getUser(id): Observable<User> {
    return this.http.get<User>(this.baseUrl + 'users/' + id);
  }

  getCharacter(id): Observable<Character> {
    return this.http.get<Character>(this.baseUrl + 'characters/' + id);
  }

  pickCharacter(id) {
    sessionStorage.setItem('Activechar', id);
  }

  getPickedCharacter() {
    return sessionStorage.getItem('Activechar');
  }

  deletePickedCharacter() {
    sessionStorage.removeItem('Activechar');
  }

  createCharacter(model: any) {
    return this.http.post(this.baseUrl + 'characters/create', model);
  }
}
