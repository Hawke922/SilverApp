import { Component, OnInit } from '@angular/core';
import { CombatService } from 'src/app/_services/combat.service';
import { CombatData } from 'src/app/_models/combat-data';

@Component({
  selector: 'app-combat-panel',
  templateUrl: './combat-panel.component.html',
  styleUrls: ['./combat-panel.component.css']
})
export class CombatPanelComponent implements OnInit {

  data: any;
  combatData: CombatData;

  constructor(private combatService: CombatService) { }

  ngOnInit() {
    this.combatService.data.subscribe(data => this.data = data);
    this.combatService.combatData.subscribe(combatData => this.combatData = combatData);
  }

}
