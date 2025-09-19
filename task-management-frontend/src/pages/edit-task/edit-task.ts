import { Component, inject } from '@angular/core';
import { TasksService } from './tasks-service';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { DataService } from '../home-page/data-service';
import { Task } from './task';
import { MatFormFieldModule } from '@angular/material/form-field';
import { CommonModule } from '@angular/common';
import { MatInputModule } from '@angular/material/input';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-edit-task',
  imports: [MatSnackBarModule, MatFormFieldModule, MatInputModule, CommonModule, ReactiveFormsModule],
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

  constructor() {
    this.tasksService = inject(TasksService);
    this.dataService = inject(DataService);
    this.snackBar = inject(MatSnackBar);
    this.activatedRoute = inject(ActivatedRoute);
    this.taskId = Number(this.activatedRoute.snapshot.paramMap.get('id'));

    this.taskFrm = new FormGroup({
      title: new FormControl(null, Validators.required),
      description: new FormControl(null, Validators.maxLength(5000)),
      assignedToId: new FormControl(null),
    });

    this.fetchTaskDetails(this.taskId);
  }


  fetchTaskDetails(id: number) {
    this.tasksService.getTaskById(id).subscribe({
      next: (task: Task) => {
        this.taskFrm.setValue({ title: task.title, description: task.description, assignedToId: task.assignedToId });
      },
      error: (error) => {
        this.snackBar.open(`Error fetching the task: ${error.message}`, 'Close', { duration: 3000 });
      }
    });
  }

  onSubmit(): void {
  }
}
