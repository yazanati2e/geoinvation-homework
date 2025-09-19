import { Component, inject } from '@angular/core';
import { TasksService } from './tasks-service';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { DataService } from '../home-page/data-service';
import { Task, TaskStatus } from './task';
import { MatFormFieldModule } from '@angular/material/form-field';
import { CommonModule, Location } from '@angular/common';
import { MatInputModule } from '@angular/material/input';
import { ActivatedRoute } from '@angular/router';
import { MatSelectModule } from '@angular/material/select';
import { MatOptionModule } from '@angular/material/core';
import { AuthService } from '../../common/auth-service';

@Component({
  selector: 'app-edit-task',
  imports: [MatSnackBarModule, MatFormFieldModule, MatInputModule,
            CommonModule, ReactiveFormsModule, MatSelectModule, MatOptionModule],
  templateUrl: './edit-task.html',
  styleUrl: './edit-task.css'
})
export class EditTask {
  private tasksService: TasksService;
  private dataService: DataService
  private snackBar: MatSnackBar;
  private activatedRoute: ActivatedRoute
  taskFrm: FormGroup;
  private taskId: number;
  private currentLocation: Location;
  public allTaskStatuses = TaskStatus;
  public selectedOption: TaskStatus | null = null;
  public authService: AuthService;
  public allUsers: any[] = [];

  constructor() {
    this.tasksService = inject(TasksService);
    this.dataService = inject(DataService);
    this.snackBar = inject(MatSnackBar);
    this.activatedRoute = inject(ActivatedRoute);
    this.authService = inject(AuthService);
    this.taskId = Number(this.activatedRoute.snapshot.paramMap.get('id'));
    this.currentLocation = inject(Location);

    this.taskFrm = new FormGroup({
      title: new FormControl(null, Validators.required),
      description: new FormControl(null, Validators.maxLength(5000)),
      status: new FormControl(null, Validators.required),
      assignedTo: new FormControl(null, Validators.required)
    });

    this.fetchTaskDetails(this.taskId);

    this.fetchAllUsers();
  }


  fetchTaskDetails(id: number) {
    this.tasksService.getTaskById(id).subscribe({
      next: (task: Task) => {
        this.taskFrm.setValue({ title: task.title, description: task.description, status: task.status, assignedTo: task.assignedToId });
      },
      error: (error) => {
        this.snackBar.open(`Error fetching the task: ${error.message}`, 'Close', { duration: 3000 });
      }
    });
  }

  fetchAllUsers() {


    if(!this.authService.isAdminUser()){
      this.allUsers = [{id: this.authService.getCurrentUserId(), name: this.authService.getUserName()}];
    }
    this.dataService.getUsers().subscribe({
      next: (users) => {
        for (let user of users) {
          this.allUsers.push({id: user.id, name: `${user.firstName} ${user.lastName}`});
        }
      },
      error: (error) => {
        this.snackBar.open(`Error fetching users: ${error.message}`, 'Close', { duration: 3000 });
      }
    });
  }

  get TaskStatusValues(): string[] {
    return Object.keys(this.allTaskStatuses).filter(key => isNaN(Number(key)));
  }

  getTaskStatusEnum(value: string): TaskStatus | null {
    return (TaskStatus as any)[value] ?? null;
  }

  onSubmit(): void {
  }

  onCacnel(): void {
    this.currentLocation.back();
  }
}
