import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
@Injectable({
  providedIn: 'root'
})
export class ApiBaseService {

  constructor() { }

  getbaseURL() : string{
   return environment.baseUrl;
  }
}
