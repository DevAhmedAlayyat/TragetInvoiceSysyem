import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Component, OnInit, Inject } from '@angular/core';
import { UnitInputDto } from '../../../dtos/unit/unit-input-dto';

export interface DialogData{
  dialogTitle: string;
  unitInputDto: UnitInputDto;
}

@Component({
  selector: 'app-unit-create',
  templateUrl: './unit-create.component.html',
  styleUrls: ['./unit-create.component.css']
})
export class UnitCreateComponent implements OnInit {

  constructor(public dialogRef:MatDialogRef<UnitCreateComponent>,
              @Inject(MAT_DIALOG_DATA) public data: DialogData) {}

  ngOnInit(): void {
  }

  onNoClick(){
    this.dialogRef.close();
  }

}
