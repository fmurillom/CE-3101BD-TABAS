import { Component, OnInit, Input } from '@angular/core';
import { BagCart } from 'src/app/bag-cart';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-bag-list',
  templateUrl: './bag-list.component.html',
  styleUrls: ['./bag-list.component.css']
})
export class BagListComponent implements OnInit {

  fId: number;

  @Input() cart : BagCart;

  constructor(private route: ActivatedRoute, private router: Router) { }

  ngOnInit() {
    this.fId = this.route.snapshot.params['id'];
  }

  assignBC(){/*
    this.httpclient.post(this.conexion.ip + "reserV", JSON.stringify({id: this.idVuelo, username: this.usuario.username})).subscribe(
      data  => {
      console.log("POST Request is successful ", data);
      },
      error  => {
      console.log("Error", error);
      });*/
      this.router.navigate(['Asign']);
    
  }

}
