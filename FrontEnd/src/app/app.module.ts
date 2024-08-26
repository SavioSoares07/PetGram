//Imports Angular
import { NgModule } from '@angular/core';
import {
  BrowserModule,
  provideClientHydration,
} from '@angular/platform-browser';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { AnguarMaterialModule } from './angular-material/angular-material.module';

//App
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

//My Imports
import { Components } from './components/components.module';
import { PagesModule } from './Pages/pages.module';

@NgModule({
  declarations: [AppComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    AnguarMaterialModule,
    Components,
    PagesModule,
  ],
  providers: [provideClientHydration(), provideAnimationsAsync()],
  bootstrap: [AppComponent],
})
export class AppModule {}
