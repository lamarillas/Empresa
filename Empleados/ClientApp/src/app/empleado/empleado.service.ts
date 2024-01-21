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
    console.log(this.baseUrl + 'api/empleado/' + empleado_Id);
    return this.http.get(this.baseUrl + 'api/empleado/' + empleado_Id);
  }

  save(empleado: IEmpleado) {
    return this.http.post(this.baseUrl + 'api/empleado', empleado);
  }

  update(empleado: IEmpleado) {
    return this.http.put(this.baseUrl + 'api/empleado', empleado);
  }


  deleteById(empleado_Id: number) {
    console.log(this.baseUrl + 'api/empleado/' + empleado_Id);
    return this.http.delete(this.baseUrl + 'api/empleado/' + empleado_Id);
  }
}

export interface IEmpleado {
  empleado_Id: number;
  nombre: string;
  apellido_Paterno: string;
  apellido_Materno: string;
  fecha_Nacimiento: Date;
  estatus_Id: number
}
