import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CmalLayoutComponent } from './cmal-layout.component';

describe('CmalLayoutComponent', () => {
  let component: CmalLayoutComponent;
  let fixture: ComponentFixture<CmalLayoutComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CmalLayoutComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CmalLayoutComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
