import { Component, OnInit } from '@angular/core';
import {Worker} from 'src/app/worker';

@Component({
  selector: 'app-reg-layout',
  templateUrl: './reg-layout.component.html',
  styleUrls: ['./reg-layout.component.css']
})
export class RegLayoutComponent implements OnInit {

  showAlert: boolean = false;

  showSucces: boolean = false;

  newWorker: Worker = new Worker();

  constructor() { }

  ngOnInit() {
    //hacer request de roles
  }

  createWorker(nombre: string, a1: string, a2:string, usr: string, pass:string, rol: string){
    if(nombre == "" || a1 == "" || a2 == "" ||  rol == "" || usr == "" || pass == ""){
      this.showAlert = true;
    }
    else{
      this.newWorker.nombre = nombre;
      this.newWorker.apellido1 = a1;
      this.newWorker.apellido2 = a2;
      this.newWorker.password = pass;
      this.newWorker.rol = rol;
      this.newWorker.username = usr;
      this.showSucces = true;
      this.showAlert = false;
    }
    console.log(this.newWorker);
  }

}
