import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { Environment } from '../environments/environment';
import { Constants } from './contants';
import { LoginModel } from './models/loginModel';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private loggedIn = new BehaviorSubject<boolean>(false);
  private http: HttpClient;

  constructor() {
    this.http = inject(HttpClient);

    const token = localStorage.getItem('authToken');
    if (token) {
      this.loggedIn.next(true);
    }
  }

  login(username: string, password: string) {

    this.http.post<LoginModel>(`${Environment.apiUrl}/${Constants.AuthUrl}`, { username, password })
      .subscribe(response => {
        if (response && response.token) {
              localStorage.setItem('authToken', response.token);
              this.loggedIn.next(true);
        }
      });


  }

  logout() {
    localStorage.removeItem('authToken');
    this.loggedIn.next(false);
  }

  isLoggedIn(): Observable<boolean> {
    return this.loggedIn.asObservable();
  }
  
}
