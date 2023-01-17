import {Component, Input, OnInit} from '@angular/core';
import { Product } from 'src/app/model/product.interface';
import { ProductsService } from 'src/app/services/products.service';

/**
 * @title Products table
 */

@Component({
  selector: 'app-productstable',
  templateUrl: './productstable.component.html',
  styleUrls: ['./productstable.component.css']
})
export class ProductstableComponent implements OnInit {

  /**
   *
   */
  constructor(private productsService: ProductsService) { }

  clicked = false;
  products: Product[] = [];

  displayedColumns: string[] = ['id', 'name', 'description', 'ageRestriction',
    'company', 'price', 'update', 'delete' ];
  dataSource = this.products;


  ngOnInit(): void {

     this.fetchProducts();

  }

  fetchProducts(): void {
    this.productsService
    .getAllProducts()
    .subscribe({
      next: (data) => {
         this.dataSource = data;
        console.log(data);
      },
      error: (e) => console.error(e)
    });
  }

}
