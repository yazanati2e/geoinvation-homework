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
    displayedColumns = ['id', 'firstName', 'lastName'];


  constructor() {
    this.dataSerivce.getUsers().subscribe((data: any[]) => {
      this.usersDataSource = data
    });
  }
}
