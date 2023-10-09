import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ModalSharedService } from 'src/app/services/Modal/modal-shared.service';

@Component({
  selector: 'app-modal',
  templateUrl: './modal.component.html',
  styleUrls: ['./modal.component.scss']
})
export class ModalComponent implements OnInit {

  @Input() title = "";
  @Input() tableData: any[] =[];
  @Input() displayedColumns: string[]=[];
  @Output() updateRegisterEvent=new EventEmitter<any>();
  @Output() deleteRegisterEvent=new EventEmitter<any>();

  //onModal:boolean;//modal:ModalComponent;
  subscription:any;
  
  public show=false;

  constructor(private modalshared:ModalSharedService){
    
  }
  ngOnInit(): void {
    
  }
  ngOnChanges(){
    this.subscription = this.modalshared.getEmittedValue()
      .subscribe(item =>{
        this.show=item.show
        this.title=item.title
      } );
  }

  showModal(){
    
    this.show = true;
  }
  
  hideModal(){
    this.show = false;
  }

  onUpdateRegister(element:any)
  {
    this.updateRegisterEvent.emit(element);
  }
  onDeleteRegister(element:any)
  {
    this.deleteRegisterEvent.emit(element);
  }

}
