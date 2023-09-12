import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { ProductCatalogComponent } from './pages/product-catalog/product-catalog.component';

const routes: Routes = [
  { path: "", redirectTo: "shop", pathMatch: "full" },
  { path: "shop", component: HomeComponent },
  { path: "products", component: ProductCatalogComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
