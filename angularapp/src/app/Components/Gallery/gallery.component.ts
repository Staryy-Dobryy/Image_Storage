import { HttpClient } from '@angular/common/http';
import { Component, ElementRef, HostListener, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { GalleryService } from '../../Services/gallery.service';
import { IPublication } from '../../Models/publication.model';
import { PublicationService } from '../../Services/publication.service';
import { Router } from '@angular/router';
import { IPreview } from '../../Models/preview.model';

@Component({
  selector: 'app-gallery',
  templateUrl: './gallery.component.html',
  styleUrls: ['./gallery.component.css']
})
export class GalleryComponent implements OnInit {
  publication: IPublication | undefined;
  publicationId: string;

  gallery: IPreview[] = []
  imagePreview: string | undefined;

  uploadPublicationForm = new FormGroup({
    image: new FormControl<File | undefined>(undefined),
    description: new FormControl<string>(''),
    isPublic: new FormControl<boolean>(false)
  });

  authorized: boolean = false;
  createCommentForm = new FormGroup({
    text: new FormControl<string>(''),
  });

  constructor(private galleryService: GalleryService, private publicationService: PublicationService, private router: Router) {

  }



  ngOnInit(): void {
    if (localStorage.getItem("jwt")) {
      this.authorized = true
    }

    this.galleryService.getGallery().subscribe(gallery => {
      this.gallery = gallery;
    },
      error => {
      console.error("Gallery fail", error)

      if (error.status == 401) {
        localStorage.removeItem("jwt")
        this.router.navigate(['/']);
      }
    });
  }

  uploadPublicationSubmit(): void {

    const publicationImage = this.uploadPublicationForm["image"]

    const publicationDetails = {
      description: this.uploadPublicationForm.get("description")!.value!,
      isPublic: this.uploadPublicationForm.get("isPublic")!.value!
    }

    let formData = new FormData();
    formData.append('image', publicationImage, publicationImage.name);


    this.publicationService.createPublication(formData, publicationDetails).subscribe(preview => {


      console.log(this.gallery)

      this.gallery.push(preview);

      console.log(this.gallery)
    },
      error => {
        console.error("Publication failed", error)

        if (error.status == 401) {
          localStorage.removeItem("jwt")
          this.router.navigate(['/']);
        }
      });

    this.uploadPublicationForm.reset();
    this.uploadPublicationForm["isPublic"] = false
    this.imagePreview = undefined;
  }

  getDroppedFile(file: File | any): void {
    try {
      if (file.type.includes("image")) {
        this.uploadPublicationForm["image"] = file;
        let reader = new FileReader()
        console.log(this.uploadPublicationForm["image"])
        reader.readAsDataURL(file)
        reader.onload = (event) => this.imagePreview = event.target!.result!.toString();
        return
      }
      else if (file.target.files[0].type.includes("image")) {
        let reader = new FileReader()
        this.uploadPublicationForm["image"] = file.target.files[0]
        reader.readAsDataURL(this.uploadPublicationForm["image"])
        reader.onload = (event) => this.imagePreview = event.target!.result!.toString();
      }
    }
    catch (ex) {
      console.warn(ex)
    }
  }

  getPublication(id: string): void {
    this.publicationService.getPublicationById(id).subscribe(publication => {
      this.publication = publication;
    });
  }

  showUserProfile(userId: string): void {
    this.router.navigate(["/account"], { queryParams: { "accountId": userId } })
  }

  createComment(): void {
    const commentDetails = {
      text: this.createCommentForm.get("text")!.value!,
      publicationId: this.publicationId
    }

    this.publicationService.createCommentOnPublication(commentDetails).subscribe(comment => {
      this.publication?.comments.push(comment)
    });

    this.createCommentForm.reset();
  }
}
