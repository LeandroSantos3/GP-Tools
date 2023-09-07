import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ActivityToWorkerProfileComponent } from './activity-to-worker-profile.component';

describe('ActivityToWorkerProfileComponent', () => {
  let component: ActivityToWorkerProfileComponent;
  let fixture: ComponentFixture<ActivityToWorkerProfileComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ActivityToWorkerProfileComponent]
    });
    fixture = TestBed.createComponent(ActivityToWorkerProfileComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
