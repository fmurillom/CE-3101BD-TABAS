import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BagCart } from 'src/app/bag-cart';

@Component({
  selector: 'app-cart-layout',
  templateUrl: './cart-layout.component.html',
  styleUrls: ['./cart-layout.component.css']
})
export class CartLayoutComponent implements OnInit {

  fId: number;

  bagCarts: Array<BagCart> = [{marca: "Mercedes", pesoMax: 30, placa: "AAA123", anno: "2019", cerrado: null, vueloId: 0}
                              ,{marca: "BYD", pesoMax: 25, placa: "AAA124", anno: "2019", cerrado: null, vueloId: 0}
                              ,{marca: "Ford", pesoMax: 66, placa: "AAA125", anno: "2019", cerrado: null, vueloId: 0}]


  constructor(private route: ActivatedRoute) { }

  ngOnInit() {
    this.fId = this.route.snapshot.params['id'];
  }
}
