import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { IPreview } from "../Models/preview.model";
import { IUser } from "../Models/user.model";

@Injectable({
  providedIn: "root"
})

export class AccountService {
  constructor(private http: HttpClient) {
  }

  getUserAccountById(id: string | undefined = undefined): Observable<IUser> {
    const headersDict = {
      "Authorization": "Bearer " + localStorage.getItem("jwt")
    };

    if (id) {
      const profileParams = {
        userId: id
      };

      return this.http.get<IUser>("/api/Profile", { headers: headersDict, params: profileParams });
    }

    return this.http.get<IUser>("/api/Profile", { headers: headersDict });
  }

  updateUserAccount(formData: FormData, updateDetails: any): Observable<IUser> {
    const headersDict = {
      "Authorization": "Bearer " + localStorage.getItem("jwt")
    };

    return this.http.put<IUser>("/api/Profile", formData, { headers: headersDict, params: updateDetails });
  }
}
