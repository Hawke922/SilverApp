/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { DungeonService } from './dungeon.service';

describe('Service: Dungeon', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [DungeonService]
    });
  });

  it('should ...', inject([DungeonService], (service: DungeonService) => {
    expect(service).toBeTruthy();
  }));
});
