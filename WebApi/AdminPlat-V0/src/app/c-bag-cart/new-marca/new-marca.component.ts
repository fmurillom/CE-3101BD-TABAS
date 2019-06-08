import { Component, OnInit } from '@angular/core';
import { Marcas } from 'src/app/marcas';
import { Router } from '@angular/router';
import { MaxmarcasService } from 'src/app/service/maxmarcas.service';
import { HttpClient } from '@angular/common/http';
import { Conexion } from 'src/app/conexion';

@Component({
  selector: 'app-new-marca',
  templateUrl: './new-marca.component.html',
  styleUrls: ['./new-marca.component.css']
})
export class NewMarcaComponent implements OnInit {

  idMarca: number;

  conexion: Conexion = new Conexion();


  showAlert: boolean = false;

  showSucces: boolean = false;

  newMarc: Marcas = new Marcas();

  constructor(private router: Router, private maxMarkService: MaxmarcasService, private httpclient: HttpClient) { }

  ngOnInit() {
    this.maxMarkService.getMaxMarcas().subscribe((dato: {data: any}) => {
      this.idMarca = dato['data']
      console.log(this.idMarca)});
  }

  createMar(marca: string){
    if(marca == ""){
      this.showAlert = true;
    }else{
      this.newMarc.marca = marca;
      this.newMarc.id = this.idMarca;
      console.log(this.newMarc);
      this.showAlert = false;
      this.showSucces = true;
      this.httpclient.post(this.conexion.ip + "regisMarca", JSON.stringify(this.newMarc)).subscribe(
        data  => {
        console.log("POST Request is successful ", data);
        },
        error  => {
        console.log("Error", error);
        });

    }

    this.router.navigate(['CbagC']);
  }

}
