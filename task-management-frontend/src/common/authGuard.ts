    import { Injectable } from '@angular/core';
    import { CanActivate, Router, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree } from '@angular/router';
    import { Observable, map, take } from 'rxjs';
import { AuthService } from './auth-service';

    @Injectable({
      providedIn: 'root'
    })
    export class AuthGuard implements CanActivate {
      constructor(private authService: AuthService, private router: Router) {}

      canActivate(
        route: ActivatedRouteSnapshot,
        state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {

            if(this.authService.isLoggedIn()) {
                return true;
            }

            return this.router.navigate(['/login']);

      }
    }