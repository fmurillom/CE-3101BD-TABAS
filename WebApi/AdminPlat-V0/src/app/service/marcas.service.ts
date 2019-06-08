import { Injectable } from '@angular/core';
import { Conexion } from '../conexion';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class MarcasService {

  conexion: Conexion = new Conexion();

  constructor(private http: HttpClient) { }

  getMarcas(){
    return this.http.get(this.conexion.ip + "marcas")
  }
}
