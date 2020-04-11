import { Component, OnInit } from '@angular/core';
import { CombatService } from 'src/app/_services/combat.service';
import { CombatData } from 'src/app/_models/combat-data';

@Component({
  selector: 'app-hero',
  templateUrl: './hero.component.html',
  styleUrls: ['./hero.component.css']
})
export class HeroComponent implements OnInit {

  data: any;
  combatData: CombatData;

  constructor(private combatService: CombatService) { }

  ngOnInit() {
    this.combatService.data.subscribe(data => this.data = data);
    this.combatService.combatData.subscribe(cd => this.combatData = cd);
  }

}
