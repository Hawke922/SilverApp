import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Enemy } from '../_models/enemy';
import { Character } from '../_models/character';
import { Ability } from '../_models/ability';

@Component({
  selector: 'app-combat',
  templateUrl: './combat.component.html',
  styleUrls: ['./combat.component.css'],
})
export class CombatComponent implements OnInit, OnDestroy {
  data: any;
  enemy: Enemy;
  character: Character;
  offense: Ability;
  defense: Ability;
  enemyOffense: Ability;
  enemyDefense: Ability;
  heroDamage: number;
  enemyDamage: number;
  heroHealth: number;
  enemyHealth: number;
  heroHealthBarValue = 100;
  enemyHealthBarValue = 100;
  blockedDamage = 0;
  strategyPhase = true;
  heroPhase = false;
  enemyPhase = false;
  victory = false;
  defeat = false;

  constructor(private route: ActivatedRoute, private router: Router) { }

  filterOffensiveAbility = (ability: Ability) => {
    return ability.isOffensive;
  }

  filterDefensiveAbility = (ability: Ability) => {
    return !ability.isOffensive;
  }

  ngOnInit() {
    this.route.data.subscribe(data => {
    this.data = data['character'];
    });
    this.heroHealth = this.data.character.hp;
    this.enemyHealth = this.data.enemy.hp;
    document.body.classList.add('bg-duel');
  }

  ngOnDestroy() {
    document.body.classList.remove('bg-duel');
  }

  pickOffense(ability) {
    this.offense = ability;
  }

  pickDefense(ability) {
    this.defense = ability;
  }

  unPickOffense() {
    this.offense = null;
  }

  unPickDefense() {
    this.defense = null;
  }

  enemyPick() {
    const randomOne = Math.random();
    if (randomOne < 0.75) {
      this.enemyOffense = this.data.enemy.abilities[0];
    } else {
      this.enemyOffense = this.data.enemy.abilities[1];
    }
    this.enemyDefense = this.data.enemy.abilities[2];
  }

  enemyPickProto() {
    // defense - will pick according to hero attack last turn, need to implement buffer for last actions

    // offense - enemy can have ultimate ability on cooldown, will use it when it goes off

    // crit chance calculated by "main" stat of character/enemy
  }

  abilityLog(ability) {
    // abilityList = []
    // abilityList[0] = div 1, abilityList[1] = div 2, etc;
    // ability.push => abiliyList
    // abilityList[i] if i > 5 => abilityList remove last item
  }

  processHero() {
    const damage = this.offense.baseDamage + this.data.character.strongAttack;

    if (this.offense.typeId === 1) {
      if (this.enemyDefense.typeId === 1) {
        this.heroDamage = damage * 0.25;
      } else if (this.enemyDefense.typeId === 2) {
        this.heroDamage = damage * 0.75;
      } else {
        this.heroDamage = damage;
      }
    } else if (this.offense.typeId === 2) {
      if (this.enemyDefense.typeId === 1) {
        this.heroDamage = damage;
      } else if (this.enemyDefense.typeId === 2) {
        this.heroDamage = damage * 0.25;
      } else {
        this.heroDamage = damage * 0.75;
      }
    } else {
      if (this.enemyDefense.typeId === 1) {
        this.heroDamage = damage * 0.75;
      } else if (this.enemyDefense.typeId === 2) {
        this.heroDamage = damage;
      } else {
        this.heroDamage = damage * 0.25;
      }
    }

    this.blockedDamage = damage - this.heroDamage;
    this.enemyHealth -= this.heroDamage;
    this.enemyHealthBarValue = this.percentage(this.data.enemy.hp, this.enemyHealth);

    if (Math.sign(this.enemyHealthBarValue) === -1 || 0 || -0) {
      this.enemyHealthBarValue = 0;
      this.enemyHealth = 0;
      this.victory = true;
    }
  }

