import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule, Routes } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { HomeComponent } from './Components/Home/home.component';
import { InViewAnimationDirective } from './Directives/elemInVievAnim.directive';
import { NotFoundComponent } from './Components/NotFound/not-found.component';
import { GeneralComponent } from './Components/General/general.component';

const appRoutes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'general', component: GeneralComponent },
  { path: '**', component: NotFoundComponent }
];

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    GeneralComponent,
    NotFoundComponent,
    InViewAnimationDirective
  ],
  imports: [BrowserModule, HttpClientModule, RouterModule.forRoot(appRoutes), FormsModule, ReactiveFormsModule],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
