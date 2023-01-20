import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from "@angular/material/dialog";
import { ProductsService } from 'src/app/services/products.service';

@Component({
  selector: 'app-dialog',
  templateUrl: './dialog.component.html',
  styleUrls: ['./dialog.component.css']
})
export class DialogComponent {

  productId: number;

  constructor(private productsService: ProductsService,
    public dialogRef: MatDialogRef<DialogComponent>,
    @Inject(MAT_DIALOG_DATA) private data: { productId: number }) {

    this.productId = data.productId;

  }
  onDeleteClick(): void {

    let response = this.productsService.deleteProduct(this.productId)
    .subscribe(res => {

      this.dialogRef.close();

    });

  }



}
