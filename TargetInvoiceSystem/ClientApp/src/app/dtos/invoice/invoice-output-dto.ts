import { InvoiceProductOutputDto } from './invoice-product-output-dto';

export class InvoiceOutputDto {
    id: string;
    date: Date;
    totalPrice: number;
    discount: number;
    netPrice: number;
    totalQuantity: number;
    invoiceProductOutputDtos: InvoiceProductOutputDto;
    userName: string;
    personName: string;
    isSellInvoice: boolean;
}
