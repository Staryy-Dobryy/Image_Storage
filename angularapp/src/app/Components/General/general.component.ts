import { HttpClient } from '@angular/common/http';
import { Component, ElementRef, HostListener, OnInit, ViewChild } from '@angular/core';
import { GeneralService } from '../../Services/general.service';
import { IGeneral } from '../../Models/general.model';
import { IPublication } from '../../Models/publication.model';

@Component({
  selector: 'app-general',
  templateUrl: './general.component.html',
  styleUrls: ['./general.component.css']
})
export class GeneralComponent implements OnInit {

  general: IGeneral;
  publication: IPublication | undefined;

  constructor(private generalSirvice: GeneralService) { }

  ngOnInit(): void {
    this.generalSirvice.getGeneral().subscribe(general => {
      this.general = general;
    })
  }

}
