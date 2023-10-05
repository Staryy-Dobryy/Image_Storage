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
      userName: registrationForm.get("userName")!.value,
      email: registrationForm.get("email")!.value,
      password: registrationForm.get("password")!.value
    };

    return this.http.post<string>("/Registration", {}, { params: registationParams });
  }

  sendLoginForm(loginForm: FormGroup): Observable<string> {
    const loginParams = {
      email: loginForm.get("email")!.value,
      password: loginForm.get("password")!.value
    };

    return this.http.post<string>("/Login", {}, { params: loginParams });
  }

  sendGoogleAuthInfo(authParams: any) {
    return this.http.post<string>("/GoogleAuth", {}, { params: authParams });
  }
}
