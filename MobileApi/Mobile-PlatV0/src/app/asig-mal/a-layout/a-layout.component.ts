import { Component, OnInit } from '@angular/core';
import { BagCart } from 'src/app/bag-cart';
import { GetAMalService } from 'src/app/services/get-amal.service';
import { GetBCService } from 'src/app/services/get-bc.service';
import { HttpClient } from '@angular/common/http';
import { User } from 'src/app/user';
import { Conexion } from 'src/app/conexion';

@Component({
  selector: 'app-a-layout',
  templateUrl: './a-layout.component.html',
  styleUrls: ['./a-layout.component.css']
})
export class ALayoutComponent implements OnInit {

  rechazar: boolean = false;

  bagcart: Array<number>;

  showCart: boolean = true;

  user: User;

  conexion: Conexion = new Conexion();

  maletas: Array<{username: string, color: string, idMaleta: string, costo: number, peso: number}>;

  constructor(private maletaService: GetAMalService, private bacCartService: GetBCService, private httpclient: HttpClient) { }

  ngOnInit() {
    this.maletaService.getMaletas().subscribe((dato: {data: any}) => {
      console.log(dato)
      this.maletas = dato['data']});

    this.user = JSON.parse(localStorage.getItem('localusr'));
  }

  asignarMal(idmaleta: string, idcar: string){

    let userMaleta = "";

    console.log(this.maletas);

    this.maletas.forEach( obj => {
      if(obj.idMaleta == idmaleta){
        console.log("obj", obj);
        userMaleta = obj.username
      }
    });

    console.log({idMaleta: idmaleta, username: userMaleta, trabajadorRX: this.user.username, estado: 1, comentario: null, idbagcart: idcar});

    this.httpclient.post(this.conexion.ip + "asigMBC", JSON.stringify({idMaleta: idmaleta, username: userMaleta, trabajadorRX: this.user.username, estado: 1, comentario: "", idbagcart: idcar})).subscribe(
      data  => {
      console.log("POST Request is successful ", data);
      },
      error  => {
      console.log("Error", error);
      });

  }

  rechazarMal(idmaleta: string, idcar: string, comentario: string){
    if(this.rechazar == true){
      this.rechazar = false;
    }else{
      let userMaleta = "";

    console.log(this.maletas);

    this.maletas.forEach( obj => {
      if(obj.idMaleta == idmaleta){
        console.log("obj", obj);
        userMaleta = obj.username
      }
    });

    console.log({idMaleta: idmaleta, username: userMaleta, trabajadorRX: this.user.username, estado: 2, comentario: comentario, idbagcart: idcar});

    this.httpclient.post(this.conexion.ip + "asigMBC", JSON.stringify({idMaleta: idmaleta, username: userMaleta, trabajadorRX: this.user.username, estado: 2, comentario: comentario, idbagcart: idcar})).subscribe(
      data  => {
      console.log("POST Request is successful ", data);
      },
      error  => {
      console.log("Error", error);
      });
    }
  }

  changeDetec(input: string){
    this.showCart = true;
    this.bacCartService.getBC().subscribe((dato: {data: any}) => {
      console.log(dato)
      this.bagcart = dato['data']});
  }

}
