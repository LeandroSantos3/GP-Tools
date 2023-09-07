import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CategoryStateComponent } from './category-state.component';

describe('CategoryStateComponent', () => {
  let component: CategoryStateComponent;
  let fixture: ComponentFixture<CategoryStateComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CategoryStateComponent]
    });
    fixture = TestBed.createComponent(CategoryStateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
