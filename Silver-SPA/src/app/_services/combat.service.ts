import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CombatService {

  private dataSource = new BehaviorSubject<any>({});
  data = this.dataSource.asObservable();

  private combatDataSource = new BehaviorSubject<any>({});
  combatData = this.combatDataSource.asObservable();

  constructor() { }

  loadData(data: any) {
    this.dataSource.next(data);
  }

  loadCombatData(CD: any) {
    this.combatDataSource.next(CD);
  }

  percentage(oldValue: number, newValue: number) {
    return (newValue / oldValue) * 100;
  }

  powerDifference(off: number, def: number) {
    const power = off / def;
    return power < 0.4 ? 0.4 : (power > 2.4 ? 2.4 : power);
  }

  attackEfficiency(off: number, def: number) {
    if (off === def) {
      return 0.25;
    } else if ((off === 1 && def === 2) || (off === 2 && def === 3) || (off === 3 && def === 1)) {
      return 0.75;
    } else {
      return 1;
    }
  }

}
