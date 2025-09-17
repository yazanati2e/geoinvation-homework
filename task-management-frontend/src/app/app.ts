import { Component, inject, signal } from '@angular/core';
import { Router, RouterOutlet } from '@angular/router';
import { AuthService } from '../common/auth-service';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  private authService: AuthService;
  private router: Router

  constructor() {
    this.authService = inject(AuthService);
    this.router = inject(Router);

    if(this.authService.isLoggedIn()) {
      
      this.router.navigate(['/']);
      return;
    }

    this.router.navigate(['/login']);
  }
}
