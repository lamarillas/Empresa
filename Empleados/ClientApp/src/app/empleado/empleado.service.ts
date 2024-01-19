import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class EmpleadoService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getAll() {
    console.log(this.baseUrl + 'api/empleado');
    return this.http.get(this.baseUrl + 'api/empleado');
  }

  getById(empleado_Id: number) {
    return this.http.get(this.baseUrl + 'api/empleado/' + empleado_Id);
  }

  save(empleado: IEmpleado) {
    return this.http.post(this.baseUrl + 'api/empleado', empleado);
  }
}

export interface IEmpleado {
  empleado_Id: number;
  nombre: string;
  apellido_paterno: string;
  apellido_materno: string;
  fecha_nacimiento: Date;
  estatus_Id: number
}
