import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateIPODetailsComponent } from './update-ipodetails.component';

describe('UpdateIPODetailsComponent', () => {
  let component: UpdateIPODetailsComponent;
  let fixture: ComponentFixture<UpdateIPODetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UpdateIPODetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UpdateIPODetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
