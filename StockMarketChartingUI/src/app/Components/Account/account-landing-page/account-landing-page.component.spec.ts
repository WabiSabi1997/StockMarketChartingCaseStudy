import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AccountLandingPageComponent } from './account-landing-page.component';

describe('AccountLandingPageComponent', () => {
  let component: AccountLandingPageComponent;
  let fixture: ComponentFixture<AccountLandingPageComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AccountLandingPageComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AccountLandingPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
