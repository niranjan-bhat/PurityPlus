import { Injectable } from '@angular/core';
import axios from 'axios';
import { ApiBaseService } from './api-base.service';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  private axiosInstance = axios.create({
    baseURL: this.apiBaseSerice.getbaseURL(), // Use the ConfigService for the base URL
  });
  constructor(private apiBaseSerice: ApiBaseService) { }

  getAllProducts() {
   return this.axiosInstance.get('Product/GetAll');
  }

  getProductById(Id:string) {
    return this.axiosInstance.get(`Product/GetById?ProductId=${Id}`);
   }
}
