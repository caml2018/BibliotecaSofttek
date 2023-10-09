import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { LibroService } from 'src/app/services/libro/libro.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-configuracion',
  templateUrl: './configuracion.component.html',
  styleUrls: ['./configuracion.component.scss']
})
export class ConfiguracionComponent implements OnInit {

  auxiliarcantidaddelibros:number=0;
  
  configuracionform = new FormGroup({
    cantidadlibros:new FormControl('', [Validators.required]),
  });

  constructor(private _libroService:LibroService)
  {
    this.cleanConfiguracion();
  }

  ngOnInit(): void {
    this._libroService.getCantidadMaximaLibros().subscribe(res=>{
      if(res.exito==1){
        this.configuracionform.controls.cantidadlibros.setValue(res.data.result.numeroMaximoLibros);
      }
    })
  }

  cleanConfiguracion(){
    this._libroService.formDataConfiguracion = {
        id:0,
        numeroMaximoLibros:0
      }
  }

  onSave()
  {
    this._libroService.formDataConfiguracion.numeroMaximoLibros= Number(this.configuracionform.controls.cantidadlibros.value);
    this._libroService.saveCantidadMaximaLibros().subscribe(res=>{
      if(res.exito==1){
        Swal.fire({
          position: 'top-end',
          icon: 'success',
          title: 'Configuracion guradada',
          showConfirmButton: false,
          timer: 1500
        })
      }
    })
  }

}
