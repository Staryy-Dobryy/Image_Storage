import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { IPreview } from "../Models/preview.model";

@Injectable({
  providedIn: "root"
})

export class GalleryService {
  constructor(private http: HttpClient) {
  }

  getGallery(id: string | undefined = undefined): Observable<IPreview[]> {
    const headersDict = {
      "Authorization": "Bearer " + localStorage.getItem("jwt")
    };

    if (id) {
      const profileParams = {
        userId: id
      };

      return this.http.get<IPreview[]>("/api/Gallery", { headers: headersDict, params: profileParams });
    }

    return this.http.get<IPreview[]>("/api/Gallery", { headers: headersDict });
  }
}
