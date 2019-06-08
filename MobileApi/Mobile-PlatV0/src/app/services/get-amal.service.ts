import { Injectable } from '@angular/core';
import { Conexion } from '../conexion';
import { HttpClient } from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})
export class GetAMalService {

  conexion: Conexion = new Conexion();

  constructor(private http: HttpClient) { }

  getMaletas(){
    return this.http.get(this.conexion.ip + "getAllMaletas");
  }
}
