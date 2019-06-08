import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CartVLayoutComponent } from './cart-vlayout.component';

describe('CartVLayoutComponent', () => {
  let component: CartVLayoutComponent;
  let fixture: ComponentFixture<CartVLayoutComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CartVLayoutComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CartVLayoutComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
