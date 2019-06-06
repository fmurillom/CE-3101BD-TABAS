import { Component, OnInit } from '@angular/core';
import { Marcas } from 'src/app/marcas';
import { Router } from '@angular/router';

@Component({
  selector: 'app-new-marca',
  templateUrl: './new-marca.component.html',
  styleUrls: ['./new-marca.component.css']
})
export class NewMarcaComponent implements OnInit {

  showAlert: boolean = false;

  showSucces: boolean = false;

  newMarc: Marcas = new Marcas();

  constructor(private router: Router) { }

  ngOnInit() {
  }

  createMar(marca: string, pesoMax: string){
    if(marca == "" || pesoMax == "" ){
      this.showAlert = true;
    }else{
      this.newMarc.nombre = marca;
      this.newMarc.pesoMax = +pesoMax;
      console.log(this.newMarc);
      this.showAlert = false;
      this.showSucces = true;
    }

    this.router.navigate(['CbagC']);
  }

}
