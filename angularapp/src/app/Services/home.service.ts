import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { FormGroup } from "@angular/forms";

@Injectable({
  providedIn: "root"
})

export class HomeService {
  constructor(private http: HttpClient) {
  }

  sendRegistrationForm(registrationForm: FormGroup): Observable<string> {

    const registationParams = {
      Name: registrationForm.get("userName")!.value,
      Email: registrationForm.get("email")!.value,
      Password: registrationForm.get("password")!.value
    };

    return this.http.post<string>("/api/Registration", registationParams);
  }

  sendLoginForm(loginForm: FormGroup): Observable<string> {
    const loginParams = {
      email: loginForm.get("email")!.value,
      password: loginForm.get("password")!.value
    };

    return this.http.post<string>("/api/Login", loginParams);
  }

  sendGoogleAuthInfo(authParams: any) {
    return this.http.post<string>("/api/GoogleAuth", authParams);
  }
}
