import { Injectable, Inject } from '@Angular/core';
import { Observable } from 'rxjs';
import { Servicio, MyResponse } from '../Interfaces';
import { HttpClient, HttpHeaders } from '@angular/common/http';

const httpOptions = {
  headers: new HttpHeaders,
  'Content-Type': 'application/json'
}

@Injectable({
  providedIn: 'root'
})

export class ServicioService {
  baseUrl: string;
  constructor(protected http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  public GetServicios(): Observable<Servicio[]> {
    return this.http.get<Servicio[]>(this.baseUrl + "api/Servicio/Listado");
  }


  public Search(id) {
    return this.http.get<Servicio[]>(this.baseUrl + 'api/Servicio/Listado' + id);
  }

  public Add(nombreServicio, valorxhoraServicio, fk_Cliente) {
   
    this.http.post<MyResponse>(this.baseUrl + 'api/Servicio/Add',
      {
        'nombreServicio': nombreServicio,
        'valorxHora': valorxhoraServicio,
        'fk_Cliente': {
          'id': fk_Cliente
        }
      },
      httpOptions).
      subscribe(result => {
        console.log(result);
      },
        error => console.log(error));
  }

 

  public Delete(id) {
    this.http.delete<MyResponse>(this.baseUrl + 'api/Servicio/Delete/' + id, httpOptions).
      subscribe(result => {
        console.log(result);
      },
        error => console.log(error));
  }

  public Modify(id, nombreServicioModificado, valorxhoraServicio,) {
    this.http.put<MyResponse>(this.baseUrl + 'api/Servicio/Modificar/' + id,
      {
        'id': id,
        'nombreServicio': nombreServicioModificado,
        'valorxHora': valorxhoraServicio
      },
      httpOptions).
      subscribe(result => {
        console.log(result);
      },
        error => console.log(error));
  }
}

