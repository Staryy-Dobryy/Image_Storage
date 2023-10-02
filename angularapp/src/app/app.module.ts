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
import { GalleryComponent } from './Components/Gallery/gallery.component';
import { NavigationComponent } from './Components/Navigation/navigation.component';
import { DragDirective } from './Directives/dragDropFile.directive';

const appRoutes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'general', component: GeneralComponent },
  { path: 'gallery', component: GalleryComponent },
  { path: '**', component: NotFoundComponent }
];

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    GeneralComponent,
    GalleryComponent,
    NotFoundComponent,
    InViewAnimationDirective,
    NavigationComponent,
    DragDirective
  ],
  imports: [BrowserModule, HttpClientModule, RouterModule.forRoot(appRoutes), FormsModule, ReactiveFormsModule],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
