import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { IGeneral } from "../Models/general.model";
import { IPublication } from "../Models/publication.model";
import { IPreview } from "../Models/preview.model";
import { IComment } from "../Models/comment.model";

@Injectable({
  providedIn: "root"
})

export class PublicationService {
  constructor(private http: HttpClient) {
  }

  getPublicationById(id: string): Observable<IPublication> {
    const headersDict = {
      "Authorization": "Bearer " + localStorage.getItem("jwt")
    };

    return this.http.get<IPublication>("/api/Publication", { headers: headersDict, params: { publicationId: id } })
  }

  createPublication(formData: FormData, publicationDetails: any): Observable<IPreview> {
    const headersDict = {
      "Authorization": "Bearer " + localStorage.getItem("jwt")
    };

    return this.http.post<IPreview>("/api/Publication", formData, { headers: headersDict, params: publicationDetails })
  }

  createCommentOnPublication(commentDetails): Observable<IComment> {
    const headersDict = {
      "Authorization": "Bearer " + localStorage.getItem("jwt")
    };

    return this.http.post<IComment>("/api/Comment", commentDetails, { headers: headersDict })
  }
}
