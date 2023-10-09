import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AutorModel } from 'src/app/models/autor.model';
import { Response } from 'src/app/models/response.model';

@Injectable({
  providedIn: 'root'
})
export class AutorService {

  public formData!: AutorModel;

  urlGet:string;
  //urlAdd:string;

  constructor(private http:HttpClient) {
    debugger;
    this.urlGet="https://localhost:44302/api/" + "Autor";
    //this.urlAdd="https://localhost:44326/api/" + "Customer";
   }

   get():Observable<Response>{
    return this.http.get<Response>(this.urlGet);
   }

   getAll(companyId:number):Observable<Response>{
      return this.http.get<Response>(`${this.urlGet}=${companyId}`);
   }

   SaveOrUpdateCustomer(): Observable<Response> {
    var body = {
      ...this.formData,
    }
    return this.http.post<Response>(this.urlGet, body);
  }
}
