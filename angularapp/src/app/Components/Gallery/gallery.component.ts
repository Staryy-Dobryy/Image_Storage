import { HttpClient } from '@angular/common/http';
import { Component, ElementRef, HostListener, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { IGallery } from '../../Models/gallery.model';
import { GalleryService } from '../../Services/gallery.service';
import { IPublication } from '../../Models/publication.model';

@Component({
  selector: 'app-gallery',
  templateUrl: './gallery.component.html',
  styleUrls: ['./gallery.component.css']
})
export class GalleryComponent implements OnInit {
  publication: IPublication | undefined;
  gallery: IGallery
  imagePreview: string;

  uploadPublicationForm = new FormGroup({
    image: new FormControl<File | undefined>(undefined),
    description: new FormControl<string>(''),
    isPublic: new FormControl<boolean>(false)
  });


  constructor(private formBuilder: FormBuilder, private galleryService: GalleryService) {

  }



  ngOnInit(): void {
    this.galleryService.getGeneral().subscribe(gallery => {
      this.gallery = gallery;
    })
  }

  uploadPublicationSubmit(): void {
    const publicationImage = this.uploadPublicationForm["image"]

    const publicationDetails = {
      description: this.uploadPublicationForm.get("description")!.value!,
      isPublic: this.uploadPublicationForm.get("isPublic")!.value!
    }

    let formData = new FormData();
    formData.append('image', publicationImage, publicationImage.name);


    this.galleryService.createPublication(formData, publicationDetails).subscribe(() => {

    },
      error => {
        console.error("Publication failed", error)
      });
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
}
