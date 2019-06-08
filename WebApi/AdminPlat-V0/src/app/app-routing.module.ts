import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LayoutComponent } from './ui/layout/layout.component';
import { RegLayoutComponent } from './register-trb/reg-layout/reg-layout.component';
import { RegUsrLayoutComponent } from './register/reg-usr-layout/reg-usr-layout.component';
import { LoginComponent } from './login/login.component';
import { CmalLayoutComponent } from './c-maletas/cmal-layout/cmal-layout.component';
import { CcartLayoutComponent } from './c-bag-cart/ccart-layout/ccart-layout.component';
import { AssignLayoutComponent } from './asig-v/assign-layout/assign-layout.component';
import { CartLayoutComponent } from './asig-v/cart-layout/cart-layout.component';
import { CartVLayoutComponent } from './cerrar-bag-c/cart-vlayout/cart-vlayout.component';

const routes: Routes = [
  { path: '', component: LayoutComponent}
  ,{path: 'registerTrb', component: RegLayoutComponent}
  ,{path: 'registerUsr', component: RegUsrLayoutComponent}
  ,{path: 'login', component: LoginComponent}
  ,{path: 'Cmal', component: CmalLayoutComponent}
  ,{path: 'CbagC', component: CcartLayoutComponent}
  ,{path: 'Asign', component: AssignLayoutComponent}
  ,{path: 'AsignBc/:id', component: CartLayoutComponent}
  ,{path: 'cerrBC', component: CartVLayoutComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
