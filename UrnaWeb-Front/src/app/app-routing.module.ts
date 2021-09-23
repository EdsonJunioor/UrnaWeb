import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CandidateComponent } from './Components/Candidate/Candidate.component';
import { DashBoardComponent } from './Components/DashBoard/DashBoard.component';
import { VoteComponent } from './Components/Vote/Vote.component';

const routes: Routes = [
  { path: 'dashboard', component: DashBoardComponent},
  { path: 'candidate', component: CandidateComponent},
  { path: 'vote', component: VoteComponent},
  { path: '', redirectTo: 'vote', pathMatch:'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
