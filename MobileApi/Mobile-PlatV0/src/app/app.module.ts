import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UiModule } from './ui/ui.module';
import { LoginComponent } from './login/login.component';
import { HttpClientModule } from '@angular/common/http';
import { AsigMalModule } from './asig-mal/asig-mal.module';
import { MalBodComponent } from './mal-bod/mal-bod.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    MalBodComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    UiModule,
    HttpClientModule,
    AsigMalModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
