import { NgModule } from '@angular/core';
import { ServerModule } from '@angular/platform-server';

import { AppModule } from './app.module';
import { AppComponent } from './app.component';
import { PagesModule } from './Pages/pages.module';

@NgModule({
  imports: [AppModule, ServerModule, PagesModule],
  bootstrap: [AppComponent],
})
export class AppServerModule {}
