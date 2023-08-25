import { Injectable } from '@angular/core';
import { Moneda } from '../models/moneda';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';


@Injectable({
  providedIn: 'root'
})
export class MonedaService {
  myAppUrl: string;
  myApiUrl: string;
  myApiUrl2: string | any;

  constructor(private http: HttpClient) {
    this.myAppUrl = environment.endpoint;
    this.myApiUrl = '/api/Moneda/';
  }

  saveMoneda(moneda: Moneda): Observable<any>{
    return this.http.post(this.myAppUrl + this.myApiUrl2, moneda);
  }

  getListMonedas(): Observable<any>{
    return this.http.get(this.myAppUrl + this.myApiUrl + 'GetListMonedas');
  }

  getMoneda(idMoneda: number): Observable<any>{
    return this.http.get(this.myAppUrl + this.myApiUrl + idMoneda);
  }
}
