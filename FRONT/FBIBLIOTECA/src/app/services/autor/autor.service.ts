import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Autor } from 'src/app/models/autor.model';
import { Response } from 'src/app/models/response.model';

@Injectable({
  providedIn: 'root'
})
export class AutorService {

  public formData!: Autor;

  urlGet:string;

  constructor(private http:HttpClient) {
    this.urlGet="https://localhost:44302/api/" + "Autor";
   }

   get():Observable<Response>{
    return this.http.get<Response>(this.urlGet);
   }

   getAll():Observable<Response>{
      return this.http.get<Response>(`${this.urlGet}`);
   }

   SaveOrUpdateAutor(): Observable<Response> {
    var body = {
      ...this.formData,
    }
    return this.http.post<Response>(this.urlGet, body);
  }
}
