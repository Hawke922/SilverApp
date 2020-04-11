import { Component, OnInit, AfterViewInit } from '@angular/core';
import { CombatService } from 'src/app/_services/combat.service';
import { CombatData } from 'src/app/_models/combat-data';
import { Router } from '@angular/router';

@Component({
  selector: 'app-merger',
  templateUrl: './merger.component.html',
  styleUrls: ['./merger.component.css']
})
export class MergerComponent implements OnInit, AfterViewInit {

  data: any;
  combatData: CombatData;

  constructor(private combatService: CombatService, private router: Router) { }

  ngOnInit() {
    this.combatService.data.subscribe(data => this.data = data);
    this.combatService.combatData.subscribe(combatData => this.combatData = combatData);
  }

  ngAfterViewInit() {
  }

  dropOffense() {
    this.combatData.hero.offense = null;
  }

  dropDefense() {
    this.combatData.hero.defense = null;
  }

  processTurn(attacker, attackerData, defender, defenderData) {
    const cs = this.combatService;
    const off = attacker.offense;

    if (attacker.offense.typeId === 1) {
      attacker.trueDamage = (attackerData.strongAttack + off.baseDamage)
      * cs.powerDifference(attackerData.strongAttack, defenderData.strongDefense);
    } else if (attacker.offense.typeId === 2) {
      attacker.trueDamage = (attackerData.fastAttack + off.baseDamage)
      * cs.powerDifference(attackerData.fastAttack, defenderData.fastDefense);
    } else {
      attacker.trueDamage = (attackerData.specialAttack + off.baseDamage)
      * cs.powerDifference(attackerData.specialAttack, defenderData.specialDefense);
    }

    attacker.damage = attacker.trueDamage * cs.attackEfficiency(off.typeId, defender.defense.typeId);
    defender.blockedDamage = attacker.trueDamage - attacker.damage;
    defender.health -= attacker.damage;
    defender.healthBarValue = cs.percentage(defenderData.hp, defender.health);

    if (Math.sign(defender.healthBarValue) === -1 || 0 || -0) {
      defender.healthBarValue = 0;
      defender.health = 0;
      this.combatData.combatComplete = true;
      setTimeout(() => {
        this.router.navigate(['/dungmenu/', this.data.character.activeDungeonId]);
    }, 3000);
    }
  }

  endTurn() {
    this.combatData.abilityPicking = false;
    this.combatData.battlePhase = true;
    setTimeout(() => {
      this.combatData.battlePhase = false;
    }, 2500);
    this.enemyPick();

    if (this.data.character.fastAttack >= this.data.enemy.fastAttack) {

      setTimeout(() => {

        this.processTurn(this.combatData.hero, this.data.character, this.combatData.enemy, this.data.enemy);

        setTimeout(() => {

          this.processTurn(this.combatData.enemy, this.data.enemy, this.combatData.hero, this.data.character);

          this.combatData.strategyPhase = true;
          setTimeout(() => {
            this.combatData.strategyPhase = false;
            this.combatData.abilityPicking = true;
            this.combatData.hero.offense = null;
            this.combatData.hero.defense = null;
          }, 2500);
            }, 3000);
      }, 3000);

    } else {

      setTimeout(() => {

        this.processTurn(this.combatData.enemy, this.data.enemy, this.combatData.hero, this.data.character);

        setTimeout(() => {

          this.processTurn(this.combatData.hero, this.data.character, this.combatData.enemy, this.data.enemy);

          this.combatData.strategyPhase = true;
          setTimeout(() => {
            this.combatData.strategyPhase = false;
            this.combatData.abilityPicking = true;
            this.combatData.hero.offense = null;
            this.combatData.hero.defense = null;
          }, 2500);
            }, 3000);
      }, 3000);
    }
  }

  enemyPick() {
    const random = Math.random();

    if (random < 0.75) {
      this.combatData.enemy.offense = this.data.enemy.abilities[0];
    } else {
      this.combatData.enemy.offense = this.data.enemy.abilities[1];
    }

    this.combatData.enemy.defense = this.data.enemy.abilities[2];
  }
}
