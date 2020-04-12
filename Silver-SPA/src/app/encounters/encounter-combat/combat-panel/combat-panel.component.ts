import { Component, OnInit } from '@angular/core';
import { CombatService } from 'src/app/_services/combat.service';
import { CombatData } from 'src/app/_models/combat-data';
import { trigger, transition, style, animate } from '@angular/animations';

@Component({
  selector: 'app-combat-panel',
  templateUrl: './combat-panel.component.html',
  styleUrls: ['./combat-panel.component.css'],
  animations: [
    trigger(
      'fade',  [
        transition (
          ':enter', [
            style ({ opacity: 0 }),
            animate('200ms ease-out', style ({ opacity: 1 }))
          ]
        ),
        transition (
          ':leave', [
            style ({ opacity: 1 }),
            animate ('200ms ease-in', style ({ opacity: 0 }))
          ]
        )
      ]
    )
  ]
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
