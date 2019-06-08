import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LogInComponent } from './log-in/log-in.component';
import { SignUpComponent } from './sign-up/sign-up.component';
import { RegScanComponent } from './reg-scan/reg-scan.component';
import { RegPlaneComponent } from './reg-plane/reg-plane.component';

const routes: Routes = [
  //{path'',component:MainviewComponent}
  {path:'log-in',component: LogInComponent},
  {path:'sign-up',component: SignUpComponent},
  {path:'reg-scan',component: RegScanComponent},
  {path:'reg-plane',component: RegPlaneComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
