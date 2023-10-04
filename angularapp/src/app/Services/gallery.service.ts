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

  createPublication(formData: FormData, publicationDetails: any): Observable<undefined> {
    return this.http.post<undefined>("/Publication", formData, { params: publicationDetails })
  }
}
