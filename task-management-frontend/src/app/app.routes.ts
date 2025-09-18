import { Routes } from '@angular/router';
import { HomePage } from '../pages/home-page/home-page';
import { LoginPage } from '../pages/login-page/login-page';
import { AuthGuard } from '../common/authGuard';
import { EditTask } from '../pages/edit-task/edit-task';

export const routes: Routes = [
      { path: 'login', component: LoginPage },
      { path: '', component: HomePage, canActivate: [AuthGuard] },
      {path: 'edit-task/:id', component: EditTask, canActivate: [AuthGuard]},
      { path: '**', redirectTo: '', pathMatch: 'full' }
];

