export * from './bookings.service';
import { BookingsService } from './bookings.service';
export * from './persons.service';
import { PersonsService } from './persons.service';
export const APIS = [BookingsService, PersonsService];
