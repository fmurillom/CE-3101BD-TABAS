import { Injectable } from '@angular/core';
import { Conexion } from '../conexion';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class GetUserService {

  conexion: Conexion = new Conexion();

  constructor(private http: HttpClient) { }

  getUsers(){

    return this.http.get(this.conexion.ip + "getUsernames");

  }
}
