import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { NgQrScannerModule } from 'angular2-qrscanner';
import { ZXingScannerModule } from '@zxing/ngx-scanner';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LogInComponent } from './log-in/log-in.component';
import { SignUpComponent } from './sign-up/sign-up.component';
import { RegScanComponent } from './reg-scan/reg-scan.component';
import { RegPlaneComponent } from './reg-plane/reg-plane.component';
import { DenyComponent } from './deny/deny.component';

@NgModule({
  declarations: [
    AppComponent,
    LogInComponent,
    SignUpComponent,
    RegScanComponent,
    RegPlaneComponent,
    DenyComponent
  ],
  imports: [
    BrowserModule,
    ZXingScannerModule,
    NgQrScannerModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
