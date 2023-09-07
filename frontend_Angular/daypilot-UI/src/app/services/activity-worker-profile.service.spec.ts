import { TestBed } from '@angular/core/testing';

import { ActivityWorkerProfileService } from './activity-worker-profile.service';

describe('ActivityWorkerProfileService', () => {
  let service: ActivityWorkerProfileService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ActivityWorkerProfileService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
