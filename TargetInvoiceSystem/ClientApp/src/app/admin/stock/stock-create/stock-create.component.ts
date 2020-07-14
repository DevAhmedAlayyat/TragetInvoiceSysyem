import { StockDto } from './../../../dtos/stock-dto';
import { Component, OnInit, Inject } from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';

export interface DialogData{
  dialogTitle: string;
  stock: StockDto;
}

@Component({
  selector: 'app-stock-create',
  templateUrl: './stock-create.component.html',
  styleUrls: ['./stock-create.component.css']
})
export class StockCreateComponent {

  constructor(public dialogRef: MatDialogRef<StockCreateComponent>,
              @Inject(MAT_DIALOG_DATA) public data: DialogData) {}

  onNoClick(){
    this.dialogRef.close();
  }

}
