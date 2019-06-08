import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FlightVComponent } from './flight-v.component';

describe('FlightVComponent', () => {
  let component: FlightVComponent;
  let fixture: ComponentFixture<FlightVComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FlightVComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FlightVComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
