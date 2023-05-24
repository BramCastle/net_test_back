import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { ClientesService } from 'src/app/services/clientes/clientes.service';
// import { FormComponent } from '../form/form.component';

const ELEMENT_DATA: any[] = [
  {position: 1, name: 'Hydrogen', weight: 1.0079, symbol: 'H'},
  {position: 2, name: 'Helium', weight: 4.0026, symbol: 'He'},
  {position: 3, name: 'Lithium', weight: 6.941, symbol: 'Li'},
  {position: 4, name: 'Beryllium', weight: 9.0122, symbol: 'Be'},
  {position: 5, name: 'Boron', weight: 10.811, symbol: 'B'},
  {position: 6, name: 'Carbon', weight: 12.0107, symbol: 'C'},
  {position: 7, name: 'Nitrogen', weight: 14.0067, symbol: 'N'},
  {position: 8, name: 'Oxygen', weight: 15.9994, symbol: 'O'},
  {position: 9, name: 'Fluorine', weight: 18.9984, symbol: 'F'},
  {position: 10, name: 'Neon', weight: 20.1797, symbol: 'Ne'},
];

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.scss']
})

export class IndexComponent implements OnInit {

  displayedColumns: string[] = ['item', 'codigo', 'descripcion', 'stock', 'fecha', 'fechaUpdate'];
  dataSource = new MatTableDataSource<any>([]);

  textSearch = "";
  
  constructor(private _clientesService : ClientesService,
              public dialog: MatDialog
             )
  { }
  
  ngOnInit() {
    this.dataSource.data = ELEMENT_DATA;
    // this.index();
  }

  key_enterSearch(){
    this.index();
  }

  index(){
    let params = {
      search: this.textSearch,
      searchFilters: [{ field: 'Codigo'}, { field: 'Descripcion'}],
      filters: [],
      filtersMultiple: [],
      dateFrom: '',
      dateTo: '',
      dateOptions: [
          {
              field: 'CreatedFecha'
          }
      ],
      columns: [],
      persistenceColumns: [],
      length: 100,
      page: 1
  }

    this._clientesService.index(params).subscribe(res => {
      this.dataSource.data = res.result.rows;
    })
  }

}
