import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, tap } from 'rxjs';
import { Environment } from '../environments/environment';
import { Constants } from './contants';
import { jwtDecode }  from 'jwt-decode';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private isAuthenticatedSubject = new BehaviorSubject<boolean>(this.hasToken());
  public isAuthenticated$ = this.isAuthenticatedSubject.asObservable();

  constructor(private http: HttpClient, private router: Router) { }

  login(username: string, password: string): Observable<any> {
    return this.http.post(`${Environment.apiUrl}/${Constants.AuthUrl}`, { username, password });
  }

  logout(): void {
    localStorage.removeItem('jwt_token');
    this.isAuthenticatedSubject.next(false);
    this.router.navigate(['/login']);
  }

  getToken(): string | null {
    return localStorage.getItem('jwt_token');
  }

  getCurrentUserId(): number | null {
    if (this.hasToken()) {
      const decodedToken: any = jwtDecode(localStorage.getItem('jwt_token')!);
      const userId = decodedToken.sub; // Or other claim containing the user ID
      return +userId;
    }

    return null;
  }

  isAdminUser(): boolean {
    if (this.hasToken()) {
      const decodedToken: any = jwtDecode(localStorage.getItem('jwt_token')!);
      const role: string = decodedToken['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'];
      return role === 'Admin';
    }

    return false;
  }

  isLoggedIn(): boolean {
    return this.hasToken();
  }

  getUserName(): string {
    if (this.hasToken()) {
      const decodedToken: any = jwtDecode(localStorage.getItem('jwt_token')!);
      const name = decodedToken['http://schemas.microsoft.com/ws/2008/06/identity/claims/name'];
      return name;
    } 

    return '';
  }

  private hasToken(): boolean {
    return !!localStorage.getItem('jwt_token');
  }
}