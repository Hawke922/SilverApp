import { Component, OnInit } from '@angular/core';
import { CombatService } from 'src/app/_services/combat.service';
import { CombatData } from 'src/app/_models/combat-data';

@Component({
  selector: 'app-enemy',
  templateUrl: './enemy.component.html',
  styleUrls: ['./enemy.component.css']
})
export class EnemyComponent implements OnInit {

  data: any;
  combatData: CombatData;

  constructor(private combatService: CombatService) { }

  ngOnInit() {
    this.combatService.data.subscribe(data => this.data = data);
    this.combatService.combatData.subscribe(cd => this.combatData = cd);
  }

}
