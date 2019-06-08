import { Component, OnInit, Input } from '@angular/core';
import { BagCart } from 'src/app/bag-cart';
import { ActivatedRoute, Router } from '@angular/router';
import { Conexion } from 'src/app/conexion';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-bag-list',
  templateUrl: './bag-list.component.html',
  styleUrls: ['./bag-list.component.css']
})
export class BagListComponent implements OnInit {

  conexion: Conexion = new Conexion();

  fId: number;

  @Input() cart : number;

  constructor(private route: ActivatedRoute, private router: Router, private httpclient: HttpClient) { }

  ngOnInit() {
    this.fId = this.route.snapshot.params['id'];
  }

  assignBC(){
    this.httpclient.post(this.conexion.ip + "asigbc", JSON.stringify({idvuelo: this.fId, idbagcart: this.cart})).subscribe(
      data  => {
      console.log("POST Request is successful ", data);
      },
      error  => {
      console.log("Error", error);
      });
      this.router.navigate(['Asign']);
    
  }

}
