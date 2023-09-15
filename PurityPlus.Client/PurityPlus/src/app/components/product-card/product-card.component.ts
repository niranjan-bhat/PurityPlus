import { Component, EventEmitter, Input, Output } from '@angular/core';
import { ProductDTO } from 'src/app/models/dto';

@Component({
  selector: 'app-product-card',
  templateUrl: './product-card.component.html',
  styleUrls: ['./product-card.component.scss']
})
export class ProductCardComponent {
  @Input() product: ProductDTO | undefined;

  @Output() onClick = new EventEmitter<ProductDTO>();

  rating: number = 3;


  getThumbnil() {
    return this.product?.imageUrl[0];
  }

  onCardClick(){
    this.onClick.emit(this.product);
  }
}
