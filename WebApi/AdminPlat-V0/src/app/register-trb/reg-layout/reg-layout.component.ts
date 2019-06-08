import { Component, OnInit } from '@angular/core';
import {Worker} from 'src/app/worker';
import { Conexion } from 'src/app/conexion';
import { HttpClient } from '@angular/common/http';
import { RolesService } from 'src/app/service/roles.service';


@Component({
  selector: 'app-reg-layout',
  templateUrl: './reg-layout.component.html',
  styleUrls: ['./reg-layout.component.css']
})
export class RegLayoutComponent implements OnInit {

  conexion: Conexion = new Conexion();

  

  showAlert: boolean = false;

  showSucces: boolean = false;

  newWorker: Worker = new Worker();

  roles: Array<{idRol: string, rol: string}>;

  constructor(private httpclient: HttpClient, private rolService: RolesService) { }

  ngOnInit() {
    //hacer request de roles

    this.rolService.getRoles().subscribe((dato: {data: any}) => this.roles = dato['data']);
  }

  createWorker(nombre: string, a1: string, a2:string, usr: string, pass:string, rol: string, cedula: string){
    if(nombre == "" || a1 == "" || a2 == "" ||  rol == "" || usr == "" || pass == "" || cedula == ""){
      this.showAlert = true;1
    }
    else{
      this.newWorker.nombre = nombre;
      this.newWorker.apellido1 = a1;
      this.newWorker.apellido2 = a2;
      this.newWorker.password = pass;
      this.newWorker.rol = +rol;
      this.newWorker.username = usr;
      this.newWorker.cedula = +cedula;
      this.showSucces = true;
      this.showAlert = false;

      this.httpclient.post(this.conexion.ip + "regisTrab", JSON.stringify(this.newWorker)).subscribe(
        data  => {
        console.log("POST Request is successful ", data);
        },
        error  => {
        console.log("Error", error);
        });

    }
    console.log(this.newWorker);
  }

}
