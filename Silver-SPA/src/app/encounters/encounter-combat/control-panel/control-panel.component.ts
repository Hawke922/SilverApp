import { Component, OnInit } from '@angular/core';
import { CombatService } from 'src/app/_services/combat.service';
import { Ability } from 'src/app/_models/ability';
import { CombatData } from 'src/app/_models/combat-data';
import { Router } from '@angular/router';

@Component({
  selector: 'app-control-panel',
  templateUrl: './control-panel.component.html',
  styleUrls: ['./control-panel.component.css']
})
export class ControlPanelComponent implements OnInit {
  data: any;
  combatData: CombatData;

  constructor(private combatService: CombatService, private router: Router) { }

  ngOnInit() {
    this.combatService.data.subscribe(data => this.data = data);
    this.combatService.combatData.subscribe(CD => this.combatData = CD);
  }

  filterOffensiveAbility = (ability: Ability) => {
    return ability.isOffensive;
  }

  filterDefensiveAbility = (ability: Ability) => {
    return !ability.isOffensive;
  }

  pickOffense(ability) {
    this.combatData.hero.offense = ability;
  }

  pickDefense(ability) {
    this.combatData.hero.defense = ability;
  }

  return() {
    const navigationExtras = {
      queryParams: { character: this.data.character.id }
    };
    this.router.navigate([
      ['/dungmenu/'], this.data.character.activeDungeonId, navigationExtras]);
    console.log(this.data.character);
  }
}
