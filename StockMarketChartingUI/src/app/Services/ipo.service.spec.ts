import { TestBed } from '@angular/core/testing';

import { IPOService } from './ipo.service';

describe('IPOService', () => {
  let service: IPOService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(IPOService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
