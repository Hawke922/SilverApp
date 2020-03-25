import { Component, OnInit } from '@angular/core';
import { Dungeon } from '../_models/dungeon';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-dungeon-menu',
  templateUrl: './dungeon-menu.component.html',
  styleUrls: ['./dungeon-menu.component.css']
})
export class DungeonMenuComponent implements OnInit {
  dungeon: Dungeon;

  constructor(private route: ActivatedRoute, private router: Router) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.dungeon = data['dungeon'];
    });
    // document.body.classList.add(this.dungeon.name); -> add property to dungeon that will select background from global css sheet
  }

}
