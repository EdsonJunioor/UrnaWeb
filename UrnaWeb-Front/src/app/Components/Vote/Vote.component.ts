import { Component, OnInit } from '@angular/core';
import { Candidate } from 'src/app/Models/Candidate';
import { Vote } from 'src/app/Models/Vote';
import { CandidateService } from '../Service/Candidate.service';
import { VoteService } from '../Service/Vote.service';

@Component({
  selector: 'app-Vote',
  templateUrl: './Vote.component.html',
  styleUrls: ['./Vote.component.css']
})
export class VoteComponent implements OnInit {

  public vote: Vote = new Vote;
  public candidatoModel = new Candidate;
  public candidate: Candidate[] = [];

  constructor(private voteService: VoteService, private candidateService: CandidateService) { }

  ngOnInit() {
  }

  buscarCandidato(){
    var legenda = this.vote.legenda;
    this.candidateService.getCandidateByLegenda(legenda).subscribe(
      (resposta: Candidate) => {
        this.candidatoModel = resposta;
        return this.candidatoModel;
      },
      () => {}
    );
  }

  votar(){
    if(this.vote.legenda){
      this.salvarVoto();
      this.limparCampo();
    }
    else{
      this.vote.legenda = 0;
      this.salvarVoto();
      this.limparCampo();
    }
  }

  salvarVoto(){
    this.voteService.post(this.vote).subscribe( vote => {
      this.vote = new Vote;
    },
      err => {
        console.log('Erro ao realizar voto', err);
        this.limparCampo();
      }
    );
  }

  limparCampo(){
    this.vote = new Vote;
  }
}
