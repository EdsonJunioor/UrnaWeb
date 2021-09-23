import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Candidate } from 'src/app/Models/Candidate';
import { CandidateService } from '../Service/Candidate.service';

@Component({
  selector: 'app-Candidate',
  templateUrl: './Candidate.component.html',
  styleUrls: ['./Candidate.component.css']
})
export class CandidateComponent implements OnInit {

  public candidateForm!: FormGroup;

  public candidate: Candidate[] = [];
  public candidatoModel = new Candidate;

  constructor(private candidateService: CandidateService, private fb: FormBuilder) { 
  }

  ngOnInit() {
    this.carregarCandidatos();
  }

  candidateSelect(candidate: Candidate){
    this.candidatoModel = candidate;
  }

  carregarCandidatos(){
    this.candidateService.getAll().subscribe(
      (candidate: Candidate[]) => {
        this.candidate = candidate;
        return this.candidate;
      },
      (erro: any) => {
        console.error('Não foi possivel carregar os candidatos.')
      }
    );
  }

  salvarCandidato(){
    this.candidateService.post(this.candidatoModel).subscribe(resposta => {
      this.candidatoModel = new Candidate;
      this.carregarCandidatos();
    });
  }

  editarCandidato(){
    var id = this.candidatoModel.candidateId;
    this.candidateService.put(id, this.candidatoModel).subscribe(resposta => {
      this.carregarCandidatos();
    });
    this.limparCampo();
  }

  deletarCandidato(){
    var id = this.candidatoModel.candidateId;
    this.candidateService.delete(id).subscribe(resposta => {
        this.limparCampo();
        this.carregarCandidatos();
    });
  }
  
  limparCampo(){
    this.candidatoModel = new Candidate;
  }
}
