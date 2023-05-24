import { Routes, RouterModule } from '@angular/router';
import { IndexComponent } from './index/index.component';
import { LoginComponent } from './login/login.component';
import { AuthGuard } from 'src/app/auth/auth.guard';

export const globalRoutes: Routes = [
  { 
    path: '',
    redirectTo: 'login',
    pathMatch: 'full'
  },
  {
    path: 'login',
    component: LoginComponent,
  },
  {
    path: 'index',
    component: IndexComponent,
    loadChildren: () => import('./global.module').then(m => m.GlobalModule), 
    canActivate: [AuthGuard]
  },
];
