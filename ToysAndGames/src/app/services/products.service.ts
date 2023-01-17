import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Product } from '../model/product.interface';

const WEBSERVICE_API = "https://localhost:7010/api/products/";

@Injectable({
  providedIn: 'root'
})
export class ProductsService {
  products: Product[] = [];


  constructor(private http: HttpClient) { }

  getAllProducts(): Observable<Product[]> {
    let url = WEBSERVICE_API + 'getproducts';
    return this.http.get<Product[]>(url);
  }

  
}
