import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CcartLayoutComponent } from './ccart-layout/ccart-layout.component';
import { NewMarcaComponent } from './new-marca/new-marca.component';

@NgModule({
  declarations: [CcartLayoutComponent, NewMarcaComponent],
  imports: [
    CommonModule
  ],
  exports: [CcartLayoutComponent]
})
export class CBagCartModule { }
