import { Component, OnInit } from '@angular/core';
import {User} from "src/app/user";

@Component({
  selector: 'app-reg-usr-layout',
  templateUrl: './reg-usr-layout.component.html',
  styleUrls: ['./reg-usr-layout.component.css']
})
export class RegUsrLayoutComponent implements OnInit {

  buttonDisabled: boolean = true;
  uni: Array<string>;

  showAlert: boolean = false;

  showSucces: boolean = false;

  newUser: User = new User();


  constructor() {
    this.uni = ["Instituto Tecnologico de Costa Rica", "Universidad de Costa Rica"];
   }

  ngOnInit() {
  }

  createUser(nombre: string, a1: string, a2:string, tel:string, cor: string, usr: string, pass:string){
    if(nombre == "" || a1 == "" || a2 == "" || tel == "" || cor == "" || usr == "" || pass == ""){
      this.showAlert = true;
    }
    else{
      this.newUser.nombre = nombre;
      this.newUser.apellido1 = a1;
      this.newUser.apellido2 = a2;
      this.newUser.telefono = +tel;
      this.newUser.correo = cor;
      this.newUser.username = usr;
      this.newUser.password = pass;

      this.showAlert = false;
      this.showSucces = true;

      console.log(this.newUser);
    }
  }
}
