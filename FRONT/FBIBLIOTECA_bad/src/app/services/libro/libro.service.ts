import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { LibroModel } from 'src/app/models/libro.model';

@Injectable({
  providedIn: 'root'
})
export class LibroService {

  public formData!: LibroModel;

  urlGet:string;
  //urlAdd:string;

  constructor(private http:HttpClient) {
    https://localhost:44302/api/Autor
    this.urlGet="https://localhost:44302/api/" + "Autor";
    //this.urlAdd="https://localhost:44302/api/" + "A";
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