  processEnemy() {
    const damage = this.enemyOffense.baseDamage + this.data.enemy.strongAttack;

    if (this.enemyOffense.typeId === 1) {
      if (this.defense.typeId === 1) {
        this.enemyDamage = damage * 0.25;
      } else if (this.defense.typeId === 2) {
        this.enemyDamage = damage * 0.75;
      } else {
        this.enemyDamage = damage;
      }
    } else if (this.enemyOffense.typeId === 2) {
      if (this.defense.typeId === 1) {
        this.enemyDamage = damage;
      } else if (this.defense.typeId === 2) {
        this.enemyDamage = damage * 0.25;
      } else {
        this.enemyDamage = damage * 0.75;
      }
    } else {
      if (this.defense.typeId === 1) {
        this.enemyDamage = damage * 0.75;
      } else if (this.defense.typeId === 2) {
        this.enemyDamage = damage;
      } else {
        this.enemyDamage = damage * 0.25;
      }
    }

    this.blockedDamage = damage - this.enemyDamage;
    this.heroHealth -= this.enemyDamage;
    this.heroHealthBarValue = this.percentage(this.data.character.hp, this.heroHealth);

    if (Math.sign(this.heroHealthBarValue) === -1 || 0 || -0) {
      this.heroHealthBarValue = 0;
      this.heroHealth = 0;
      this.defeat = true;
    }
  }

  endTurn() {
    this.strategyPhase = !this.strategyPhase;
    this.enemyPick();

    if (this.data.character.fastAttack >= this.data.enemy.fastAttack) {
      this.heroPhase = true;

      setTimeout(() => {
        this.heroPhase = false;
        this.processHero();
        this.enemyHealth -= this.heroDamage;
        this.enemyHealthBarValue = this.percentage(this.data.enemy.hp, this.enemyHealth);
        if (Math.sign(this.enemyHealthBarValue) === -1 || 0 || -0) {
          this.enemyHealthBarValue = 0;
          this.enemyHealth = 0;
          this.victory = true;
          setTimeout(() => {
            this.router.navigate(['/dungmenu/', this.data.character.activeDungeonId]);
        }, 3000);
        } else {
          this.enemyPhase = true;
          setTimeout(() => {
              this.enemyPhase = false;
              this.processEnemy();
              this.heroHealth -= this.enemyDamage;
              this.heroHealthBarValue = this.percentage(this.data.character.hp, this.heroHealth);
              if (Math.sign(this.heroHealthBarValue) === -1 || 0 || -0) {
                this.heroHealthBarValue = 0;
                this.heroHealth = 0;
                this.defeat = true;
                setTimeout(() => {
                  this.router.navigate(['/dungmenu/', this.data.character.activeDungeonId]);
              }, 3000);
              }
              this.strategyPhase = !this.strategyPhase;
            }, 3000);
        }
      }, 3000);
    } else {
      this.enemyPhase = true;

      setTimeout(() => {
        this.enemyPhase = false;
        this.processEnemy();
        this.heroHealth -= this.enemyDamage;
        this.heroHealthBarValue = this.percentage(this.data.character.hp, this.heroHealth);
        if (Math.sign(this.heroHealthBarValue) === -1 || 0 || -0) {
          this.heroHealthBarValue = 0;
          this.heroHealth = 0;
          this.defeat = true;
          setTimeout(() => {
            this.router.navigate(['/dungmenu/', this.data.character.activeDungeonId]);
        }, 3000);
        } else {
          this.heroPhase = true;
          setTimeout(() => {
              this.heroPhase = false;
              this.processHero();
              this.enemyHealth -= this.heroDamage;
              this.enemyHealthBarValue = this.percentage(this.data.enemy.hp, this.enemyHealth);
              if (Math.sign(this.enemyHealthBarValue) === -1 || 0 || -0) {
                this.enemyHealthBarValue = 0;
                this.enemyHealth = 0;
                this.victory = true;
                setTimeout(() => {
                  this.router.navigate(['/dungmenu/', this.data.character.activeDungeonId]);
              }, 3000);
              }
              this.strategyPhase = !this.strategyPhase;
            }, 3000);
        }
      }, 3000);
    }
  }

  percentage(oldValue, newValue) {
  return (newValue / oldValue) * 100;
  }
}
