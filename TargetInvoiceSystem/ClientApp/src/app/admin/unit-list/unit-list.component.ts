import { MainUnitDto } from './../../dtos/unit/main-unit-dto';
import { UnitCreateComponent } from './unit-create/unit-create.component';
import { MatDialog } from '@angular/material/dialog';
import { UnitInputDto } from './../../dtos/unit/unit-input-dto';
import { Component, OnInit } from '@angular/core';
import { SubUnitDto } from 'src/app/dtos/unit/sub-unit-dto';

@Component({
  selector: 'app-unit-list',
  templateUrl: './unit-list.component.html',
  styleUrls: ['./unit-list.component.css']
})
export class UnitListComponent implements OnInit {

  constructor(public dialog:MatDialog) { }  
  
  unitInputDto: UnitInputDto = {
    mainUnitDto: new MainUnitDto(),
    subUnitDto: new SubUnitDto()
  };

  displayColumns = ["id", "mainUnit", "subUnit", "update"];
  dataSource = [
    {id: "1", mainUnit: "Carton", subUnit: "Box"},
    {id: "1", mainUnit: "Carton", subUnit: "Box"},
    {id: "1", mainUnit: "Carton", subUnit: "Box"},
    {id: "1", mainUnit: "Carton", subUnit: "Box"}
  ];

  ngOnInit(): void {
  }

  createUnit(dialogTitle){
      const dialog = this.dialog.open(UnitCreateComponent, {
        width: '300px',
        data: {dialogTitle: dialogTitle, unitInputDto: this.unitInputDto}
      });

      dialog.afterClosed().subscribe(result => {
        console.log(result);
      })
  }

  onEdit(id, dialogtitle){
    this.createUnit(dialogtitle);
  }

  onDelete(id){
    console.log(id);
  }

}
