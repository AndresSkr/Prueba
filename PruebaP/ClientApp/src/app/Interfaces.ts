export interface Cliente {
  id: number,
  nit: number,
  nombre: string,
  correo:string
}
export interface Servicio {
  id: number,
  nombreServicio: string,
  valorxHora: number
  fk_Cliente: Cliente;
}
export interface Pais {
  id: number,
  nombrePais: string,
}
export interface ServicioPais {
  id: number,
  fk_IdPais: Pais,
  fK_IdServicio: Servicio
}
export interface MyResponse {
  Success: number,
  Data: any,
  Message: string
}
