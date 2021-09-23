import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CandidateComponent } from './Components/Candidate/Candidate.component';
import { MenuComponent } from './Components/Menu/Menu.component';
import { VoteComponent } from './Components/Vote/Vote.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { VoteService } from './Components/Service/Vote.service';
import { CandidateService } from './Components/Service/Candidate.service';
import { DashBoardComponent } from './Components/DashBoard/DashBoard.component';

@NgModule({
  declarations: [
    AppComponent,
    VoteComponent,
    CandidateComponent,
    MenuComponent,
    DashBoardComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule
  ],
  providers: [HttpClientModule, VoteService, CandidateService],
  bootstrap: [AppComponent]
})
export class AppModule { }
