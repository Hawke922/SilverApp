import { Component, OnInit, OnDestroy } from '@angular/core';
import { Dungeon } from '../_models/dungeon';
import { ActivatedRoute } from '@angular/router';
import { Enemy } from '../_models/enemy';
import { User } from '../_models/user';

@Component({
  selector: 'app-dungeon-menu',
  templateUrl: './dungeon-menu.component.html',
  styleUrls: ['./dungeon-menu.component.css']
})
export class DungeonMenuComponent implements OnInit, OnDestroy {
  data: any;
  dungeon: Dungeon;
  user: User;
  filterEnemy = (enemy: Enemy) => {
    return !enemy.isBoss;
  }

  constructor(private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.data = data['dungeon'];
    });
    document.body.classList.add(`bg-${this.data.dungeon.codeName}`);
  }

  ngOnDestroy() {
    document.body.classList.remove(`bg-${this.data.dungeon.codeName}`);
  }

}
