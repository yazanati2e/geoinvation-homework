

export interface Task {
  id: number;
  title: string;
  description: string;
  status: string;
  assignedToId?: number;
  assignedToFirstName?: string;
  assignedToLastName?: string;
}