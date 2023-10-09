import { Component, ViewChild } from '@angular/core';
import { FormControl, FormGroup, FormGroupDirective, Validators } from '@angular/forms';
import { MatDatepickerInputEvent } from '@angular/material/datepicker';
import { ModalSharedService } from 'src/app/services/Modal/modal-shared.service';
import { AutorService } from 'src/app/services/autor/autor.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-autor',
  templateUrl: './autor.component.html',
  styleUrls: ['./autor.component.scss']
})
export class AutorComponent {

  @ViewChild('formDirective') formRef!: FormGroupDirective;
  
  //Boton Crear
  CreateLabel:string="Crear"

  //MODAL
  ModalTitle:string='';

  //TABLA
  tableData:any[]=[];
  tblTitle:string ="Tercero";
  displayedColumns: string[] = ['update', 'delete'];
  columns=['id', 'nombreCompleto', 'ciudadProcedencia', 'correoElectronico'];

  events: string[] = [];

  autorform = new FormGroup({
    nombreAutor:new FormControl('', [Validators.required]),
    fechaNacimiento:new FormControl('' ),
    ciudadautor:new FormControl(''),
    emailautor:new FormControl('', [Validators.required]),
  });

  constructor(private _autorService: AutorService, private modalshared:ModalSharedService,){
    this.cleanAutor();
  }
  ngOnInit(): void {
    this._autorService.get().subscribe(res=>{
      if(res.exito==1){
        this.tableData=res.data;
      }
    });
  }

  onCreateRegister(){
    this.modalshared.change('Crear Libro');
  }

  onUpdateRegister(element:any)
  {
    this.modalshared.change('Actualizar Tercero');
    console.log("actualizar Tercero"+ element.noIdentificacion);
  }
    
  onDeleteRegister(element:any)
  { 
    this.modalshared.change('Borrar Tercero');
    console.log("Borrar Tercero"+ element.noIdentificacion);
  }

  cleanAutor(){
    this._autorService.formData = {
        nombreCompleto:'',
        fechaNacimiento:new Date,
        ciudadProcedencia:'',
        correoElectronico:''
      }
  }

  cleanFormulario(){
    this.autorform.controls.nombreAutor.setValue('');
    this.autorform.controls.fechaNacimiento.setValue('');
    this.autorform.controls.ciudadautor.setValue('');
    this.autorform.controls.emailautor.setValue('');
  }

  onSave(){
    this._autorService.formData.nombreCompleto=this.autorform.controls.nombreAutor.value;
    this._autorService.formData.fechaNacimiento= this.autorform.controls.fechaNacimiento.value;
    this._autorService.formData.ciudadProcedencia=this.autorform.controls.ciudadautor.value;
    this._autorService.formData.correoElectronico=this.autorform.controls.emailautor.value;
    this._autorService.SaveOrUpdateAutor().subscribe(res=>{
      if(res.exito===1){
        Swal.fire({
          position: 'top-end',
          icon: 'success',
          title: 'El Autor fué guradado',
          showConfirmButton: false,
          timer: 1500
        })
        this.cleanFormulario();
        this.formRef.resetForm();
      }
      else{
        Swal.fire({
          position: 'top-end',
          icon: 'error',
          title: 'El Autor no fué guardado',
          text:res.data,
          showConfirmButton: false,
          timer: 2000
        }) 
      }
    })

  }
}
