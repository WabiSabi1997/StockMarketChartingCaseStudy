import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DisplayIPOComponent } from './display-ipo.component';

describe('DisplayIPOComponent', () => {
  let component: DisplayIPOComponent;
  let fixture: ComponentFixture<DisplayIPOComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DisplayIPOComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DisplayIPOComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
