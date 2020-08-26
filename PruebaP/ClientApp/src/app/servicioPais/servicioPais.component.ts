import { Component, Inject, ViewChild, ElementRef } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ServicioPaisService } from '../service/ServicioPaisService';
import { ServicioPais } from '../interfaces';
import { Observable } from 'rxjs';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-servicioPais',
  templateUrl: './servicioPais.Component.html'
})

export class ServicioPaisComponent {
  public listServiciosPais: Observable<ServicioPais[]>;
  idPaisControl = new FormControl('');
  idServicioControl = new FormControl('');
  @ViewChild('idPais') idPais;
  pageActual: number = 1;

  constructor(http: HttpClient, @Inject("BASE_URL") baseUrl: string,
    protected servicioPaisServices: ServicioPaisService) {
    this.GetServicios();
  }

  public GetServicios() {
    this.listServiciosPais = this.servicioPaisServices.GetServiciosPais();
  }

  public SendServicioPais() {
    console.log(this.idServicioControl.value + " "+this.idPaisControl.value )
    this.servicioPaisServices.Add(this.idServicioControl.value, this.idPaisControl.value);
    this.ActualizarLista()
    this.limpiar();
  }


  public Delete(servicioPais: ServicioPais) {
    this.servicioPaisServices.Delete(servicioPais.id);
    this.ActualizarLista()
    this.limpiar();
  }

  public limpiar() {
    this.idServicioControl.setValue('');
    this.idPaisControl.setValue('');
    this.idPais.nativeElement.focus();
  }

  public ActualizarLista() {
    setTimeout(() => {
      this.GetServicios();

    }, 700)
  }

}
