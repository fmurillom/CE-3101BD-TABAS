import { Component, OnInit } from '@angular/core';
import { Vuelo } from '../vuelo';
import { Bodega } from '../bodega';
import { GetVuelosService } from '../services/get-vuelos.service';
import { HttpClient } from '@angular/common/http';
import { Conexion } from '../conexion';
import { User } from '../user';

@Component({
  selector: 'app-mal-bod',
  templateUrl: './mal-bod.component.html',
  styleUrls: ['./mal-bod.component.css']
})
export class MalBodComponent implements OnInit {

  conexion: Conexion = new Conexion();

  vuelos: Array<Vuelo>;

  user: User;

  currentVuelo: Vuelo;

  currentMal: {username: string,  idMaleta: number,  trabajadorrx: string, bagcart: number, estado: number, comentario: string};

  vueloId: number;

  maletas: Array<{username: string,  idMaleta: number,  trabajadorrx: string, bagcart: number, estado: number, comentario: string}>;

  bodegas: Array<Bodega>;



  constructor(private vueloServ: GetVuelosService, private httpclient: HttpClient) { }

  ngOnInit() {
    this.vueloServ.getVuelos().subscribe((dato: {data: any}) => {
      console.log(dato)
      this.vuelos = dato['data']});

      this.user = JSON.parse(localStorage.getItem('localusr'));

  }

  show(value: string){
    if(value == ""){
      return false;
    }else{
      return true;
    }
  }

  asigBod(idbod: string){
    console.log({idMaleta: this.currentMal.idMaleta, username: this.currentMal.username, avion: this.currentVuelo.avion, idbod: idbod, trabajadorSC: this.user.username});
    this.httpclient.post(this.conexion.ip + "asigMalAV", JSON.stringify({idMaleta: this.currentMal.idMaleta, username: this.currentMal.username, avion: this.currentVuelo.avion, idbod: idbod, trabajadorSC: this.user.username})).subscribe(
      data  => {
      console.log("POST Request is successful ", data);
      },
      error  => {
      console.log("Error", error);
      });
  }

  changeDetec1(input: string){
    this.vuelos.forEach(obj =>{
      if(obj.id == +input){
        this.currentVuelo = obj;
      }
    console.log(this.currentVuelo);
    })
    this.httpclient.post(this.conexion.ip + "getMalBCid", JSON.stringify({idbagcart: this.currentVuelo.id})).subscribe(
      data  => {
      console.log("POST Request is successful ", data);
      this.maletas = data["data"];
      },
      error  => {
      console.log("Error", error);
      });
  }

  changeDetec2(input: string){

    this.maletas.forEach(obj =>{
      if(obj.idMaleta == +input){
        this.currentMal = obj;
      }
    });

    console.log(this.currentMal);

    this.httpclient.post(this.conexion.ip + "getBod", JSON.stringify({idavion: this.currentVuelo.avion})).subscribe(
      data  => {
      console.log("POST Request is successful ", data);
      this.bodegas = data["data"];
      console.log(this.bodegas);
      },
      error  => {
      console.log("Error", error);
      });
  }

}
