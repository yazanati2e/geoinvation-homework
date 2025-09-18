import { Component, inject } from '@angular/core';
import { MatCard } from "@angular/material/card";
import { MatTableModule } from '@angular/material/table';
import { DataService } from './data-service';
import { MatIconModule } from '@angular/material/icon';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';
import { AuthService } from '../../common/auth-service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home-page',
  imports: [MatTableModule, MatIconModule, MatSnackBarModule],
  templateUrl: './home-page.html',
  styleUrl: './home-page.css'
})
export class HomePage {
  private snackBar: MatSnackBar;
  private dataSerivce: DataService;
  private router: Router;
  authService: AuthService;
  usersDataSource: any[] = [];
  userdisplayedColumns = ['id', 'firstName', 'lastName', 'actions'];

  tasksDataSource: any[] = [];
  tasksDisplayedColumns = ['id', 'title', 'description', 'actions'];


  constructor() {
    this.snackBar = inject(MatSnackBar);
    this.dataSerivce = inject(DataService);
    this.authService = inject(AuthService);
    this.router = inject(Router);

    this.loadUsers();
    this.loadTasks();
  }

  private loadUsers(): void {
    this.dataSerivce.getUsers().subscribe((data: any[]) => {
      this.usersDataSource = data
    });
  }

  private loadTasks(): void {
    this.dataSerivce.getTasks().subscribe((data: any[]) => {
      this.tasksDataSource = data
    });
  }


  deleteUser(id: number): void {
    this.dataSerivce.deleteUser(id).subscribe({
      next: () => {
        this.snackBar.open('User deleted successfully', 'Close', { duration: 3000 });
        this.loadUsers();
      },
      error: (err) => {
        this.snackBar.open(`Error deleting user: ${err.message}`, 'Close', { duration: 3000 });
      }
    });
  }

  deleteTask(id: number): void {
    this.dataSerivce.deleteTask(id).subscribe({
      next: () => {
        this.snackBar.open('Task deleted successfully', 'Close', { duration: 3000 });
        this.loadTasks();
      },
      error: (err) => {
        this.snackBar.open(`Error deleting task: ${err.message}`, 'Close', { duration: 3000 });
      }
    });
  }

  editTask(id: number): void {
    this.router.navigate([`/edit-task/${id}`]);
  }

  signout(): void {
    this.authService.logout();
  }
}
