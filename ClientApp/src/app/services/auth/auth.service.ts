import { APP_BASE_HREF } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Sessions } from 'src/app/libraries/sessions';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient, @Inject(APP_BASE_HREF) private baseUrl: string) { }
  
  login(login: IUserLogin): Observable<any>{ 
    return this.http.post<ISession>('http://localhost:5001' + '/api/AspNetUser/Login', login);
  }

  refeshToken(): Observable<any> {
    return this.http.post<any>(this.baseUrl + "api/AspNetUser/Refresh", { token : Sessions.getItem('token')} , Sessions.header());
  }

  logout( ) : Observable<ILogout> {
    return this.http.post<ILogout>("api/AspNetUser/Logout", {
      headers: {
        "Authorization"   : "Bearer " + Sessions.getItem("token")
      }
    });
  }
  loggedIn(){
    return Sessions.getItem('token');
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
