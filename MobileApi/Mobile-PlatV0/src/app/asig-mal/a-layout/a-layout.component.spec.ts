import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ALayoutComponent } from './a-layout.component';

describe('ALayoutComponent', () => {
  let component: ALayoutComponent;
  let fixture: ComponentFixture<ALayoutComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ALayoutComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ALayoutComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
