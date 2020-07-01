import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatTabsModule} from '@angular/material/tabs';
import { PersonsComponent } from './persons/persons.component';
import {MatTableModule} from '@angular/material/table';
import { ReservationsComponent } from './reservations/reservations.component';
import {MatButtonModule} from '@angular/material/button';
import {MatIconModule} from '@angular/material/icon';
import {HttpClientModule} from '@angular/common/http';
import {ApiModule, BASE_PATH} from './swagger';
import {environment} from '../environments/environment';
import { AddBookingDialogComponent } from './add-booking-dialog/add-booking-dialog.component';
import {MatDialogModule} from '@angular/material/dialog';
import {MatInputModule} from '@angular/material/input';
import {FormsModule} from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    PersonsComponent,
    ReservationsComponent,
    AddBookingDialogComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatTabsModule,
    MatTableModule,
    MatButtonModule,
    MatIconModule,
    HttpClientModule,
    ApiModule,
    MatDialogModule,
    MatInputModule,
    FormsModule
  ],
  providers: [
    {provide : BASE_PATH, useValue: environment.apiRoot}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
