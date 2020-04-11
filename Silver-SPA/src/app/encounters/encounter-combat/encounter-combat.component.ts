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

  // processHero() {
  //   const cd = this.combatData;
  //   const cs = this.combatService;
  //   const off = this.combatData.pickedOffense;
  //   const hero = this.data.character;
  //   const enemy = this.data.enemy;

  //   if (off.typeId === 1) {
  //     this.combatData.heroTrueDamage = (hero.strongAttack + off.baseDamage) * cs.powerDifference(hero.strongAttack, enemy.strongDefense);
  //   } else if (off.typeId === 2) {
  //     this.combatData.heroTrueDamage = (hero.fastAttack + off.baseDamage) * cs.powerDifference(hero.fastAttack, enemy.fastDefense);
  //   } else {
  //     this.combatData.heroTrueDamage = (hero.specialAttack + off.baseDamage) * cs.powerDifference(hero.specialAttack, enemy.specialDefense);
  //   }

  //   this.combatData.heroDamage = cd.heroTrueDamage * cs.attackEfficiency(off.typeId, cd.enemyDefense.typeId);
  //   this.combatData.enemyBlockedDamage = cd.heroTrueDamage - cd.heroDamage;
  //   this.combatData.enemyHealth -= cd.heroDamage;
  //   this.combatData.enemyHealthBarValue = cs.percentage(this.data.enemy.hp, cd.enemyHealth);

  //   if (Math.sign(cd.enemyHealthBarValue) === -1 || 0 || -0) {
  //     this.combatData.enemyHealthBarValue = 0;
  //     this.combatData.enemyHealth = 0;
  //     this.combatData.combatComplete = true;
  //   }
  // }

}
