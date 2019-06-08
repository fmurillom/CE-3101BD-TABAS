import { Component, OnInit } from '@angular/core';
import { Marcas } from 'src/app/marcas';
import { BagCart } from 'src/app/bag-cart';
import { MarcasService } from 'src/app/service/marcas.service';
import { BcIdentService } from 'src/app/service/bc-ident.service';
import { HttpClient } from '@angular/common/http';
import { Conexion } from 'src/app/conexion';

@Component({
  selector: 'app-ccart-layout',
  templateUrl: './ccart-layout.component.html',
  styleUrls: ['./ccart-layout.component.css']
})
export class CcartLayoutComponent implements OnInit {

  conexion: Conexion = new Conexion();

  marcas: Array<Marcas>;// = [{nombre: "Mercedes", pesoMax: 10}, {nombre: "BYD", pesoMax: 5}, {nombre: "Ford", pesoMax: 22}];

  newBC: BagCart = new BagCart();

  identificadores: Array<number>;

  showAlert: boolean = false;

  showSucces: boolean = false;

  showNMarca: boolean = false;

  showRepetido: boolean = false;

  register: boolean = true;



  constructor(private markService: MarcasService, private bcService: BcIdentService, private httpclient : HttpClient) { }

  ngOnInit() {
    this.markService.getMarcas().subscribe((dato: {data: any}) => {
      console.log(dato)
      this.marcas = dato['data']});
    console.log(this.marcas);

    console.log(this.marcas);


  }

  createBC(mark: string, ident: string, anno: string){
    console.log(this.identificadores);

    this.bcService.getIdents().subscribe((dato: {data: any}) => {
      console.log(dato)
      this.identificadores = dato['data']});

    if(mark == "" || ident == "" || anno == "" ){
      this.showAlert = true;
    }else{
      this.newBC.marca = mark;

      this.newBC.id = +ident;

      this.newBC.modelo = +anno;

      let boolAux = false;

      this.identificadores.forEach(obj =>{
        if(obj == this.newBC.id){
          this.register = false;
        }else{
          this.register = true;
        }
      })

      this.newBC.modelo = +anno;

      if(this.register){
        this.httpclient.post(this.conexion.ip + "regisBC", JSON.stringify(this.newBC)).subscribe(
          data  => {
          console.log("POST Request is successful ", data);
          },
          error  => {
          console.log("Error", error);
          });
          
          console.log(this.newBC);
          this.showAlert = false;
          this.showSucces = true;

      }else{
        this.showRepetido = true;

      }



     
    }
  }

  showEditor(){
    this.showNMarca = !this.showNMarca;
  }

}
