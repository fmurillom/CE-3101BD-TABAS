import { Component, OnInit } from '@angular/core';
import { Vuelo } from 'src/app/vuelo';
import { VuelosService } from 'src/app/service/vuelos.service';
import { HttpClient } from '@angular/common/http';
import { Conexion } from 'src/app/conexion';

@Component({
  selector: 'app-assign-layout',
  templateUrl: './assign-layout.component.html',
  styleUrls: ['./assign-layout.component.css']
})
export class AssignLayoutComponent implements OnInit {

  conexion: Conexion = new Conexion();

  vuelos : Array<Vuelo>;/* = 
  [{id: 1, avion: "", bagCart: "", fecha:"29/5/2019" }
  ,{id: 2, avion: "", bagCart: "", fecha:"29/5/2019" }
  ,{id: 3, avion: "", bagCart: "", fecha:"29/5/2019" }]
 
*/
  constructor(private vueloService: VuelosService) { }

  ngOnInit() {
    this.vueloService.getIdents().subscribe((dato: {data: any}) => {
      console.log(dato)
      this.vuelos = dato['data']});
    console.log(this.vuelos);
  }
}
