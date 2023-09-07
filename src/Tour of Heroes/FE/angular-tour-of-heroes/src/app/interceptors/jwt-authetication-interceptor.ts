import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { AuthService } from "../services/auth/auth.service";
import { environment } from "../environment";




@Injectable()
export class JwtAtuthenticationInterceptor implements HttpInterceptor{

    constructor(private authService: AuthService){}


    intercept(
        req: HttpRequest<any>, 
        next: HttpHandler
        ): Observable<HttpEvent<any>> {
            const authToken = this.authService.getAuthorizationToken();
        const loginValidation = this.authService.isUserAuthenticated();
        
        if(loginValidation)
        {
            req = req.clone({
                setHeaders:{Authorizaton: `Bearer${authToken}`}
            });
        }
        return next.handle(req);

    }
}