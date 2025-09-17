import { HttpInterceptorFn } from '@angular/common/http';

export const authInterceptor: HttpInterceptorFn = (req, next) => {
    const authToken = localStorage.getItem('jwt_token');

    if (authToken) {

        req = req.clone({
            setHeaders: {
                Authorization: `Bearer ${authToken}`
            }
        });
    }

    return next(req);
};