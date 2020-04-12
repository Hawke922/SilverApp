import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CombatService } from 'src/app/_services/combat.service';
import { CombatData } from 'src/app/_models/combat-data';

@Component({
  selector: 'app-encounter-combat',
  templateUrl: './encounter-combat.component.html',
  styleUrls: ['./encounter-combat.component.css']
})
export class EncounterCombatComponent implements OnInit {
  data: any;
  combatData: CombatData;

  constructor(private route: ActivatedRoute, private combatService: CombatService, private router: Router) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
    this.data = data['character'];
    });
    this.combatService.loadData(this.data);
    this.combatService.combatData.subscribe(CD => this.combatData = CD);
    this.initiateCombat();
  }

  initiateCombat() {
    this.combatData = {
      abilityPicking: true,
      battlePhase: false,
      victory: false,
      defeat: false,
      combatComplete: false,
      hero: {
        offense : null,
        defense: null,
        health: this.data.character.hp,
        healthBarValue: 100
      },
      enemy: {
        health: this.data.enemy.hp,
        healthBarValue: 100
      }
    };
    this.combatService.loadCombatData(this.combatData);
  }
}
