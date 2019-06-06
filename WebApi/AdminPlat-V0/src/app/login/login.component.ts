import { Component, OnInit } from '@angular/core';
import { User } from '../user';
import {Router} from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  //conexion: Conexion = new Conexion();

  showAlert: boolean = false;

  user: User;

  constructor(
    //private httpclient: HttpClient, 
    private router: Router
    ) { }

  ngOnInit() {
    if(localStorage.getItem('localusr') != "none"){
      localStorage.setItem('localusr', 'none');
      this.router.navigate(['login']);
    }
  }

  sendLogInfo(usr: string, pass: string){
    if(usr == "" || pass == ""){
      this.showAlert = true;
    }
    else{/*
      this.httpclient.post(this.conexion.ip + "login", JSON.stringify({username: usr, password: pass})).subscribe(
        data  => {
        console.log("POST Request is successful ", data);
        let aux = data as {data: User};
        this.user = aux.data;
        console.log(this.user);
        if(this.user.username != 'None'){
          if(this.user.username != '-1'){
            localStorage.setItem('localusr', JSON.stringify(this.user));
            this.router.navigate(['']);
          }else{
            this.showAlert = true;
            console.log("error")
          }
        }
        },
        error  => {
        
        console.log("Error", error);
        })
      
      */}
    this.user = {username: "ollirum", password: "holis", nombre: "Francisco", apellido1: "Murillo", apellido2: "Morgan" ,telefono: 85943291, correo: "fmurillom@gmail.com", nombreTitular: "Francisco Murillo", tarjeta: 1234, fechaExp:"12", puntos: 2, maletas: 0};
    this.router.navigate(['']);
    localStorage.setItem('localusr', JSON.stringify(this.user));
  }
}
