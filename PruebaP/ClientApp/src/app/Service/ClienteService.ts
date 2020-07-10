import { Injectable, Inject } from '@Angular/core';
import { Observable } from 'rxjs';
import { Cliente, MyResponse } from '../Interfaces';
import { HttpClient, HttpHeaders } from '@angular/common/http';


const httpOptions = {
  headers: new HttpHeaders,
  'Content-Type': 'application/json'
}

@Injectable({
  providedIn: 'root'
})

export class ClienteService {
  baseUrl: string;
  constructor(protected http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }
  public GetCliente(): Observable<Cliente[]> {
    return this.http.get<Cliente[]>(this.baseUrl + "api/Cliente/Listado");
  }

  public Add(NIT, name, correo) {
    this.http.post<MyResponse>(this.baseUrl + 'api/Cliente/Add', { 'NIT': NIT, 'nombre': name, 'correo':correo }, httpOptions).
      subscribe(result => {
        console.log(result);
      },
        error => console.log(error));
  }


  public Search(id) {
    this.http.post<MyResponse>(this.baseUrl + 'api/Cliente/Listado'+id, httpOptions).
      subscribe(result => {
        console.log(result);
      },
        error => console.log(error));
  }

  public Delete(id) {
    this.http.delete<MyResponse>(this.baseUrl + 'api/Cliente/Delete/'+id, httpOptions).
      subscribe(result => {
        console.log(result);
      },
        error => console.log(error));
  }

  public Modify(id, nameModify, NitModify, CorreoModify) {
    this.http.put<MyResponse>(this.baseUrl + 'api/Cliente/Modificar/' + id, { 'Id': id, 'NIT': NitModify, 'nombre': nameModify, 'correo': CorreoModify }, httpOptions).
      subscribe(result => {
        console.log(result);
      },
        error => console.log(error));
  }
}

