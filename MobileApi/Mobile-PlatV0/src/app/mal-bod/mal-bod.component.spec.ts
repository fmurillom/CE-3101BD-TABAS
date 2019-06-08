import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MalBodComponent } from './mal-bod.component';

describe('MalBodComponent', () => {
  let component: MalBodComponent;
  let fixture: ComponentFixture<MalBodComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MalBodComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MalBodComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
