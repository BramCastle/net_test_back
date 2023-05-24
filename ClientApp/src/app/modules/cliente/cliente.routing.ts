import { Routes, RouterModule } from '@angular/router';
import { IndexComponent } from './index/index.component';

export const clientesRoutes: Routes = [
  { 
    path: 'cliente/index',
    component: IndexComponent,
    loadChildren: () => import('./cliente.module').then(m => m.ClienteModule)
  },
];