using System;
using System.Globalization;

namespace Core.Costant
{
    public static class ARAConvertDate
    {

        /// <summary>
        /// یک استرینگ تاریخ شمسی که از دیتا پیکر میاد را به معادل میلادی تبدیل میکند
        /// </summary>
        /// <param name="persianDate">تاریخ شمسی</param>
        /// <returns>تاریخ میلادی</returns>
        public static DateTime ToGeorgianDateTime(int year, int month, int day)
        {
            try
            {
                PersianCalendar pc = new PersianCalendar();

                return new DateTime(year, month, day, pc);
            }
            catch (Exception)
            {

                return System.DateTime.Now;
            }

        }
        /// <summary>
        /// یک استرینگ تاریخ شمسی که از گرید  میاد را به معادل میلادی تبدیل میکند
        /// </summary>
        /// <param name="persianDate">تاریخ شمسی</param>
        /// <returns>تاریخ میلادی</returns>
        public static DateTime? ToGeorgianDateTimeForGridNullable(string date)
        {
            try
            {
                PersianCalendar pc = new PersianCalendar();
                DateTime dt = new DateTime(Int32.Parse(date.Substring(0, 4)), Int32.Parse(date.Substring(5, 2)), Int32.Parse(date.Substring(8, 2)), pc);
                return dt;
            }
            catch (Exception)
            {
                return null;
            }

        }
        /// <summary>
        /// یک استرینگ تاریخ شمسی که از گرید  میاد را به معادل میلادی تبدیل میکند
        /// </summary>
        /// <param name="persianDate">تاریخ شمسی</param>
        /// <returns>تاریخ میلادی</returns>
        public static DateTime ToGeorgianDateTimeForGrid(string date)
        {
            try
            {

                PersianCalendar pc = new PersianCalendar();

                int index = date.IndexOf('/');
                int Lastindex = date.LastIndexOf('/');
                DateTime dt = new DateTime(Int32.Parse(date.Substring(0, index)),
                    Int32.Parse(date.Substring(++index, Lastindex - index)),
                    Int32.Parse(date.Substring(++Lastindex, date.Length - Lastindex)), pc);
                return dt;
            }
            catch (Exception)
            {
                throw new Exception(ExceptionMessage.InvalidDatetime);
            }

        }
        /// <summary>
        /// یک تاریخ میلادی را به معادل فارسی آن تبدیل میکند
        /// </summary>
        /// <param name="georgianDate">تاریخ میلادی</param>
        /// <returns>تاریخ شمسی</returns>
        public static string ToPersianDateStringNullable(this DateTime? georgianDate)
        {

            if (georgianDate == null)
                return "";

            if (georgianDate.Value.Date < DateTime.Now.AddYears(-100))
                return "";
            else
            {
                DateTime @datetime = Convert.ToDateTime(georgianDate);

                System.Globalization.PersianCalendar persianCalendar = new System.Globalization.PersianCalendar();

                string year = persianCalendar.GetYear(@datetime).ToString();
                string month = persianCalendar.GetMonth(@datetime).ToString().PadLeft(2, '0');
                string day = persianCalendar.GetDayOfMonth(@datetime).ToString().PadLeft(2, '0');
                string persianDateString = string.Format("{0}/{1}/{2}", year, month, day);
                return persianDateString;
            }
        }
        public static string ToPersianDateString(this DateTime georgianDate)
        {
            if (georgianDate == null)
                return "";
            else
            {
                DateTime @datetime = Convert.ToDateTime(georgianDate);

                System.Globalization.PersianCalendar persianCalendar = new System.Globalization.PersianCalendar();

                string year = persianCalendar.GetYear(@datetime).ToString();
                string month = persianCalendar.GetMonth(@datetime).ToString().PadLeft(2, '0');
                string day = persianCalendar.GetDayOfMonth(@datetime).ToString().PadLeft(2, '0');
                string persianDateString = string.Format("{0}/{1}/{2}", year, month, day);
                return persianDateString;
            }
        }


        /// <summary>
        /// ماه تاریخ شمسی را باز می گرداند
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static int ShamsiMouth(DateTime dateTime)
        {
            var persianCalendar = new System.Globalization.PersianCalendar();

            return persianCalendar.GetMonth(dateTime);
        }

        public static int ShamsiYear(DateTime dateTime)
        {
            var persianCalendar = new System.Globalization.PersianCalendar();

            return persianCalendar.GetYear(dateTime);
        }
        public static string DayName(DateTime dateTime)
        {
            var persianCalendar = new System.Globalization.PersianCalendar();
            switch (persianCalendar.GetDayOfWeek(dateTime))
            {
                case DayOfWeek.Friday:
                    return "جمعه";
                    
                case DayOfWeek.Monday:
                    return "دوشنبه";
                   
                case DayOfWeek.Saturday:
                    return "شنبه";
                   
                case DayOfWeek.Sunday:
                    return "یکشنبه";
                   
                case DayOfWeek.Thursday:
                    return "پنج‌شنبه";
                   
                case DayOfWeek.Tuesday:
                    return "سه‌شنبه";
                    
                case DayOfWeek.Wednesday:
                    return "چهار‌شنبه";
                  
                default:
                    return  string.Empty;
                  
            }
            
        }

    }
}
