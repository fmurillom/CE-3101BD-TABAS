import { Component, OnInit } from '@angular/core';
import { Conexion } from 'src/app/conexion';
import { HttpClient } from '@angular/common/http';
import { GetUserService } from 'src/app/service/get-user.service';
import { GetIdMalService } from 'src/app/service/get-id-mal.service';

@Component({
  selector: 'app-cmal-layout',
  templateUrl: './cmal-layout.component.html',
  styleUrls: ['./cmal-layout.component.css']
})
export class CmalLayoutComponent implements OnInit {

  conexion: Conexion = new Conexion();



  users: Array<String>;// = ["Usuario1", "Usuario2", "Usuario3"];

  maleta: {usrname: string, color: string, idmaleta: number, costo: number, peso: number} = Object();

  numeroMal: number = -1;

  showAlert: boolean = false;

  showSucces: boolean = false;

  constructor(private httpclient: HttpClient, private userService: GetUserService, private malidServ: GetIdMalService) { }

  ngOnInit() {
    

    this.userService.getUsers().subscribe((dato: {data: any}) => {
      console.log(dato)
      this.users = dato['data']});

  }

  createMal(usr: string, color: string, peso: string, costo: string){

    this.malidServ.getUsers().subscribe((dato: {data: any}) => {
      console.log(dato)
      this.numeroMal = dato['data']});

    if(usr == "" || color == "" || peso == "" || costo == "" || this.numeroMal == -1){
      this.showAlert = true;
    }else{
      this.maleta.usrname = usr;
      this.maleta.color = color;
      this.maleta.peso = +peso;
      this.maleta.costo = +costo;
      this.maleta.idmaleta = this.numeroMal;

      this.httpclient.post(this.conexion.ip + "cmaleta", JSON.stringify(this.maleta)).subscribe(
        data  => {
        console.log("POST Request is successful ", data);
        },
        error  => {
        console.log("Error", error);
        });

      console.log(this.maleta);
      this.showAlert = false;
      this.showSucces = true;
    }
  }

}
