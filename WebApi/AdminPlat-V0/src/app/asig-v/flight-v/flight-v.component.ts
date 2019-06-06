import { Component, OnInit, Input } from '@angular/core';
import { Vuelo } from 'src/app/vuelo';
import { Router } from '@angular/router';

@Component({
  selector: 'app-flight-v',
  templateUrl: './flight-v.component.html',
  styleUrls: ['./flight-v.component.css']
})
export class FlightVComponent implements OnInit {

  @Input() flight : Vuelo;

  constructor(private router: Router) { }

  ngOnInit() {
  }

  reservE(){
    this.router.navigate(['AsignBc', this.flight.id]);
    console.log("Hoolis");
  }

}
