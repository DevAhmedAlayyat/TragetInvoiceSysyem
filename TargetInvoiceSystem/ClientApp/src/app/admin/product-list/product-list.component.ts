import { UnitInputDto } from './../../dtos/unit/unit-input-dto';
import { ProductDto } from './../../dtos/product/product-dto';
import { ProductInputDto } from './../../dtos/product/product-input-dto';
import { ProductCreateComponent } from './product-create/product-create.component';
import { MatDialog } from '@angular/material/dialog';
import { Component, OnInit } from '@angular/core';
import { MainUnitDto } from 'src/app/dtos/unit/main-unit-dto';
import { SubUnitDto } from 'src/app/dtos/unit/sub-unit-dto';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {

  constructor(public dialog:MatDialog) { }  
  
  productInputDto: ProductInputDto = {
    productDto: new ProductDto(),
    buyPrice: 0,
    sellPrice: 0,
    unitDtoId: null
  };
  unitInputDto: UnitInputDto = {
    mainUnitDto: new MainUnitDto(),
    subUnitDto: new SubUnitDto()
  };

  displayColumns = ["id", "name", "description", "mainUnit", "subUnit", "stock", "sellPrice", "buyPrice", "balance", "update"];
  dataSource = [
    {id: "1",name:"Shipsy", description:"Shipsy Asly",  mainUnit: "Carton", subUnit: "Box", stock:"Main", sellPrice:5, buyPrice:4.5, balance: 500},
    {id: "2",name:"Shipsy", description:"Shipsy Asly",  mainUnit: "Carton", subUnit: "Box", stock:"Main", sellPrice:5, buyPrice:4.5, balance: 500},
    {id: "3",name:"Shipsy", description:"Shipsy Asly",  mainUnit: "Carton", subUnit: "Box", stock:"Main", sellPrice:5, buyPrice:4.5, balance: 500},
    {id: "4",name:"Shipsy", description:"Shipsy Asly",  mainUnit: "Carton", subUnit: "Box", stock:"Main", sellPrice:5, buyPrice:4.5, balance: 500},
    {id: "5",name:"Shipsy", description:"Shipsy Asly",  mainUnit: "Carton", subUnit: "Box", stock:"Main", sellPrice:5, buyPrice:4.5, balance: 500}
  ];

  ngOnInit(): void {
  }

  createUnit(dialogTitle){
      const dialog = this.dialog.open(ProductCreateComponent, {
        width: '600px',
        data: {dialogTitle: dialogTitle, productInput: this.productInputDto, 
               unitInputDto: this.unitInputDto}
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
