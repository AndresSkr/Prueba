import { Injectable, Inject } from '@Angular/core';
import { Observable } from 'rxjs';
import { ServicioPais, MyResponse } from '../Interfaces';
import { HttpClient, HttpHeaders } from '@angular/common/http';

const httpOptions = {
  headers: new HttpHeaders,
  'Content-Type': 'application/json'
}

@Injectable({
  providedIn: 'root'
})

export class ServicioPaisService {
  baseUrl: string;
  constructor(protected http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  public GetServiciosPais(): Observable<ServicioPais[]> {
    return this.http.get<ServicioPais[]>(this.baseUrl + "api/ServicioPais/Listado");
  }
 
  public Add(idServicio, idPais) {
    this.http.post<MyResponse>(this.baseUrl + 'api/ServicioPais/Add',
      {
        'fk_IdPais': {
          'id': idPais
        },
        'fK_IdServicio': {
          'id': idServicio
        }
      },
      httpOptions).
      subscribe(result => {
        console.log(result);
      },
        error => console.log(error));
  }

  public Delete(id) {
    this.http.delete<MyResponse>(this.baseUrl + 'api/ServicioPais/Delete/' + id, httpOptions).
      subscribe(result => {
        console.log(result);
      },
        error => console.log(error));
  }
}

