import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Environment } from '../../environments/environment';
import { Constants } from '../../common/contants';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  http: HttpClient = inject(HttpClient);

  getUsers() {
    return this.http.get<any[]>(`${Environment.apiUrl}/${Constants.GetAllUsersUrl}`);
  }

  
  
}
