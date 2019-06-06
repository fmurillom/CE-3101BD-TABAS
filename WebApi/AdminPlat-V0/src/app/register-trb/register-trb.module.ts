import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RegLayoutComponent } from './reg-layout/reg-layout.component';

@NgModule({
  declarations: [RegLayoutComponent],
  imports: [
    CommonModule
  ],
  exports:[RegLayoutComponent]
})
export class RegisterTrbModule { }
