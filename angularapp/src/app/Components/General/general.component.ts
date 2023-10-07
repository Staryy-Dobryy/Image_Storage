import { HttpClient } from '@angular/common/http';
import { Component, ElementRef, HostListener, OnInit, ViewChild } from '@angular/core';
import { GeneralService } from '../../Services/general.service';
import { IGeneral } from '../../Models/general.model';
import { IPublication } from '../../Models/publication.model';
import { PublicationService } from '../../Services/publication.service';
import { Router } from '@angular/router';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-general',
  templateUrl: './general.component.html',
  styleUrls: ['./general.component.css']
})
export class GeneralComponent implements OnInit {

  general: IGeneral;
  publication: IPublication | undefined;
  publicationId: string;

  authorized: boolean = false;
  createCommentForm = new FormGroup({
    text: new FormControl<string>(''),
  });

  constructor(private generalService: GeneralService, private publicationService: PublicationService, private router: Router) { }

  ngOnInit(): void {
    this.generalService.getGeneral().subscribe(general => {
      this.general = general;
    })

    if (localStorage.getItem("jwt")) {
      this.authorized = true
    }
  }

  getPublication(publicationId: string): void {
    this.publicationId = publicationId;
    this.publicationService.getPublicationById(publicationId).subscribe(publication => {
      this.publication = publication
    },
      error => {
        console.error(error)
      })
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
