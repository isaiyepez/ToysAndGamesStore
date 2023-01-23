import { ResourceLoader } from '@angular/compiler';
import { Component, Input, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { Product } from 'src/app/model/product.interface';
import { DialogComponent } from 'src/app/pages/dialog/dialog.component';
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
  constructor(private productsService: ProductsService,
              private router: Router,
              private dialog: MatDialog) { }

  clicked = false;
  products: Product[] = [];
  productId: number = 0;

  displayedColumns: string[] = ['id', 'name', 'description', 'ageRestriction',
    'company', 'price', 'update', 'delete'];
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

        },
        error: (e) => console.error(e)
      });
  }

  //Buttons Events code

  createNewProduct() {
    this.router.navigate(['/productform']);
  }

  updateProduct(productId: any) {

    this.router.navigate(['/productform', { productId }]);
  }

  deleteProduct(productId: any) {
    this.openDialog(productId);

  }

  openDialog(productId: any): void {
    this.productId = productId;
    const deleteDialog = this.dialog.open(DialogComponent, {
      width: '250px',
      data: { productId: this.productId }
    });

    deleteDialog.afterClosed().subscribe(() => {
      this.fetchProducts();
    });

  }
}
