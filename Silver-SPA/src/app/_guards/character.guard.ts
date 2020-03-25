import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { UserService } from '../_services/user.service';
import { AuthService } from '../_services/auth.service';

@Injectable({
  providedIn: 'root'
})
export class CharacterGuard implements CanActivate {
  constructor(private userService: UserService, private authService: AuthService, private router: Router) { }

  // not even expect it to work, here is just an idea how to do it

  canActivate(): boolean {
    for (const char of this.userService.getUser(this.authService.decodedToken.nameid).characters) {
      const entries = Object.entries(char);
      const activeChar = this.userService.activeCharacter;
      if (entries[0].includes(activeChar)) {
        return true;
      }
      console.log('You can only play with your characters.');
      this.router.navigate(['/charselect']);
      return false;
    }
  }
}
