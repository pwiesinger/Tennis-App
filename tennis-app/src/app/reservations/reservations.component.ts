import { Component, OnInit } from '@angular/core';
import {BookingReplyDto, BookingsService, PersonReplyDto, PersonsService} from '../swagger';
import {MatDialog} from '@angular/material/dialog';
import {AddBookingDialogComponent} from '../add-booking-dialog/add-booking-dialog.component';

export interface TimelineEntry {
  time: number;
  // entry id
  entryIds: number[];
}



@Component({
  selector: 'app-reservations',
  templateUrl: './reservations.component.html',
  styleUrls: ['./reservations.component.scss']
})
export class ReservationsComponent implements OnInit {

  entries: TimelineEntry[] = [];
  selectedWeek = 22;

  bookings: BookingReplyDto[] = [];
  persons: PersonReplyDto[] = [];

  constructor(private dialog: MatDialog, private bookingsService: BookingsService, private personsService: PersonsService) { }

  ngOnInit(): void {
    this.reload();
  }

  reload(): void {
    this.bookingsService.apiBookingsGet().subscribe(x => {
      this.bookings = x;
      this.setup();
    });
    this.personsService.apiPersonsGet().subscribe(x => {
      this.persons = x;
      this.setup();
    });
  }

  setup(): void {
    if (this.persons.length !== 0 && this.bookings.length !== 0) {
      this.entries = [];

      for (let i = 9; i <= 22; i++) {
        const bookingsInWeekAndHour = this.bookings.filter(x => x.week == this.selectedWeek && x.hour == i);

        const entryIds: number[] = [];
        // sorting by day and filling the remaining entries...
        for (let j = 0; j <= 6; j++) {
          const replyDto = bookingsInWeekAndHour.find(x => x.dayOfWeek == j);
          if (replyDto) {
            entryIds.push(replyDto.id);
          } else {
            entryIds.push(-1);
          }
        }

        this.entries.push({
          time: i,
          entryIds
        });
      }

      console.log(this.bookings);
      console.log(this.entries);

      console.log('setting up!');
    } else {
      console.log('not everything received yet!');
    }
  }

  getName(bookingId: number): string {
    if (bookingId !== -1) {
      const dto = this.bookings.find(x => bookingId == x.id);
      const personReplyDto = this.persons.find(x => dto.personId == x.id);
      return `${personReplyDto.lastname} ${personReplyDto.firstname}`;
    } else {
      return '';
    }
  }

  nextWeek() {
    this.selectedWeek++;
    this.setup();
  }

  previousWeek() {
   this.selectedWeek--;
   this.setup();
  }

  addBooking(booking: number) {
    console.log(booking);
    const dialogRef = this.dialog.open(AddBookingDialogComponent, {
      data: booking
    });

    dialogRef.afterClosed().subscribe(x => {
      console.log('closed');
      this.reload();
    });
  }
}
