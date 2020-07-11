import { Injectable, Inject } from '@Angular/core';
import {  MyResponse } from '../Interfaces';
import { HttpClient, HttpHeaders } from '@angular/common/http';

const httpOptions = {
  headers: new HttpHeaders,
  'Content-Type': 'application/json'
}

@Injectable({
  providedIn: 'root'
})

export class HomeService {
  baseUrl: string;
  constructor(protected http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  public restablecer() {
    console.log("Enviando peticion")
    this.http.delete<MyResponse>(this.baseUrl + "api/Home/Restaurar").
      subscribe(result => {
        console.log(result);
      },
        error => console.log(error));;
    console.log("Peticion enviada")
  }
}
