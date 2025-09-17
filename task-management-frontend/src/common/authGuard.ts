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

        return this.authService.isLoggedIn().pipe(
          take(1), 
          map(isLoggedIn => {
            if (isLoggedIn) {
              return true;
            } else {
              return this.router.createUrlTree(['/login']);
            }
          })
        );
      }
    }