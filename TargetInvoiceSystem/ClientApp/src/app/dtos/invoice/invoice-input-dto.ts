import { InvoiceProductsDto } from './invoice-products-dto';

export class InvoiceInputDto {
    id: string;
    date: Date;
    totalPrice: number;
    discount: number;
    netPrice: number;
    totalQuantity: number;
    invoiceProducts: InvoiceProductsDto;
    userId: string;
    personId: string;
    isSellInvoice: boolean;
}
