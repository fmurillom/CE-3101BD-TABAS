import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RegUsrLayoutComponent } from './reg-usr-layout.component';

describe('RegUsrLayoutComponent', () => {
  let component: RegUsrLayoutComponent;
  let fixture: ComponentFixture<RegUsrLayoutComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RegUsrLayoutComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RegUsrLayoutComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
