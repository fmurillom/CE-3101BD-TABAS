import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Conexion } from '../conexion';

@Injectable({
  providedIn: 'root'
})
export class MaxmarcasService {

  conexion: Conexion = new Conexion();


  constructor(private http: HttpClient) { }

  getMaxMarcas(){
    return this.http.get(this.conexion.ip + "maxMarcas")
  }
}
