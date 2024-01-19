import { Component, OnInit } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { EmpleadoService, IEmpleado } from './empleado.service';

@Component({
  selector: 'app-empleado',
  templateUrl: './empleado.component.html',
  styleUrls: ['./empleado.component.css']
})
export class EmpleadoComponent implements OnInit {

  empleados$: Observable<any>;
  //empleados = [];

  constructor(private empleadoService: EmpleadoService) {
    this.empleados$ = empleadoService.getAll();
  }

  ngOnInit(): void {

    //this.empleadoService.getAll().subscribe({
    //  next: (data: any) => {
    //    this.empleados = data.result;
    //    console.log(this.empleados);
    //  },
    //  error: (error) => console.log(error)
    //});
      
  }


  consultar() {
    this.empleadoService.getAll().subscribe({
      next: (result: any) => {
        console.log(result);
      }
    })
  }


  guardar() {

    const empleado: IEmpleado = {
      empleado_Id: 0,
      nombre: "Leoabardo",
      apellido_paterno: "Amarillas",
      apellido_materno: "Cuen",
      fecha_nacimiento: new Date(),
      estatus_Id: 1
    };

    this.empleadoService.save(empleado).subscribe({
      next: (result: any) => {
        console.log(result);
      }
    })

  }

}
