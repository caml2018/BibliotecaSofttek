import { EventEmitter, Injectable, Output } from '@angular/core';
import { ModalConfig } from 'src/app/models/modal-config.model';

@Injectable({
  providedIn: 'root'
})
export class ModalSharedService {

  @Output() fire: EventEmitter<any> = new EventEmitter();

  modalconfig!:ModalConfig

  constructor()
  {
    this.initModalCongit();
  }

  initModalCongit(){
    this.modalconfig={
      show:false,
      title:''
    }
  }

  change(title:string) {
    this.modalconfig.show=true;
    this.modalconfig.title=title;
    this.fire.emit(this.modalconfig);
   }

   getEmittedValue() {
     return this.fire;
   }
}
