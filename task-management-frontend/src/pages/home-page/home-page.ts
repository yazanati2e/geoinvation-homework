import { Component, inject } from '@angular/core';
import { MatCard } from "@angular/material/card";
import { MatTableModule } from '@angular/material/table';
import { DataService } from './data-service';

@Component({
  selector: 'app-home-page',
  imports: [MatTableModule],
  templateUrl: './home-page.html',
  styleUrl: './home-page.css'
})
export class HomePage {
  private dataSerivce: DataService = inject(DataService);
  usersDataSource: any[] = [];
  userdisplayedColumns = ['id', 'firstName', 'lastName'];

  tasksDataSource: any[] = [];
  tasksDisplayedColumns = ['id', 'title', 'description'];


  constructor() {
    this.dataSerivce.getUsers().subscribe((data: any[]) => {
      this.usersDataSource = data
    });

    this.dataSerivce.getTasks().subscribe((data: any[]) => {
      this.tasksDataSource = data
    });
  }
}
