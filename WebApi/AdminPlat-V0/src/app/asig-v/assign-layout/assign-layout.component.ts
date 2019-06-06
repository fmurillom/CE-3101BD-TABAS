import { Component, OnInit } from '@angular/core';
import { Vuelo } from 'src/app/vuelo';

@Component({
  selector: 'app-assign-layout',
  templateUrl: './assign-layout.component.html',
  styleUrls: ['./assign-layout.component.css']
})
export class AssignLayoutComponent implements OnInit {

  vuelos : Array<Vuelo> = 
  [{id: 1, avion: "", bagCart: "", fecha:"29/5/2019" }
  ,{id: 2, avion: "", bagCart: "", fecha:"29/5/2019" }
  ,{id: 3, avion: "", bagCart: "", fecha:"29/5/2019" }]
 

  constructor() { }

  ngOnInit() {
  }

}
