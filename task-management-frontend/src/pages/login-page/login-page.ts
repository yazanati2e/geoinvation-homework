import { Component, inject } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatInputModule } from '@angular/material/input';
import { BrowserModule } from '@angular/platform-browser';
import { AuthService } from '../../common/auth-service';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { tap } from 'rxjs';

@Component({
  selector: 'app-login-page',
  imports: [MatCardModule, MatInputModule, MatButtonModule, CommonModule, ReactiveFormsModule],
  templateUrl: './login-page.html',
  styleUrl: './login-page.css'
})
export class LoginPage {
  private authService: AuthService = inject(AuthService);
  private router = inject(Router);

  loginForm = new FormGroup({
    userName: new FormControl('YAZAN.ATI@GENOVATION.AI', Validators.required),
    password: new FormControl('P@ssword1', Validators.required),
  });

  error: string | null = null;

  onSubmit() {
    if (this.loginForm.valid) {
      const { userName, password } = this.loginForm.value;

      this.authService.login(userName!, password!).pipe(
      tap((response: any) => {
        if (response && response.token) {
          localStorage.setItem('jwt_token', response.token);

        }
      })
    ).subscribe(resp => {
        if ((this.authService.isLoggedIn())) {
          this.router.navigate(['/']);
        } else {
          this.error = 'Invalid username or password.';
        }
      });

      

   

    } else {
      this.error = 'Please fill in all required fields.';
    }
  }

}
