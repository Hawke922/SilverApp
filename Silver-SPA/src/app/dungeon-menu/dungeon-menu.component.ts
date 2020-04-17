import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Enemy } from '../_models/enemy';
import { Area } from '../_models/area';
import { DungeonService } from '../_services/dungeon.service';

@Component({
  selector: 'app-dungeon-menu',
  templateUrl: './dungeon-menu.component.html',
  styleUrls: ['./dungeon-menu.component.css']
})
export class DungeonMenuComponent implements OnInit, OnDestroy {
  data: any;
  dungeonProgress: number;
  styling: {'text-align': 'left;'};

  filterArea = (area: Area) => {
    return area.unlockOn <= this.dungeonProgress;
  }

  constructor(private route: ActivatedRoute, private dungeonService: DungeonService) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.data = data['dungeon'];
      this.dungeonProgress = data['dungeon'].character.progress.dungeonProgress.filter(
        dung => dung.dungeonId === this.data.character.activeDungeonId)[0].explored;
    });
    document.body.classList.add(`bg-${this.data.dungeon.codeName}`);
  }

  ngOnDestroy() {
    document.body.classList.remove(`bg-${this.data.dungeon.codeName}`);
  }

  currentDungeonProgressaa() {
    const activeDung = this.data.character.activeDungeonId;

    const dungeonProgress  = this.data.character.progress.dungeonProgress.filter(
      dung => dung.dungeonId === this.data.character.activeDungeonId)[0].explored;

    if (dungeonProgress[0].explored === undefined) {
      return 0;
    } else {
      return dungeonProgress[0].explored;
    }
  }

  print() {
    console.log(this.data);
  }

}
