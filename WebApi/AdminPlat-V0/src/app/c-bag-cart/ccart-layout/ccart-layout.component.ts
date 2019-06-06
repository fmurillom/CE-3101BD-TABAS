import { Component, OnInit } from '@angular/core';
import { Marcas } from 'src/app/marcas';
import { BagCart } from 'src/app/bag-cart';

@Component({
  selector: 'app-ccart-layout',
  templateUrl: './ccart-layout.component.html',
  styleUrls: ['./ccart-layout.component.css']
})
export class CcartLayoutComponent implements OnInit {

  marcas: Array<Marcas> = [{nombre: "Mercedes", pesoMax: 10}, {nombre: "BYD", pesoMax: 5}, {nombre: "Ford", pesoMax: 22}];

  newBC: BagCart = new BagCart();

  showAlert: boolean = false;

  showSucces: boolean = false;

  showNMarca: boolean = false;

  constructor() { }

  ngOnInit() {
  }

  createBC(marca: string, ident: string, anno: string){
    if(marca == "" || ident == "" || anno == "" ){
      this.showAlert = true;
    }else{
      this.newBC.marca = marca;

      let marcSelec;

      marcSelec = this.marcas.find(x => x.nombre == marca);

      this.newBC.pesoMax = marcSelec.pesoMax;

      this.newBC.placa = ident;
      this.newBC.anno = anno;

      console.log(this.newBC);
      this.showAlert = false;
      this.showSucces = true;
    }
  }

  showEditor(){
    this.showNMarca = !this.showNMarca;
  }

}
