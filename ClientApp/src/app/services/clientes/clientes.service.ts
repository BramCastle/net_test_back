import { HttpClient } from '@angular/common/http';
import { Injectable ,Inject } from '@angular/core';
import { Server } from '../../libraries/server';
import { IReturn } from '../../libraries/ireturn';
import { APP_BASE_HREF } from '@angular/common';

@Injectable({
  providedIn: 'root'
})

export class ClientesService {

  constructor(private httpClient : HttpClient, @Inject(APP_BASE_HREF) private urlBase : string){
    this.urlBase = Server.ip();
  }

  index(dataSource: any){
    return this.httpClient.post<IReturn>(this.urlBase+"api/clientes/index", dataSource);
  }
}
