import { formatDate } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { BehaviorSubject, Observable } from 'rxjs';
import { EmpleadoService, IEmpleado } from './empleado.service';

@Component({
  selector: 'app-empleado',
  templateUrl: './empleado.component.html',
  styleUrls: ['./empleado.component.css']
})
export class EmpleadoComponent implements OnInit {

  empleados$: Observable<any>;
  _empleado_Id: any;
  frmEmpleado: FormGroup;
  frmSubmitted: boolean = false;

  apagado: boolean = false;

  constructor(private empleadoService: EmpleadoService) {
    this.empleados$ = empleadoService.getAll();
    this._empleado_Id = "";
    this.frmEmpleado = new FormGroup({
      empleado_Id: new FormControl("", Validators.required),
      nombre: new FormControl({value:"", disabled: true }, Validators.required),
      apellido_Paterno: new FormControl({ value: "", disabled: true }, Validators.required),
      apellido_Materno: new FormControl({ value: "", disabled: true }, Validators.required),
      fecha_Nacimiento: new FormControl({ value: "", disabled: true }, Validators.required),
      estatus_Id: new FormControl({ value: 0, disabled: true }, Validators.required)
    });

    
  }

  ngOnInit(): void {


    
  }

  nuevo() {
    this.frmEmpleado.reset();
    this.frmSubmitted = false;
    this._empleado_Id = 0;
    this.frmEmpleado.patchValue({ empleado_Id: 0, estatus_Id: 1 });
    this.frmEmpleado.controls["empleado_Id"].disable();
    this.frmEmpleado.controls["nombre"].enable();
    this.frmEmpleado.controls["apellido_Paterno"].enable();
    this.frmEmpleado.controls["apellido_Materno"].enable();
    this.frmEmpleado.controls["fecha_Nacimiento"].enable();
    this.frmEmpleado.controls["estatus_Id"].enable();
  }


  limpiar() {
    this.frmEmpleado.reset();
    this.frmSubmitted = false;
    this.frmEmpleado.patchValue({ empleado_Id: "", estatus_Id: 0 });
    this.frmEmpleado.controls["empleado_Id"].enable();
  }


  consultar() {
    //console.log(this.frmEmpleado);
    this.empleadoService.getById(this.frmEmpleado.value.empleado_Id).subscribe({
      next: (data: any) => {
        console.log(data);
        this._empleado_Id = this.frmEmpleado.value.empleado_Id;
        this.frmEmpleado.patchValue(data.result);
        this.frmEmpleado.controls["empleado_Id"].disable();
        this.frmEmpleado.controls["nombre"].enable();
        this.frmEmpleado.controls["apellido_Paterno"].enable();
        this.frmEmpleado.controls["apellido_Materno"].enable();
        this.frmEmpleado.controls["fecha_Nacimiento"].enable();
        this.frmEmpleado.controls["estatus_Id"].enable();
      }
    })
  }


  seleccionar(empleado: IEmpleado) {

    this.frmEmpleado.patchValue(empleado);
    this.frmEmpleado.controls.fecha_Nacimiento.setValue(new Date(empleado.fecha_Nacimiento).toISOString().split('T')[0]);
    this._empleado_Id = empleado.empleado_Id;
    this.frmEmpleado.controls["empleado_Id"].disable();
    this.frmEmpleado.controls["nombre"].enable();
    this.frmEmpleado.controls["apellido_Paterno"].enable();
    this.frmEmpleado.controls["apellido_Materno"].enable();
    this.frmEmpleado.controls["fecha_Nacimiento"].enable();
    this.frmEmpleado.controls["estatus_Id"].enable();
  }

  guardar() {

    this.frmSubmitted = true;

    if (this.frmEmpleado.invalid) return;

    this.frmSubmitted = false;

    const _entityEmpleado = this.frmEmpleado.value;

    if (this._empleado_Id > 0) {
      _entityEmpleado.empleado_Id = this._empleado_Id;
      this.empleadoService.update(_entityEmpleado).subscribe({
        next: (result: any) => {
          //console.log(result);
          this.empleados$ = this.empleadoService.getAll();
          
        }
      });
    } else {
      this.empleadoService.save(_entityEmpleado).subscribe({
        next: (data: any) => {
          //console.log(result);
          this.empleados$ = this.empleadoService.getAll();
          this._empleado_Id = data.result.empleado_Id;
          this.frmEmpleado.patchValue(data.result);
        }
      });
    }
  }

  borrar(empleado_Id: number) {
    //console.log(this.frmEmpleado);
    this.empleadoService.deleteById(empleado_Id).subscribe({
      next: (result: any) => {
        if (result) {
          this.empleados$ = this.empleadoService.getAll();
          this.frmEmpleado.reset();
        }
      }
    })
  }


  isFieldValid(field: string) {
    return (!this.frmEmpleado.controls[field].valid && this.frmEmpleado.controls[field].touched) ||
      (this.frmEmpleado.controls[field].untouched && this.frmSubmitted);
  }

  isEstatusValid() {
    return this.frmSubmitted && this.frmEmpleado.value.estatus_Id == 0;
  }

  displayFieldCss(field: string) {
    return {
      'has-error': this.isFieldValid(field),
      'has-feedback': this.isFieldValid(field)
    };
  }
}
