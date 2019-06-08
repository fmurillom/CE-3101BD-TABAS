import { Injectable } from '@angular/core';
import { Conexion } from '../conexion';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class RolesService {

  conexion: Conexion = new Conexion();

  constructor(private http: HttpClient) { }

  getRoles(){
    return this.http.get(this.conexion.ip + "getRoles");
  }
}
