import { Component, Inject, ViewChild, ElementRef } from '@angular/core';
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
  ClienteControl = new FormControl('');
  BuscarControl = new FormControl('');
  pageActual: number = 1;

  @ViewChild('buscar') buscar;
  @ViewChild('name') name;
  @ViewChild('CodCliente') CodCliente;
  @ViewChild('BotonEditar') BotonEditar;
  @ViewChild('BotonEnviar') BotonEnviar;
  @ViewChild('BotonBuscar') BotonBuscar;

  constructor(http: HttpClient, @Inject("BASE_URL") baseUrl: string,
    protected servicioServices: ServicioService) {
    this.GetServicios();
  }

  public GetServicios() {
    this.listServicios = this.servicioServices.GetServicios();
  }

  public SendServicio() {
    this.servicioServices.Add(this.nameControl.value, this.valoxhoraControl.value, this.ClienteControl.value);
    this.ActualizarLista();
    this.Limpiar()
  }

  public Edit(servicio: Servicio) {
    this.idControl.setValue(servicio.id);
    this.nameControl.setValue(servicio.nombreServicio);
    this.valoxhoraControl.setValue(servicio.valorxHora);
    this.BotonEnviar.nativeElement.disabled = true;
    this.BotonEditar.nativeElement.disabled = false;
    this.CodCliente.nativeElement.disabled = true;
  }

  public Editar() {
    this.BotonEditar.nativeElement.disabled = true;
    this.BotonEnviar.nativeElement.disabled = false;
    this.CodCliente.nativeElement.disabled = false;

    this.servicioServices.Modify(this.idControl.value,
                                  this.nameControl.value,
                                  this.valoxhoraControl.value);
    this.ActualizarLista()
    this.Limpiar();
  }

  public Delete(servicio: Servicio) {
    this.servicioServices.Delete(servicio.id);
    this.ActualizarLista()
    this.Limpiar();
  }

  public Limpiar() {
    this.idControl.setValue("");
    this.nameControl.setValue("");
    this.valoxhoraControl.setValue("");
    this.ClienteControl.setValue("");
    this.name.nativeElement.focus();
  }
  public ActualizarLista() {
    setTimeout(() => {
      this.GetServicios();

    }, 700)
  }


}
