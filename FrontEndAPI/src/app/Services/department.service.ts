import { Injectable } from '@angular/core';

import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Department } from '../Interfaces/department';

@Injectable({
  providedIn: 'root'
})
export class DepartmentService {

  private endpoint:string = environment.endPoint;
  private apiUrl:string = this.endpoint + "department/";

  constructor(private http:HttpClient) { }

  getList():Observable<Department[]>{
    return this.http.get<Department[]>(`${this.apiUrl}list`);
  }
}
