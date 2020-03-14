import { Component, OnInit } from '@angular/core';
import { User } from '../_models/user';
import { ActivatedRoute, Router } from '@angular/router';
import { Character } from '../_models/character';

@Component({
  selector: 'app-character-menu',
  templateUrl: './character-menu.component.html',
  styleUrls: ['./character-menu.component.css']
})
export class CharacterMenuComponent implements OnInit {
  user: User;
  character: Character;

  constructor(private route: ActivatedRoute, private router: Router) {}

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.user = data['user'];
    });
    this.characterSelector();
  }

  back() {
    this.router.navigate(['/charselect']);
  }

  characterSelector() {
    for (const char of this.user.characters) {
      const entries = Object.entries(char);
      const activeChar = parseInt(sessionStorage.getItem('Activechar'), 10);
      if (entries[0].includes(activeChar)) {
        this.character = char;
      }
    }
  }
}
