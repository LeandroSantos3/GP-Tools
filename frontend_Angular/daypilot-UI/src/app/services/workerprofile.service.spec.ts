import { TestBed } from '@angular/core/testing';

import { WorkerprofileService } from './workerprofile.service';

describe('WorkerprofileService', () => {
  let service: WorkerprofileService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(WorkerprofileService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
