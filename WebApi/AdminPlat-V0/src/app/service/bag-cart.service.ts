import { Injectable } from '@angular/core';
import { Conexion } from '../conexion';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class BagCartService {

  conexion: Conexion = new Conexion();

  constructor(private http: HttpClient) { }

  
  getIdents(){
    return this.http.get(this.conexion.ip + "getBC");
  }

}
