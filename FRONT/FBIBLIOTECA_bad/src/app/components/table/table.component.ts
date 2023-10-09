import { Component, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.scss']
})
export class TableComponent implements OnInit {
  ngOnInit(): void {
    throw new Error('Method not implemented.');
  }

  @Input() title = "";
  @Input() tableData: any[] =[];
  @Input() displayedColumns: any[]=[];
  @Input() columns:any[]=[]
  @Output() updateEvent = new EventEmitter<any>();
  @Output() deleteEvent = new EventEmitter<any>();

  displayedColumnsadd: any[]=[];
  
  dataSource!: MatTableDataSource<any>;

  @ViewChild('scheduledOrdersPaginator') set paginator(pager:MatPaginator) {
    if (pager) this.dataSource.paginator = pager;
  }
  @ViewChild(MatSort) set sort(sorter:MatSort) {
    if (sorter) this.dataSource.sort = sorter;
  }

  ngOnChanges(){
    this.dataSource = new MatTableDataSource(this.tableData);
    this.displayedColumnsadd=[];
    this.displayedColumnsadd= this.displayedColumnsadd.concat(this.columns,this.displayedColumns);
  }
  
  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  update(element:any)
  {
    console.log("Actualizar");
  }
  
  onDelete(element:any)
  {
    this.deleteEvent.emit(element);
  }

  onUpdate(element:any) {
    this.updateEvent.emit(element);
  }

}
