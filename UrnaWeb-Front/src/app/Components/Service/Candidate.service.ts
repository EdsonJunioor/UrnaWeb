import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CanActivate } from '@angular/router';
import { Observable } from 'rxjs';
import { Candidate } from 'src/app/Models/Candidate';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CandidateService {

  baseUrl = environment.baseUrl + 'candidate';

  constructor(private http: HttpClient) { }

  getAll(): Observable<Candidate[]>{
    return this.http.get<Candidate[]>(`${this.baseUrl}`);
  }

  getCandidateById(id: number): Observable<Candidate>{
    return this.http.get<Candidate>(`${this.baseUrl}/${id}`);
  }

  getCandidateByLegenda(legenda: number): Observable<any>{
    return this.http.get<Candidate>(`${this.baseUrl}/legenda/${legenda}`);
  }

  post(candidate: Candidate){
    return this.http.post(`${this.baseUrl}`, candidate);
  }

  put(id: number, candidate: Candidate): Observable<any>{
    return this.http.put(`${this.baseUrl}/edit/${id}`, candidate);
  }

  delete(id: number): Observable<any>{
    return this.http.delete<Candidate>(`${this.baseUrl}/delete/${id}`);
  }
}
