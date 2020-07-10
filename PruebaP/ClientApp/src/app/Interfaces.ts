export interface Cliente {
  id: number,
  nit: number,
  nombre: string,
  correo:string
}
export interface Servicio {
  id: number,
  nombreServicio: string,
  precioxHra: number
  cliente: Cliente;
}
export interface Pais {
  id: number,
  nombrePais: string,
}
export interface MyResponse {
  Success: number,
  Data: any,
  Message: string
}
