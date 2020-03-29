import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { User } from '../_models/user';
import { UserService } from '../_services/user.service';

@Component({
  selector: 'app-character-selection',
  templateUrl: './character-selection.component.html',
  styleUrls: ['./character-selection.component.css']
})
export class CharacterSelectionComponent implements OnInit, OnDestroy {
  user: User;
  model: any = {};
  error;

  constructor(private router: Router, private route: ActivatedRoute, public userService: UserService) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.user = data['user'];
    });
    document.body.classList.add('bg-gradient');
  }

  ngOnDestroy() {
    document.body.classList.remove('bg-gradient');
  }

  activateCharacter(characterId) {
    this.model.CharacterId = characterId;
    this.model.UserId = this.user.id;
    this.userService.selectCharacter(this.model).subscribe(() => {
      this.router.navigate(['/charselect/', characterId]);
    }, error => {
      this.error = error;
      console.log(error);
    });
  }
}
