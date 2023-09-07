import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WorkerprofileComponent } from './workerprofile.component';

describe('WorkerprofileComponent', () => {
  let component: WorkerprofileComponent;
  let fixture: ComponentFixture<WorkerprofileComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [WorkerprofileComponent]
    });
    fixture = TestBed.createComponent(WorkerprofileComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
