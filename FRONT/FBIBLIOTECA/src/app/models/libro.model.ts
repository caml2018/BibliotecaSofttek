import { Autor } from "./autor.model";

export interface Libro {
    titulo: string|null;
    año: number;
    genero:string|null;
    numeroPaginas:number;
    autor:Autor
  }