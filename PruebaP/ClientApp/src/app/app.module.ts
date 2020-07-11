import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { ClienteComponent } from './cliente/cliente.Component';
import { ServicioComponent } from './servicio/servicio.Component';
import { ServicioPaisComponent } from './serviciopais/servicioPais.component';
import { HomeComponent } from './Home/home.Component';

import { ClienteService } from './service/ClienteService'
import { ServicioService } from './service/ServicioService'
import { ServicioPaisService } from './service/ServicioPaisService'
import { HomeService } from './service/HomeService'

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    ClienteComponent,
    ServicioComponent,
    ServicioPaisComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule, ReactiveFormsModule,
    RouterModule.forRoot([
      { path: 'home', component: HomeComponent },
      { path: 'clientes', component: ClienteComponent },
      { path: 'servicios', component: ServicioComponent },
      { path: 'serviciosPais', component: ServicioPaisComponent },
      

    ])
  ],
  providers: [ClienteService,
    ServicioService,
    ServicioPaisService,
    HomeService],
  bootstrap: [AppComponent]
})
export class AppModule { }
