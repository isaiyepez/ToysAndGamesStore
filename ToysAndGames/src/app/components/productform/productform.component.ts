import { Component, Input } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Product } from 'src/app/model/product.interface';
import { ProductsService } from 'src/app/services/products.service';

@Component({
  selector: 'app-productform',
  templateUrl: './productform.component.html',
  styleUrls: ['./productform.component.css']
})
export class ProductformComponent {

  @Input()
  product?: Product;
  productId?: number;

  productForm = this.fb.group({
    Id: [''],
    Name: ['', Validators.required],
    Description: [''],
    AgeRestriction: [''],
    Company: ['', Validators.required],
    Price: [0.0, Validators.required],
  });


  constructor(
    private fb: FormBuilder,
    private productsService: ProductsService,
    private router: Router,
    private activatedRouter: ActivatedRoute,
    ) {

    this.productId = Number(this.activatedRouter.snapshot.paramMap.get('productId'));

    if(this.productId){

      this.productsService.getProduct(this.productId)
        .subscribe({
          next: (data) => {
            this.product = data;
            console.log(data);

            if(this.product){
              this.setFormValues();
            }
            //this.productForm.patchValue(this.product);
          },
          error: (e) => console.error(e)
        });
        // (data: any) => {
        //   this.product = data;
        //   //
        // }

    }
  }

  setFormValues() {
    this.productForm.patchValue({
      Id: this.productId?.toString(),
      Name: this.product!['name'],
      Description: this.product!['description'],
      AgeRestriction: this.product!['ageRestriction'] ? this.product!['ageRestriction']!.toString() : null,
      Company: this.product!['company'],
      Price: this.product!['price']!
    });


  }

  onSubmit(): void {
    if(this.productForm.valid){

      if(this.productId){
        this.updateProduct();
      } else{
        this.addProduct();
      }

      this.gotoList();
    }
  }

  addProduct() {

    // this.productsService.postProduct(this.productForm.value).subscribe(
    //   (res: any) => {
    //     console.log('Post successful');

    //   });
    this.productForm.controls['Id'].disable();

      let response = this.productsService.postProduct(this.productForm.value)
    .subscribe(res => {
      console.log('Post successful');
    });

  }

  updateProduct() {
   let response = this.productsService.updateProduct(this.productForm.value)
   .subscribe(res => {
    console.log('Patch successful');
   });
  }

  gotoList() {
    this.router.navigate(['/home']);
  }

}
