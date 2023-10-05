import { HttpClient } from '@angular/common/http';
import { Component, ElementRef, HostListener, OnInit, ViewChild } from '@angular/core';
import { GeneralService } from '../../Services/general.service';
import { IGeneral } from '../../Models/general.model';
import { IPublication } from '../../Models/publication.model';
import { PublicationService } from '../../Services/publication.service';

@Component({
  selector: 'app-general',
  templateUrl: './general.component.html',
  styleUrls: ['./general.component.css']
})
export class GeneralComponent implements OnInit {

  general: IGeneral;
  publication: IPublication | undefined;

  constructor(private generalService: GeneralService, private publicationService: PublicationService) { }

  ngOnInit(): void {
    this.generalService.getGeneral().subscribe(general => {
      this.general = general;
    })
  }

  getPublication(publicationId: string): void {
    this.publicationService.getPublicationById(publicationId).subscribe(publication => {
      this.publication = publication
    },
      error => {
        console.error(error)
      })
  }

}
