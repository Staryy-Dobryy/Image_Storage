import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { IGallery } from "../Models/gallery.model";

@Injectable({
  providedIn: "root"
})

export class GalleryService {
  constructor(private http: HttpClient) {
  }

  getGeneral(): Observable<IGallery> {
    return this.http.get<IGallery>("/gallery");
  }
}
