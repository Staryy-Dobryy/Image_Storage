import { HttpClient } from '@angular/common/http';
import { Component, ElementRef, HostListener, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { GalleryService } from '../../Services/gallery.service';
import { IPublication } from '../../Models/publication.model';
import { PublicationService } from '../../Services/publication.service';
import { Router } from '@angular/router';
import { IPreview } from '../../Models/preview.model';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.css']
})
export class AccountComponent implements OnInit {
  changeProfileMenuEnabled: boolean = false;

  imagePreview: string | undefined;

  updateProfileForm = new FormGroup({
    image: new FormControl<File | undefined>(undefined),
    username: new FormControl<string>(''),
  });
  constructor(private router: Router) {

  }


  ngOnInit(): void {
    
  }

  profileMenuHandler(): void {
    if (this.changeProfileMenuEnabled) {
      this.changeProfileMenuEnabled = false;
      this.updateProfileForm.reset();
      this.imagePreview = undefined;
      return;
    }

    this.changeProfileMenuEnabled = true;
  }

  getDroppedFile(file: File | any): void {
    try {
      if (file.type.includes("image")) {
        this.updateProfileForm["image"] = file;
        let reader = new FileReader()
        reader.readAsDataURL(file)
        reader.onload = (event) => this.imagePreview = event.target!.result!.toString();
        return
      }
      else if (file.target.files[0].type.includes("image")) {
        let reader = new FileReader()
        this.updateProfileForm["image"] = file.target.files[0]
        reader.readAsDataURL(this.updateProfileForm["image"])
        reader.onload = (event) => this.imagePreview = event.target!.result!.toString();
      }
    }
    catch (ex) {
      console.warn(ex)
    }
  }

  updateProfileSubmit(): void {
    // TODO
  }
}
