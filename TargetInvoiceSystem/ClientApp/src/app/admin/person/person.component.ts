import { PersonDto } from './../../dtos/person-dto';
import { PersonCreateComponent } from './person-create/person-create.component';
import { MatDialog } from '@angular/material/dialog';
import { StockService } from '../../services/stock.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-person',
  templateUrl: './person.component.html',
  styleUrls: ['./person.component.css']
})
export class PersonComponent implements OnInit {

  constructor(public stockService: StockService,
              public dialog: MatDialog) { }

  person: PersonDto = new PersonDto();
  

  // dataSource: any[];

  ngOnInit(): void {
    this.getStocks();
  }
  
  displayedColumns: string[] = ['id', 'name', 'phone', 'mob', 'isCustomer', 'balance', "update"];
  dataSource = [
    {
      id: 1,
      fullName: "Ahmed Alayat",
      phone1: "0552970221",
      phone2: "01096228541",
      isCustomer: true,
      balance: 0      
    }
  ]

  getStocks(){    
    this.stockService.getStocks().subscribe(resutl =>{
        // this.dataSource = this.stockService.stocks;
      },
      err=> {
        console.error(err);
      }    
    )
  }  

  CreateStock(dialogTitle){
    const dialogRef = this.dialog.open(PersonCreateComponent, {
          width:'500px',
          data: {dialogTitle: dialogTitle, person: this.person}                
        }
      );

    dialogRef.afterClosed().subscribe(result => {
      console.log(result);
    });
  }

  onEdit(id, dialogTitle){
    this.CreateStock(dialogTitle);
  }
  
  onDelete(id){
    console.log(id);
  }

}
