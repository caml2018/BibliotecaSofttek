import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup, FormGroupDirective, Validators } from '@angular/forms';
import { Observable, debounceTime, distinctUntilChanged, map, startWith, switchMap } from 'rxjs';
import { Libro } from 'src/app/models/libro.model';
import { ModalSharedService } from 'src/app/services/Modal/modal-shared.service';
import { AutorService } from 'src/app/services/autor/autor.service';
import { LibroService } from 'src/app/services/libro/libro.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-libro',
  templateUrl: './libro.component.html',
  styleUrls: ['./libro.component.scss']
})
export class LibroComponent implements OnInit {

  @ViewChild('formDirective') formRef!: FormGroupDirective;

  //Boton Crear
  CreateLabel:string="Crear";

  //MODAL
  ModalTitle:string='';

  //TABLA
  tableData:any[]=[];
  tblTitle:string ="Tercero";
  displayedColumns: string[] = ['update', 'delete'];
  columns=['id', 'titulo', 'año', 'genero'];

  //FILTROS
  filteredOptions: Observable<any[]>=new Observable<any[]>();

  //ENTIDADES
  libro!: Libro

  libroform = new FormGroup({
    titulo: new FormControl('', [Validators.required]),
    anio:new FormControl('', [Validators.required]),
    genero: new FormControl('', [Validators.required]),
    numeroPaginas:new FormControl('', [Validators.required]),
    selectAutor: new FormControl(''),
    nombreAutor:new FormControl('', [Validators.required]),
    fechaNacimiento:new FormControl('' ),
    ciudadautor:new FormControl(''),
    emailautor:new FormControl('', [Validators.required]),
  });


  constructor(private _libroService: LibroService,
     private modalshared:ModalSharedService,
     private _autorService:AutorService){
      this.cleanLibro(); 
     }
  ngOnInit(): void {

    this.filteredOptions = this.libroform.controls.selectAutor.valueChanges.pipe(
      startWith(''),
      debounceTime(400),
      distinctUntilChanged(),
      switchMap((val:any) => {
            return this.filter(val || '')
      }) 
    )

    this._libroService.get().subscribe(res=>{
      if(res.exito==1){
        this.tableData=res.data;
      }
    });
  }

  private filter(valori: string): Observable<any[]> {
    var val=valori.toString();
     return this._autorService.getAll()
      .pipe(
        map((response:any) => response.data.filter((option:any) => {
          return (option.nombreCompleto).toLowerCase().indexOf(val.toLowerCase()) !== -1
        }))
      )
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

  onOptionsAutorSelected(event:any){
    this.libroform.controls.selectAutor.setValue(event.nombreCompleto);
    this.libroform.controls.nombreAutor.setValue(event.nombreCompleto);
    this.libroform.controls.emailautor.setValue(event.correoElectronico);
  }
  cleanLibro(){
    this._libroService.formData = {
      titulo:'',
      año:0,
      genero:'',
      numeroPaginas:0,
      autor:{
        nombreCompleto:'',
        fechaNacimiento:new Date,
        ciudadProcedencia:'',
        correoElectronico:''
      }
    }
  }
  cleanFormulario(){
    this.libroform.controls.titulo.setValue('');
    this.libroform.controls.anio.setValue('');
    this.libroform.controls.genero.setValue('');
    this.libroform.controls.numeroPaginas.setValue('');
    this.libroform.controls.selectAutor.setValue('');
    this.libroform.controls.nombreAutor.setValue('');
    this.libroform.controls.fechaNacimiento.setValue('');
    this.libroform.controls.ciudadautor.setValue('');
    this.libroform.controls.emailautor.setValue('');
  }

  onSave(){
    this._libroService.formData.titulo=this.libroform.controls.titulo.value;
    this._libroService.formData.año=Number(this.libroform.controls.anio.value) ;
    this._libroService.formData.genero=this.libroform.controls.genero.value;
    this._libroService.formData.numeroPaginas=Number(this.libroform.controls.numeroPaginas.value);
    this._libroService.formData.autor.nombreCompleto= this.libroform.controls.nombreAutor.value;
    this._libroService.SaveOrUpdateLibro().subscribe(res=>{
      if(res.exito===1){
        Swal.fire({
          position: 'top-end',
          icon: 'success',
          title: 'El Libro fué guradado',
          showConfirmButton: false,
          timer: 2500
        })
        this.cleanFormulario();
        this.formRef.resetForm();
      }
      else{
        Swal.fire({
          position: 'top-end',
          icon: 'error',
          title: 'El Libro no fué guardado',
          text:res.data,
          showConfirmButton: false,
          timer: 2500
        })
      }
      
    });
  }

}
