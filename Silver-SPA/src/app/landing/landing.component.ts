import { Component, OnInit, OnDestroy } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-landing',
  templateUrl: './landing.component.html',
  styleUrls: ['./landing.component.css']
})
export class LandingComponent implements OnInit, OnDestroy {
  model: any = {};
  registerMode = false;
  loginMode = false;

  constructor(public authService: AuthService, private router: Router) { }

  ngOnInit() {
    document.body.classList.add('bg-skull');
  }

  ngOnDestroy() {
    document.body.classList.remove('bg-skull');
  }

  loggedIn() {
    return this.authService.loggedIn();
  }

  logout() {
    localStorage.removeItem('token');
    console.log('logged out');
  }

  cancel() {
    console.log('cancelled');
  }
}
