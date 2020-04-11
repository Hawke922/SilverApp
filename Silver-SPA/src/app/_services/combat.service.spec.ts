/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { CombatService } from './combat.service';

describe('Service: Combat', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [CombatService]
    });
  });

  it('should ...', inject([CombatService], (service: CombatService) => {
    expect(service).toBeTruthy();
  }));
});
