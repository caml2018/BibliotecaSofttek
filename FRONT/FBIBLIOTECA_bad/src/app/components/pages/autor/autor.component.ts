import { Component, OnInit } from '@angular/core';
import { ModalSharedService } from 'src/app/services/Modal/modal-shared.service';
import { AutorService } from 'src/app/services/autor/autor.service';

@Component({
  selector: 'app-autor',
  templateUrl: './autor.component.html',
  styleUrls: ['./autor.component.scss']
})
export class AutorComponent implements OnInit {

  //TABLA  
  tableData:any[]=[];
  tblTitle:string ="Tercero";
  displayedColumns: string[] = ['update', 'delete'];
  columns=['noIdentificacion', 'nombresTercero', 'apellidosTercero', 'emailTercero'];
  //MODAL
  ModalTitle:string=''

  constructor(private _autorService: AutorService, private modalshared:ModalSharedService,)
  {
debugger;
  }

  ngOnInit(): void {
    debugger;
    this._autorService.getAll(1).subscribe(res=>{
      if(res.exito==1){
        this.tableData=res.data;
      }
    });
  }

  onCreateRegister(){
    this.modalshared.change('Crear Tercer');
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

  onUpdateRegisterEvent(event:any){}
  onDeleteRegisterEvent(event:any){}

}
