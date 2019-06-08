import { Component, OnInit } from '@angular/core';
import { Worker } from 'src/app/worker';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  admin: boolean = false;
  recepcionista: boolean = false;
  scanner: boolean = false;
  embarcador: boolean = false;

  worker: Worker;

  constructor() { }

  ngOnInit() {
    if(localStorage.getItem('localusr') != "none"){
      this.worker = JSON.parse(localStorage.getItem('localusr'));
      if(this.worker.rol == 0){
        this.scanner = true;
      }
      if(this.worker.rol == 1){
        this.embarcador = true;
      }
      if(this.worker.rol == 2){
        this.admin = true;
      }
      if(this.worker.rol == 3){
        this.recepcionista = true;
      }
    }else{
      this.admin = false;
      this.embarcador = false;
      this.scanner = false;
      this.recepcionista = false;
    }
  }

  verify(){
    if(localStorage.getItem('localusr') == "none"){
      return true;
    }else{
      return false;
    }
  }


}
