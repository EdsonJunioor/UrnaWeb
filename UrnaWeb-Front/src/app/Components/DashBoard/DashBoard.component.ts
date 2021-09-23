import { Component, OnInit } from '@angular/core';
import { Dashboard } from 'src/app/Models/Dashboard';
import { Vote } from 'src/app/Models/Vote';
import { VoteService } from '../Service/Vote.service';

@Component({
  selector: 'app-DashBoard',
  templateUrl: './DashBoard.component.html',
  styleUrls: ['./DashBoard.component.css']
})
export class DashBoardComponent implements OnInit {

  public totalVotos: Dashboard[] = [];
  
  constructor(private voteService: VoteService) { }

  ngOnInit() {
    this.apurarVotos();
  }

  apurarVotos(){
    this.voteService.getAll().subscribe(
      (votos: Dashboard[]) => {
        this.totalVotos = votos;
        return this.totalVotos;
      }
    );
  }

}