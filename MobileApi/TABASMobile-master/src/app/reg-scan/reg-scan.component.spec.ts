import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RegScanComponent } from './reg-scan.component';

describe('RegScanComponent', () => {
  let component: RegScanComponent;
  let fixture: ComponentFixture<RegScanComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RegScanComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RegScanComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
