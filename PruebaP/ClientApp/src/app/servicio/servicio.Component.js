/*import { Component, Inject, ViewChild, ElementRef } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ServicioService } from '../service/ServicioService';
import { Servicio } from '../interfaces';
import { Observable } from 'rxjs';
import { FormControl } from '@angular/forms';


@Component({
  selector: 'app-servicio',
  templateUrl: './servicio.Component.html'
})

export class ServicioComponent {
  public listServicios: Observable<Servicio[]>;
  idControl = new FormControl('');
  nameControl = new FormControl('');
  valoxhoraControl = new FormControl('');
  @ViewChild('BotonEditar') BotonEditar;
  @ViewChild('BotonEnviar') BotonEnviar;


  constructor(http: HttpClient, @Inject("BASE_URL") baseUrl: string,
    protected servicioServices: ServicioService) {
    this.GetServicios();

  }

  public GetServicios() {
    this.listServicios = this.servicioServices.GetServicios();
  }

  public SendServicio() {

  }

  public Edit() {

  }

  public Editar() {

  }

}
*/
//# sourceMappingURL=servicio.Component.js.map