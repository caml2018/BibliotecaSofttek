import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LayoutComponent } from './components/layout/layout.component';
import { LibroComponent } from './components/pages/libro/libro.component';
import { AutorComponent } from './components/pages/autor/autor.component';
import { ConfiguracionComponent } from './components/pages/configuracion/configuracion.component';

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
        path:'libro',
        component:LibroComponent
      },
      {
        path:'autor',
        component:AutorComponent
      },
      {
        path:'configuracion',
        component:ConfiguracionComponent
      },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
