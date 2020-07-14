import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-invoice-list',
  templateUrl: './invoice-list.component.html',
  styleUrls: ['./invoice-list.component.css']
})
export class InvoiceListComponent implements OnInit {

  constructor() { }

  displayedColumns = ["id", "date", "personName", "totalQty", "discount", "netPrice", "cashierName", "update"]
  dataSource = [
    {id: 1, date: "11/07/2020", person: "Mohamed Alayat", qty: 5, discount: 0, netPrice: 50, cashier: "Ahmed Alayat"}
  ]

  ngOnInit(): void {
  }

}
