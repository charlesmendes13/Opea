import { TestBed } from '@angular/core/testing';
import { OpeaWebService } from './opea.web.service';

describe('OpeaWebService', () => {
  let service: OpeaWebService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(OpeaWebService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
