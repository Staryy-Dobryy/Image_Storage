import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { IGeneral } from "../Models/general.model";

@Injectable({
  providedIn: "root"
})

export class GeneralService {
  constructor(private http: HttpClient) {
  }

  getGeneral(): Observable<IGeneral> {
    return this.http.get<IGeneral>("/general");
  }
}
