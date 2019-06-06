import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-cmal-layout',
  templateUrl: './cmal-layout.component.html',
  styleUrls: ['./cmal-layout.component.css']
})
export class CmalLayoutComponent implements OnInit {

  users: Array<String> = ["Usuario1", "Usuario2", "Usuario3"];

  maleta: {usr: string, color: string, peso: string, costo: string, numero: number} = Object();

  numeroMal: number = 1;

  showAlert: boolean = false;

  showSucces: boolean = false;

  constructor() { }

  ngOnInit() {
  }

  createMal(usr: string, color: string, peso: string, costo: string){
    if(usr == "" || color == "" || peso == "" || costo == ""){
      this.showAlert = true;
    }else{
      this.maleta.usr = usr;
      this.maleta.color = color;
      this.maleta.peso = peso;
      this.maleta.costo = costo;

      console.log(this.maleta);
      this.showAlert = false;
      this.showSucces = true;
    }
  }

}
