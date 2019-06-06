import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  constructor() { }

  ngOnInit() {
  }

  verify(){
    if(localStorage.getItem('localusr') == "none"){
      return true;
    }else{
      return false;
    }
  }


}
