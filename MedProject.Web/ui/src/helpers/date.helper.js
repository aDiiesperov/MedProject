export class DateHelper {
  static getPrevMonth(countMonths) {
    let date = new Date();
    date.setMonth(date.getMonth() - countMonths);
    date.setHours(0, 0, 0, 0);
    return date;
  }
}
