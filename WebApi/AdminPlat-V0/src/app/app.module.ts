import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UiModule } from './ui/ui.module';
import { RegisterModule } from './register/register.module';
import { RegisterTrbModule } from './register-trb/register-trb.module';
import { LoginComponent } from './login/login.component';
import { CMaletasModule } from './c-maletas/c-maletas.module';
import { CBagCartModule } from './c-bag-cart/c-bag-cart.module';
import { AsigVModule } from './asig-v/asig-v.module';
import { CerrarBagCModule } from './cerrar-bag-c/cerrar-bag-c.module';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule.forRoot(),
    UiModule,
    RegisterModule,
    RegisterTrbModule,
    CMaletasModule,
    CBagCartModule,
    AsigVModule,
    CerrarBagCModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
