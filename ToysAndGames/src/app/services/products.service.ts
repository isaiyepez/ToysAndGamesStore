import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, retry, throwError } from 'rxjs';
import { Product } from '../model/product.interface';

const WEBSERVICE_API = "https://localhost:7010/api/products/";

@Injectable({
  providedIn: 'root'
})
export class ProductsService {
  products: Product[] = [];


  constructor(private http: HttpClient) { }

  httpHeader = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }

  getAllProducts(): Observable<Product[]> {
    let url = WEBSERVICE_API + 'getproducts';
    return this.http.get<Product[]>(url);
  }

  getProduct(productId: number): Observable<Product> {
    let url = WEBSERVICE_API + 'getproduct/' + productId;
    return this.http.get<Product>(url)
    .pipe(
      retry(1),
      catchError(this.httpError)
    );
  }

  postProduct(product: any): Observable<any> {
    let url = WEBSERVICE_API + 'addproduct';
    console.log('Product for POST:   ' + JSON.stringify(product));
    return this.http.post(url, JSON.stringify(product), this.httpHeader)
    .pipe(
      retry(1),
      catchError(this.httpError)
    );
  }

  updateProduct(product: any): Observable<any> {
    let url = WEBSERVICE_API + 'updateproduct';
    return this.http.patch(url, JSON.stringify(product), this.httpHeader)
    .pipe(
      retry(1),
      catchError(this.httpError)
    );
  }

  deleteProduct(productId: number) {

    let url = WEBSERVICE_API + 'deleteproduct/' + productId;
    return this.http.delete(url)
    .pipe(
      retry(1),
      catchError(this.httpError)
    )
  }

  httpError(error: any) {
    let msg = '';
    if(error.error instanceof ErrorEvent) {
      // client side error
      msg = error.error.message;
    } else {
      // server side error
      msg = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    console.log(msg);
    return throwError(() => new Error(msg));
  }


}
