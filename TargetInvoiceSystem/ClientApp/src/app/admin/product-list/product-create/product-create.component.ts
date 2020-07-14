import { UnitInputDto } from '../../../dtos/unit/unit-input-dto';
import { ProductDto } from './../../../dtos/product/product-dto';
import { ProductInputDto } from './../../../dtos/product/product-input-dto';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Component, OnInit, Inject } from '@angular/core';

export interface DialogData{
  dialogTitle: string;
  productInput: ProductInputDto;
  unitInputDto: UnitInputDto;
}

@Component({
  selector: 'app-product-create',
  templateUrl: './product-create.component.html',
  styleUrls: ['./product-create.component.css']
})
export class ProductCreateComponent implements OnInit {

  constructor(public dialogRef:MatDialogRef<ProductCreateComponent>,
              @Inject(MAT_DIALOG_DATA) public data: DialogData) {}

  ngOnInit(): void {
  }

  onNoClick(){
    this.dialogRef.close();
  }

}
