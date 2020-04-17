import { Component, OnInit, Input } from '@angular/core';
import { Area } from 'src/app/_models/area';
import { DungeonService } from 'src/app/_services/dungeon.service';

@Component({
  selector: 'app-area-card',
  templateUrl: './area-card.component.html',
  styleUrls: ['./area-card.component.css'],
  styles: [`
  .areaSelected {
    transform: scale(1.1);
    box-shadow: inset 0 0px 20px #111, 0 0 20px var(--main-color);
  }`
  ]
})
export class AreaCardComponent implements OnInit {
  selectedArea: any;
  currentMode: any;
  @Input() area: Area;

  constructor(private dungeonService: DungeonService) { }

  ngOnInit() {
    this.dungeonService.selectedArea.subscribe(a => this.selectedArea = a);
    this.dungeonService.currentMode.subscribe(m => this.currentMode = m);
  }

  explore(area) {
    this.currentMode = 'explore';
    this.dungeonService.loadMode(this.currentMode);
    this.selectedArea = area;
    this.dungeonService.loadSelectedArea(this.selectedArea);
  }

  challenge(area) {
    this.currentMode = 'challenge';
    this.dungeonService.loadMode(this.currentMode);
    this.selectedArea = area;
    this.dungeonService.loadSelectedArea(this.selectedArea);
  }
}
