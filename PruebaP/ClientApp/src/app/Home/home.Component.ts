import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HomeService } from '../service/HomeService';

@Component({
  selector: 'app-home',
  templateUrl: './home.Component.html',
})

export class HomeComponent{
  constructor(http: HttpClient, @Inject("BASE_URL") baseUrl: string,
    protected homeServices: HomeService) {
  }
  public restablecer() {
    console.log("hola")
    this.homeServices.restablecer();
    console.log("chao")
  }

}
