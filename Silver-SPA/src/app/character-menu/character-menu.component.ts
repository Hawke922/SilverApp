import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Character } from '../_models/character';
import { UserService } from '../_services/user.service';
import { Ability } from '../_models/ability';

@Component({
  selector: 'app-character-menu',
  templateUrl: './character-menu.component.html',
  styleUrls: ['./character-menu.component.css']
})
export class CharacterMenuComponent implements OnInit, OnDestroy {
  character: Character;
  // activeCharacter: number;
  filterOffensiveAbility = (ability: Ability) => {
    return ability.isOffensive;
  }

  filterDefensiveAbility = (ability: Ability) => {
    return !ability.isOffensive;
  }

  constructor(private route: ActivatedRoute, public userService: UserService) {}

  ngOnInit() {
    // this.userService.activeCharacter.subscribe(characterId => this.activeCharacter = characterId);
    this.route.data.subscribe(data => {
      this.character = data['character'];
    });
    document.body.classList.add('bg-gradient');
  }

  ngOnDestroy() {
    document.body.classList.remove('bg-gradient');
  }
}
