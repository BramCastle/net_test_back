import { HttpClient } from '@angular/common/http';
import { Injectable ,Inject } from '@angular/core';
import { Server } from '../../libraries/server';
import { IReturn } from '../../libraries/ireturn';
import { APP_BASE_HREF } from '@angular/common';

@Injectable({
  providedIn: 'root'
})

export class ClientesService {

  constructor(private httpClient : HttpClient){
  }

  index(dataSource: any){
    return this.httpClient.post<IReturn>('http://localhost:5001'+"api/clientes/index", dataSource);
  }
}
