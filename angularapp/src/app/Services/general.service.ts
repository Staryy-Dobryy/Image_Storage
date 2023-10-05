import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { IGeneral } from "../Models/general.model";
import { IPublication } from "../Models/publication.model";

@Injectable({
  providedIn: "root"
})

export class GeneralService {
  constructor(private http: HttpClient) {
  }

  getGeneral(): Observable<IGeneral> {
    return this.http.get<IGeneral>("/api/General");
  }
}
