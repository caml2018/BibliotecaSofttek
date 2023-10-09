import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CantidaLibrosModel } from 'src/app/models/cantidadelibros.model';
import { Libro } from 'src/app/models/libro.model';
import { Response } from 'src/app/models/response.model';

@Injectable({
  providedIn: 'root'
})
export class LibroService {

  public formData!: Libro;
  public formDataConfiguracion!:CantidaLibrosModel;

  urlServicio:string;

  urlGet:string;
  urlCantidadLibros:string;
  urlsaveCantidadLibros:string;

  constructor(private http:HttpClient) {
    this.urlServicio="https://localhost:44302/api/"
    this.urlGet=this.urlServicio + "Libro";
    this.urlCantidadLibros=this.urlServicio+"Libro/GetAllmaximoDeLibros";
    this.urlsaveCantidadLibros=this.urlServicio+"Libro/maximoDeLibros";
   }

   get():Observable<Response>{
    return this.http.get<Response>(this.urlGet);
   }

   getCantidadMaximaLibros(){
    return this.http.get<Response>(this.urlCantidadLibros);
   }

   saveCantidadMaximaLibros(){
    return this.http.post<Response>(this.urlsaveCantidadLibros, this.formDataConfiguracion);
   }

   SaveOrUpdateLibro(): Observable<Response> {
    var body = {
      ...this.formData,
    }
    return this.http.post<Response>(this.urlGet, body);
  }
}
