// import { Injectable } from "@angular/core";
// import { HttpInterceptor, HttpRequest, HttpHandler } from "@angular/common/http";

// @Injectable()

// export class AuthInterceptor implements HttpInterceptor {
//     constructor() { }

//     intercept(req: HttpRequest<any>, next: HttpHandler) {
//         const authToken = localStorage.getItem('token')
//         req = req.clone({
//             setHeaders: {
//                 Authorization: "Bearer " + authToken
//             }
//         });
//         return next.handle(req);
//     }
// }

