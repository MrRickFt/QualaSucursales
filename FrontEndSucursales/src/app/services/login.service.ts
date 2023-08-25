import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { Usuario } from '../models/usuario';
import { JwtHelperService } from "@auth0/angular-jwt";

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  myAppUrl: string;
  myApiUrl: string;

  constructor(private http: HttpClient) {
    this.myAppUrl = environment.endpoint;
    this.myApiUrl = '/api/Login';
  }

  login(usuario: Usuario): Observable<any>{
    return this.http.post(this.myAppUrl + this.myApiUrl, usuario);
  }

  setLocalStorage(data: string | any): void {
    localStorage.setItem('token', data);
  }

  removeLocalStorge(): void {
    localStorage.removeItem('token');
  }

  getTokenDecoded(): any {
    const token = localStorage.getItem('token');
    if (token) {
      const helper = new JwtHelperService();
      const decodeToken = helper.decodeToken(token);
      return decodeToken;
    } else {
      // Manejar el caso en que no hay token en el LocalStorage (opcional)
      return null;
    }
  }

  getToken(): string {
    return localStorage.getItem('token') || "";
  }
  

  /*
  hasRole(rol: string): boolean {
    let roles: string[]
    if(this.getTokenDecoded().sid=="ADMINISTRADOR"){
      roles =["ADMINISTRADOR"];
      return roles.indexOf(rol) >= 0;
    }else if(this.getTokenDecoded().sid=="EMPLEADO"){
        roles = ["EMPLEADO"];
        return roles.indexOf(rol) >= 0;
    }else{
      return false;
    }
  }*/


}
