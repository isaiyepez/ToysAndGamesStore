import { Component, Input } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-productform',
  templateUrl: './productform.component.html',
  styleUrls: ['./productform.component.css']
})
export class ProductformComponent {

  @Input()
  id?: number = 1000;
  preview: string = '';

  productForm = this.fb.group({
    id: [''],
    name: ['', Validators.required],
    description: [''],
    ageRestriction: [''],
    company: ['', Validators.required],
    price: [null, Validators.required],
  });


  constructor(private fb: FormBuilder) {
    this.productForm.controls['id'].disable();

  }


  onSubmit(): void {


    if(this.id){
      this.updateProduct();
    } else{
      this.addProduct();
    }
  }

  addProduct() {
    this.preview = JSON.stringify(this.productForm.value);
    console.log(this.preview);
  }

  updateProduct() {
    this.preview = JSON.stringify(this.productForm.value);
    console.log(this.preview);
  }

}
