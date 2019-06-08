import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CcartLayoutComponent } from './ccart-layout.component';

describe('CcartLayoutComponent', () => {
  let component: CcartLayoutComponent;
  let fixture: ComponentFixture<CcartLayoutComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CcartLayoutComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CcartLayoutComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
