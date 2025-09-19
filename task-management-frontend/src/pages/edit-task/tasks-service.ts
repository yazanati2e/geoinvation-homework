import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Constants } from '../../common/contants';
import { Environment } from '../../environments/environment';
import { Task } from './task';

@Injectable({
  providedIn: 'root'
})
export class TasksService {

  private http: HttpClient;

  constructor() {
    this.http = inject(HttpClient);
  }


  getTaskById(id: number) {
    return this.http.get<Task>(`${Environment.apiUrl}/${Constants.GetTaskByIdUrl}/${id}`);
  }
}