import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LayoutComponent } from './ui/layout/layout.component';
import { LoginComponent } from './login/login.component';
import { ALayoutComponent } from './asig-mal/a-layout/a-layout.component';
import { MalBodComponent } from './mal-bod/mal-bod.component';


const routes: Routes = [{ path: '', component: LayoutComponent}
,{path: 'login', component: LoginComponent}
,{path: 'asigM', component: ALayoutComponent}
,{path: 'asigB', component: MalBodComponent}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
