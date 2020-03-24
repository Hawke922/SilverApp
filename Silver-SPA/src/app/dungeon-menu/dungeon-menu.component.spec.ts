/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { DungeonMenuComponent } from './dungeon-menu.component';

describe('DungeonMenuComponent', () => {
  let component: DungeonMenuComponent;
  let fixture: ComponentFixture<DungeonMenuComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DungeonMenuComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DungeonMenuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
