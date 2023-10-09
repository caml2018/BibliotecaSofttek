import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LayoutComponent } from './components/layout/layout.component';
import { AutorComponent } from './components/pages/autor/autor.component';
import { LibroComponent } from './components/pages/libro/libro.component';

const routes: Routes = [{
  path:'',
    component:LayoutComponent,
    children:[
      {
        path:'',
        redirectTo:"/libro",
        pathMatch:'full'
      },
      {
        path:'autor',
        component:AutorComponent
      },
      {
        path:'libro',
        component:LibroComponent
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
