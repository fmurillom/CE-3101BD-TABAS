import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BagCart } from 'src/app/bag-cart';
import { BcIdentService } from 'src/app/service/bc-ident.service';
import { BagCartService } from 'src/app/service/bag-cart.service';

@Component({
  selector: 'app-cart-layout',
  templateUrl: './cart-layout.component.html',
  styleUrls: ['./cart-layout.component.css']
})
export class CartLayoutComponent implements OnInit {

  fId: number;

  bagCarts: Array<number>;/* = [{marca: "Mercedes", pesoMax: 30, placa: "AAA123", anno: "2019", cerrado: null, vueloId: 0}
                              ,{marca: "BYD", pesoMax: 25, placa: "AAA124", anno: "2019", cerrado: null, vueloId: 0}
                              ,{marca: "Ford", pesoMax: 66, placa: "AAA125", anno: "2019", cerrado: null, vueloId: 0}]
*/

  constructor(private route: ActivatedRoute, private bagCartServ: BagCartService) { }

  ngOnInit() {
    this.fId = this.route.snapshot.params['id'];

    this.bagCartServ.getIdents().subscribe((dato: {data: any}) => {
      console.log(dato)
      this.bagCarts = dato['data']});
    console.log(this.bagCarts);
  }
}
