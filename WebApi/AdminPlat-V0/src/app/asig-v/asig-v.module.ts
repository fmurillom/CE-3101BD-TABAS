import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AssignLayoutComponent } from './assign-layout/assign-layout.component';
import { FlightVComponent } from './flight-v/flight-v.component';
import { BagListComponent } from './bag-list/bag-list.component';
import { CartLayoutComponent } from './cart-layout/cart-layout.component';

@NgModule({
  declarations: [AssignLayoutComponent, FlightVComponent, BagListComponent, CartLayoutComponent],
  imports: [
    CommonModule
  ],
  exports: [AssignLayoutComponent]
})
export class AsigVModule { }
