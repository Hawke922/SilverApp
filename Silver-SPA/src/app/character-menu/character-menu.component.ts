import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Character } from '../_models/character';

@Component({
  selector: 'app-character-menu',
  templateUrl: './character-menu.component.html',
  styleUrls: ['./character-menu.component.css']
})
export class CharacterMenuComponent implements OnInit, OnDestroy {
  character: Character;

  constructor(private route: ActivatedRoute, private router: Router) {}

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.character = data['character'];
    });
    document.body.classList.add('bg-gradient');
  }

  ngOnDestroy() {
    document.body.classList.remove('bg-gradient');
  }

  back() {
    this.router.navigate(['/charselect']);
  }

  // characterLoad() {
  //   for (const char of this.user.characters) {
  //     const entries = Object.entries(char);
  //     const activeChar = parseInt(sessionStorage.getItem('Activechar'), 10);
  //     if (entries[0].includes(activeChar)) {
  //       this.route.data.subscribe(data => {
  //         this.character = data['character'];
  //       });
  //     }
  //   }
  // }
}
