import { Component, inject } from '@angular/core';
import { TasksService } from './tasks-service';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';
import { Form, FormControl, FormGroup, Validators } from '@angular/forms';
import { DataService } from '../home-page/data-service';

@Component({
  selector: 'app-edit-task',
  imports: [MatSnackBarModule],
  templateUrl: './edit-task.html',
  styleUrl: './edit-task.css'
})
export class EditTask {
  tasksService: TasksService;
  dataService: DataService
  private snackBar: MatSnackBar;
  taskFrm: FormGroup;

  constructor() {
    this.tasksService = inject(TasksService);
    this.dataService = inject(DataService);
    this.snackBar = inject(MatSnackBar);

    this.taskFrm = new FormGroup({
          title: new FormControl(null, Validators.required),
          description: new FormControl(null, Validators.maxLength(5000)),
          assignedToId: new FormControl(null),

    });
  }


  fetchTaskDetails(id: number) {
    this.tasksService.getTaskById(id).subscribe({
      next: (task) => {
        console.log('Task details:', task);
      },
      error: (error) => {
        this.snackBar.open(`Error fetching the task: ${error.message}`, 'Close', { duration: 3000 });
      }
    });
  }

}
