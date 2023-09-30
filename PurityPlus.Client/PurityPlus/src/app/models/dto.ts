export interface CategoryDTO {
  categoryId: string;
  name: string;
  description?: string | null;
  parentCategoryId?: string | null;
  createdAt: Date;
  updatedAt: Date;
}

export interface BrandDTO {
  brandId: string;
  name: string;
  description: string;
  logoUrl: string;
  createdAt: Date;
  updatedAt: Date;
}

export interface ProductDTO {
  productId: string;
  name: string;
  description: string;
  price: number;
  discountedPrice?: number | null;
  stockQuantity: number;
  imageUrl: string[];
  categoryId: string;
  brandId: string;
  createdAt: Date;
  updatedAt: Date;
  category: CategoryDTO | null;
  brand: BrandDTO | null;
  rating?: number;
}

export interface OrderDTO {
  orderId: string;
  applicationUserId: string;
  totalAmount: number;
  status: string;
  shippingAddress: string;
  billingAddress: string;
  paymentId: string;
  createdAt: Date;
  updatedAt: Date;
  payment: PaymentDTO;
  orderItems: OrderItemDTO[];
}

export interface PaymentDTO {
  paymentId: string;
  amount: number;
  paymentDate: Date;
  paymentMethod: string;
  status: string;
  notes: string;
}

export interface OrderItemDTO {
  orderItemId: string;
  orderId: string;
  productId: string;
  quantity: number;
  unitPrice: number;
  totalPrice: number;
  createdAt: Date;
  updatedAt: Date;
  order: OrderDTO;
  product: ProductDTO;
}
