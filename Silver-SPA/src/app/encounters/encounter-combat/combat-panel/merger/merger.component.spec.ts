/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { MergerComponent } from './merger.component';

describe('MergerComponent', () => {
  let component: MergerComponent;
  let fixture: ComponentFixture<MergerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MergerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MergerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
