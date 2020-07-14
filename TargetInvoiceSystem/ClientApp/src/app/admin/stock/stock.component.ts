import { StockCreateComponent } from './stock-create/stock-create.component';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { StockDto } from './../../dtos/stock-dto';
import { StockService } from './../../services/stock.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-stock',
  templateUrl: './stock.component.html',
  styleUrls: ['./stock.component.css']
})
export class StockComponent implements OnInit {

  constructor(public stockService: StockService,
              public dialog: MatDialog) { }

  stock: StockDto = new StockDto();

  // dataSource: any[];

  ngOnInit(): void {
    this.getStocks();
  }
  
  displayedColumns: string[] = ['id', 'name', 'balance', "update"];
  dataSource = [
    {
      id: 1,
      name: "Home",
      balance: 0      
    }
  ]

  getStocks(){    
    this.stockService.getStocks().subscribe(resutl =>{
        this.stockService.stocks = resutl as StockDto[];
        // this.dataSource = this.stockService.stocks;
      },
      err=> {
        console.error(err);
      }    
    )
  }  

  CreateStock(dialogTitle){
    const dialogRef = this.dialog.open(StockCreateComponent, {
          width:'300px',
          data: {dialogTitle: dialogTitle, stock: this.stock}                
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
