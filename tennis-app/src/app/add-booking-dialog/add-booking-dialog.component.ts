import {Component, Inject, OnInit} from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import {BookingReplyDto, BookingsService, PersonReplyDto, PersonsService} from '../swagger';

@Component({
  selector: 'app-add-booking-dialog',
  templateUrl: './add-booking-dialog.component.html',
  styleUrls: ['./add-booking-dialog.component.scss']
})
export class AddBookingDialogComponent implements OnInit {

  booking: BookingReplyDto;
  persons: PersonReplyDto[] = [];
  times = [9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22];
  weeks = Array.from(Array(51).keys());
  daysOfWeek = ['Montag', 'Dienstag', 'Mittwoch', 'Donnerstag', 'Freitag', 'Samstag', 'Sonntag'];
  selectedPerson: number;
  selectedTime: number;
  selectedDayOfWeek: number;
  selectedWeeks: number;

  showIsUpdate = true;

  constructor(public dialogRef: MatDialogRef<AddBookingDialogComponent>, @Inject(MAT_DIALOG_DATA) public data: number, private bookingsService: BookingsService, private personsService: PersonsService) { }

  ngOnInit(): void {
    if (this.data === -1) {
      this.showIsUpdate = false;
      this.booking = {};
    } else {
      this.bookingsService.apiBookingsIdGet(this.data).subscribe(x => {
        this.booking = x;
        this.selectedTime = this.booking.hour;
        this.selectedDayOfWeek = this.booking.dayOfWeek;
        this.selectedPerson = this.booking.personId;
        this.selectedWeeks = this.booking.week;
      });
    }
    this.personsService.apiPersonsGet().subscribe(x => this.persons = x);
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

  create(): void {
    console.log('create');
    if (this.selectedPerson && this.selectedTime && this.selectedDayOfWeek) {
      const booking = {
        week: Number(this.selectedWeeks),
        personId: Number(this.selectedPerson),
        dayOfWeek: Number(this.selectedDayOfWeek),
        hour: Number(this.selectedTime),
      };
      console.log(booking);
      this.bookingsService.apiBookingsPost(booking).subscribe(x => this.onNoClick());
    }
  }

  update(): void {
    console.log('update');
    const booking = {
      dayOfWeek: Number(this.selectedDayOfWeek),
      hour: Number(this.selectedTime),
      personId: Number(this.selectedPerson),
      week: Number(this.selectedWeeks),
    };

    console.log(booking);

    this.bookingsService.apiBookingsIdPut(this.data, booking).subscribe(x => this.onNoClick());
  }

  delete(): void {
    this.bookingsService.apiBookingsIdDelete(this.booking.id).subscribe(x => this.onNoClick());
  }
}
