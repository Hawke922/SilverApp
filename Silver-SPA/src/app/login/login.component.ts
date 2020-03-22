import { Component, OnInit, OnDestroy } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit, OnDestroy {
  model: any = {};
  error;
  constructor(public authService: AuthService, private router: Router) { }

  ngOnInit() {
    document.body.classList.add('bg-skull');
  }

  ngOnDestroy() {
    document.body.classList.remove('bg-skull');
  }

  login() {
    this.authService.login(this.model).subscribe(next => {
      console.log('Logged in successfully');
    }, error => {
      this.error = error;
      console.log(error);
    }, () => {
      this.router.navigate(['/charselect']);
    });
  }

}
