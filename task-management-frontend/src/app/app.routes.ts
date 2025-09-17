import { Routes } from '@angular/router';
import { HomePage } from '../pages/home-page/home-page';
import { LoginPage } from '../pages/login-page/login-page';
import { AuthGuard } from '../common/authGuard';

export const routes: Routes = [
      { path: 'login', component: LoginPage },
      { path: 'home', component: HomePage, canActivate: [AuthGuard] },
      { path: '', redirectTo: '/home', pathMatch: 'full' }
];

