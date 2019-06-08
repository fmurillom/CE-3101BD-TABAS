import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RegPlaneComponent } from './reg-plane.component';

describe('RegPlaneComponent', () => {
  let component: RegPlaneComponent;
  let fixture: ComponentFixture<RegPlaneComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RegPlaneComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RegPlaneComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
