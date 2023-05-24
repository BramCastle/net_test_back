import { APP_BASE_HREF } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IReturn } from 'src/app/libraries/ireturn';
import { Sessions } from 'src/app/libraries/sessions';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient) { }
  
  login(login: IUserLogin): Observable<any>{ 
    return this.http.post<ISession>('http://localhost:5001' + '/api/AspNetUser/Login', login);
  }

  loggedIn(){
    return Sessions.getItem('token');
  }

  index(): Observable<any>{
    return this.http.get<IReturn>('http://localhost:5001'+'/api/menus/index');
  }
}

export interface ISession {
    id            : string,
    user          : any,
    token         : string;
    rol           : string,
    idRol         : number,
    privilegies   : any,
    menu          : any,
    expiration    : string,
    action        : boolean
}

export interface IUserLogin {
  email: string;
  password: string;
}
  
export interface ILogout {
  action          : boolean;
  title           : string;
  message         : string;
  errorCode       : string;
}
