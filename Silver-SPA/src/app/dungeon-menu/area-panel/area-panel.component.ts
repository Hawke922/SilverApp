import { Component, OnInit } from '@angular/core';
import { DungeonService } from 'src/app/_services/dungeon.service';
import { Enemy } from 'src/app/_models/enemy';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-area-panel',
  templateUrl: './area-panel.component.html',
  styleUrls: ['./area-panel.component.css']
})
export class AreaPanelComponent implements OnInit {
  data: any;
  selectedArea: any;
  currentMode: any;

  filterEnemy = (enemy: Enemy) => {
    return !enemy.isBoss;
  }

  filterBoss = (enemy: Enemy) => {
    return enemy.isBoss;
  }

  constructor(private dungeonService: DungeonService, private route: ActivatedRoute) { }

  ngOnInit() {    
    this.route.data.subscribe(data => {
    this.data = data['dungeon'];
  });
    this.dungeonService.selectedArea.subscribe(a => this.selectedArea = a);
    this.dungeonService.currentMode.subscribe(m => this.currentMode = m);
  }

  print() {
    console.log(this.selectedArea);
  }

}
