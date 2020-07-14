import { PersonCreateComponent } from './admin/person/person-create/person-create.component';
import { PersonComponent } from './admin/person/person.component';
import { ProductCreateComponent } from './admin/product-list/product-create/product-create.component';
import { ProductListComponent } from './admin/product-list/product-list.component';
import { MaterialModule } from './material/material.module';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http'

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { NavbarComponent } from './navbar/navbar.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { FooterComponent } from './footer/footer.component';
import { FontAwesomeModule } from "@fortawesome/angular-fontawesome";
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { FormsModule } from '@angular/forms';
import { AdminComponent } from './admin/admin.component';
import { AccessDeniedComponent } from './access-denied/access-denied.component';
import { StockComponent } from './admin/stock/stock.component';
import { StockCreateComponent } from './admin/stock/stock-create/stock-create.component';
import { UnitListComponent } from './admin/unit-list/unit-list.component';
import { UnitCreateComponent } from './admin/unit-list/unit-create/unit-create.component';
import { InvoiceListComponent } from './invoice-list/invoice-list.component';
import { InvoiceCreateComponent } from './invoice-list/invoice-create/invoice-create.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NavbarComponent,
    LoginComponent,
    RegisterComponent,
    FooterComponent,
    AdminComponent,
    AccessDeniedComponent,
    StockComponent,
    StockCreateComponent,
    UnitListComponent,
    UnitCreateComponent,
    ProductListComponent,
    ProductCreateComponent,
    PersonComponent,
    PersonCreateComponent,
    InvoiceListComponent,
    InvoiceCreateComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    FontAwesomeModule,
    HttpClientModule,
    NgbModule,
    ToastrModule.forRoot(),
    FormsModule,
    MaterialModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
