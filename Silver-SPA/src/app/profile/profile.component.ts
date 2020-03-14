import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  constructor(private router: Router, public authService: AuthService) { }
  profToggle = false;

  ngOnInit() {
  }

  logout() {
    localStorage.removeItem('token');
    this.router.navigate(['/login']);
    this.profileToggle();
  }

  loggedIn() {
    return this.authService.loggedIn();
  }

  profileToggle() {
    this.profToggle = !this.profToggle;
  }
}
