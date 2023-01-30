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
  imageSrc: any;
  imageContent: string = '';

  productForm = this.fb.group({
    Id: [''],
    Name: ['', Validators.required],
    Description: [''],
    AgeRestriction: [''],
    Company: ['', Validators.required],
    Price: [0.0, Validators.required],
    ProductImageId: [0],
    ImageFile: ['', Validators.required],
    ImageName: ['', Validators.required]
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

          },
          error: (e) => console.error(e)
        });

    }
  }

  setFormValues() {
    this.productForm.patchValue({
      Id: this.productId?.toString(),
      Name: this.product!['name'],
      Description: this.product!['description'],
      AgeRestriction: this.product!['ageRestriction'] ? this.product!['ageRestriction']!.toString() : null,
      Company: this.product!['company'],
      Price: this.product!['price']!,
      ProductImageId: this.product?.productImageId,
      ImageFile: this.product!['imageFile'],
      ImageName: this.product!['imageName']

    });


  }

  onSubmit(): void {

    if(this.productForm.valid){

      if(this.productId){
        this.updateProduct();
      } else{
        this.addProduct();
      }
    }
  }

  onImageSelected(event: any){
    if(event.target.files && event.target.files.length) {

      const reader = new FileReader();

      const [file] = event!.target.files;
      reader.readAsDataURL(file);

      reader.onload = () => {
        this.productForm.patchValue({
          ImageFile: reader.result as string,
          ImageName: file.name
        });
        this.imageSrc = file;
        this.imageContent = reader.result as string;
      }

    }

  }

  addProduct() {

    this.productForm.controls['Id'].disable();

      let response = this.productsService.postProduct(this.productForm.value)
    .subscribe(res => {
      console.log('Post successful');
      this.gotoList();
    });

  }

  updateProduct() {

   let response = this.productsService.updateProduct(this.productForm.value)
   .subscribe(res => {
    console.log('Patch successful');
    this.gotoList();
   });
  }

  gotoList() {
    this.router.navigate(['/home']);
  }

}
