import { Component, Inject, ViewChild, ElementRef } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ClienteService } from '../service/ClienteService';
import { Cliente } from '../interfaces';
import { Observable } from 'rxjs';
import { FormControl } from '@angular/forms';


@Component({
  selector: 'app-cliente',
  templateUrl: './cliente.Component.html',
})

export class ClienteComponent {
  public listaClientes: Observable<Cliente[]>;
  idControl = new FormControl('');
  NITControl = new FormControl('');
  nameControl = new FormControl('');
  correoControl = new FormControl('');
  @ViewChild('nit') nit;
  @ViewChild('BotonEditar') BotonEditar;
  @ViewChild('BotonEnviar') BotonEnviar;
  
  
  constructor(http: HttpClient, @Inject("BASE_URL") baseUrl: string,
    protected clienteServices: ClienteService) {
    this.GetCliente();
  }

  public GetCliente() {
    this.listaClientes = this.clienteServices.GetCliente();
  }

  public Edit(cliente: Cliente) {
    this.idControl.setValue(cliente.id);
    this.NITControl.setValue(cliente.nit);
    this.nameControl.setValue(cliente.nombre);
    this.correoControl.setValue(cliente.correo);
    this.BotonEditar.nativeElement.disabled = false;
    this.BotonEnviar.nativeElement.disabled = true;
  }

  public Editar() {
    this.idControl.value;
    this.NITControl.value;
    this.nameControl.value;
    this.correoControl.value;
    this.BotonEditar.nativeElement.disabled = true;
    this.BotonEnviar.nativeElement.disabled = false;

    this.clienteServices.Modify(this.idControl.value, this.nameControl.value, this.NITControl.value, this.correoControl.value );
    this.ActilizarLista()
    this.limpiar();
  }

  public Delete(cliente: Cliente) {
    this.clienteServices.Delete(cliente.id);
    this.ActilizarLista()
    this.limpiar();
  }

  public SendClient() {
    this.clienteServices.Add(this.NITControl.value, this.nameControl.value, this.correoControl.value);


    this.ActilizarLista()
    this.limpiar();
  }

  public limpiar() {
    this.idControl.setValue('');
    this.NITControl.setValue('');
    this.nameControl.setValue('');
    this.correoControl.setValue('');
    this.nit.nativeElement.focus();
  }

  public ActilizarLista() {
    setTimeout(() => {
      this.GetCliente();

    }, 700)
  }


}
