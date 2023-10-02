import { HttpClient } from '@angular/common/http';
import { Component, ElementRef, HostListener, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-gallery',
  templateUrl: './gallery.component.html',
  styleUrls: ['./gallery.component.css']
})
export class GalleryComponent implements OnInit {
  image: File;
  imagePreview: string;

  uploadPublicationForm = new FormGroup({
    image: new FormControl<File | undefined>(undefined),
    description: new FormControl<string>(''),
    isPublic: new FormControl<boolean>(false)
  });


  constructor(private client: HttpClient, private formBuilder: FormBuilder) {

  }



  ngOnInit(): void {

  }

  selectFile(event): void {
    const file = event.target.files[0];
    this.uploadPublicationForm.get("image")?.setValue(file)
  }

  uploadPublicationSubmit(): void {
    console.log(this.uploadPublicationForm);

    var publicationImage = this.uploadPublicationForm.get("image")!.value!
    const publicationDetails = {
      description: this.uploadPublicationForm.get("description")!.value!,
      isPublic: this.uploadPublicationForm.get("isPublic")!.value!
    }

    let formData = new FormData();
    formData.append('image', publicationImage, publicationImage.name);


    this.client.post("https://localhost:7161/Publication", formData, { params: publicationDetails }).subscribe();
  }

  getDroppedFile(file: File | any): void {
    try {
      if (file.type.includes("image")) {
        this.image = file;
        let reader = new FileReader()
        console.log(this.image)
        reader.readAsDataURL(file)
        reader.onload = (event) => this.imagePreview = event.target!.result!.toString();
        return
      }
      else if (file.target.files[0].type.includes("image")) {
        let reader = new FileReader()
        this.image = file.target.files[0]
        reader.readAsDataURL(this.image)
        reader.onload = (event) => this.imagePreview = event.target!.result!.toString();
      }
    }
    catch (ex) {
      console.warn(ex)
    }
  }
}
