import { StockDto } from './../dtos/stock-dto';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';


@Injectable({
  providedIn: 'root'
})
export class StockService {

  constructor(private http:HttpClient) { }
  
  stocks:StockDto[];
  apiUrl: string = "http://localhost:57974/api/stock";
  headers: HttpHeaders = new HttpHeaders().set("Authontication", "Bearer " + localStorage.getItem('token'));
  
  getStocks(){
    return this.http.get(this.apiUrl, {headers:this.headers});
  }
}
