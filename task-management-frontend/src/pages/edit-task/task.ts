

export interface Task {
  id: number;
  title: string;
  description: string;
  status: string;
  assignedToId?: number;
  assignedToFirstName?: string;
  assignedToLastName?: string;
}


export enum TaskStatus {
  NotStarted = 1,
  InProgress = 2,
  Completed = 3,
  OnHold = 4,
  Cancelled = 5
}