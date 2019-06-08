import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Conexion } from '../conexion';
@Injectable({
  providedIn: 'root'
})
export class UniversidadService {

  conexion: Conexion = new Conexion();

  constructor(private http: HttpClient) { }

  getUni(){
    return this.http.get(this.conexion.ip + "unis")
  }
}
