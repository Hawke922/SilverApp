import { Component, OnInit, OnDestroy } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit, OnDestroy {
  model: any = {};
  error;

  constructor(public authService: AuthService, private router: Router) { }

  ngOnInit() {
    document.body.classList.add('bg-skull');
  }

  ngOnDestroy() {
    document.body.classList.remove('bg-skull');
  }

  register() {
    this.authService.register(this.model).subscribe(() => {
      console.log('registration successful');
    }, error => {
      console.log(error);
      this.error = error;
    }, () => {
      this.router.navigate(['/login']);
  });
  }
}

