import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MegaMenuModule } from 'primeng/megamenu';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HeaderComponent } from './layout/header/header.component';
import { FooterComponent } from './layout/footer/footer.component';
import { BadgeModule } from 'primeng/badge';
import { OverlayPanelModule } from 'primeng/overlaypanel';
import { HomeComponent } from './pages/home/home.component';
import { HeroComponent } from './components/hero/hero.component';
import { BeautyEssentialsComponent } from './components/beauty-essentials/beauty-essentials.component';
import { ProductCatalogComponent } from './pages/product/product-catalog/product-catalog.component';
import { ProductCardComponent } from './components/product-card/product-card.component'; 
import { RippleModule } from 'primeng/ripple';
import { APP_INITIALIZER } from '@angular/core';
import { PrimeNGConfig } from 'primeng/api';
import { TooltipModule } from 'primeng/tooltip';
import { RatingModule } from 'primeng/rating';
import { FormsModule } from '@angular/forms';
import { SharedModule } from './shared/shared.module';

const initializeAppFactory = (primeConfig: PrimeNGConfig) => () => {
  // ......
  primeConfig.ripple = true;
};

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    HomeComponent,
    HeroComponent,
    BeautyEssentialsComponent,
    ProductCatalogComponent,
    ProductCardComponent,
  ],
  imports: [
    BrowserModule, 
    BrowserAnimationsModule, 
    MegaMenuModule,
    AppRoutingModule,
    BadgeModule,
    OverlayPanelModule,
    RippleModule,
    TooltipModule,
    FormsModule,
    RatingModule,
    SharedModule
  ],
  providers: [
    {
       provide: APP_INITIALIZER,
       useFactory: initializeAppFactory,
       deps: [PrimeNGConfig],
       multi: true,
    },
 ],
  bootstrap: [AppComponent]
})
export class AppModule { }
