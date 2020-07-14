import { ProductDto } from './product-dto';
export class ProductInputDto {
    productDto: ProductDto;
    unitDtoId: string;
    sellPrice: number;
    buyPrice: number;
}
