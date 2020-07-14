import { PersonDto } from './../../../dtos/person-dto';
import { Component,  Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';

export interface DialogData{
  dialogTitle: string;
  person: PersonDto;
}

@Component({
  selector: 'app-person-create',
  templateUrl: './person-create.component.html',
  styleUrls: ['./person-create.component.css']
})
export class PersonCreateComponent {

  x:any;

  constructor(public dialogRef: MatDialogRef<PersonCreateComponent>,
              @Inject(MAT_DIALOG_DATA) public data: DialogData) {}

  onNoClick(){
    this.dialogRef.close();
  }

}
