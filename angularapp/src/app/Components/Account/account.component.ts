import { HttpClient } from '@angular/common/http';
import { Component, ElementRef, HostListener, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { GalleryService } from '../../Services/gallery.service';
import { IPublication } from '../../Models/publication.model';
import { PublicationService } from '../../Services/publication.service';
import { ActivatedRoute, Router } from '@angular/router';
import { IPreview } from '../../Models/preview.model';
import { AccountService } from '../../Services/account.service';
import { IUser } from '../../Models/user.model';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.css']
})
export class AccountComponent implements OnInit {
  publication: IPublication | undefined;
  publicationId: string;

  changeProfileMenuEnabled: boolean = false;

  imagePreview: string | undefined;

  updateProfileForm = new FormGroup({
    image: new FormControl<File | undefined>(undefined),
    username: new FormControl<string>(''),
  });

  user: IUser | undefined

  accountId: string | undefined
  gallery: IPreview[] = []

  authorized: boolean = false;
  createCommentForm = new FormGroup({
    text: new FormControl<string>(''),
  });

  constructor(private router: Router, private route: ActivatedRoute, private accountService: AccountService, private galleryService: GalleryService, private publicationService: PublicationService) {
    route.queryParams.subscribe(
      (queryParam: any) => {
        this.accountId = queryParam['accountId'];
      }
    );
  }


  ngOnInit(): void {
    if (localStorage.getItem("jwt")) {
      this.authorized = true
    }

    this.accountService.getUserAccountById(this.accountId).subscribe(user => {
      this.user = user
    });

    this.galleryService.getGallery(this.accountId).subscribe(gallery => {
      this.gallery = gallery
    });
  }

  logout(): void {
    localStorage.removeItem("jwt");
    this.router.navigate(['/']);
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

  getPublication(id: string): void {
    this.publicationService.getPublicationById(id).subscribe(publication => {
      this.publication = publication;
    });
  }

  updateProfileSubmit(): void {
    let formData = new FormData();
    formData.append('image', this.updateProfileForm["image"], this.updateProfileForm["image"].name);

    const publicationDetails = {
      newName: this.updateProfileForm.get("username")!.value!,
    }

    this.accountService.updateUserAccount(formData, publicationDetails).subscribe(newUserProfile => {
      this.user = newUserProfile;
      this.changeProfileMenuEnabled = false;
    });

    this.updateProfileForm.reset();
    this.imagePreview = undefined;
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
