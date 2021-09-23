import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Vote } from 'src/app/Models/Vote';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class VoteService {

  baseUrl = environment.baseUrl + 'vote';
  
  constructor(private http: HttpClient) { }

  getAll(): Observable<any>{
    return this.http.get(`${this.baseUrl}/total-votes`);
  }

  post(voto: Vote): Observable<any>{
    return this.http.post(`${this.baseUrl}`, voto);
  }


}
