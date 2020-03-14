import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { User } from '../_models/user';
import { UserService } from '../_services/user.service';

@Component({
  selector: 'app-character-selection',
  templateUrl: './character-selection.component.html',
  styleUrls: ['./character-selection.component.css']
})
export class CharacterSelectionComponent implements OnInit {
  user: User;

  constructor(private router: Router, private route: ActivatedRoute, public userService: UserService) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.user = data['user'];
    });
  }

  logout() {
    localStorage.removeItem('token');
    console.log('Logged out');
    this.router.navigate(['/landing']);
  }

  getChar() {
    console.log(this.userService.getPickedCharacter());
  }
}
