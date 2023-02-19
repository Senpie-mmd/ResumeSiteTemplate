using System.Globalization;

namespace MyResumeSite.Utilities
{
    public static class Converter
    {
        public static string PhoneFormat(this string value)
        {
            string format = "+98-###-###-####";
            return Convert.ToInt64(value).ToString(format);
        }

        public static string ToShamsi(this DateTime value)
        {
            PersianCalendar pc = new PersianCalendar();
            return pc.GetYear(value) + "/" +
                pc.GetMonth(value) + "/" +
                pc.GetDayOfMonth(value);
        }

        public static string ToMiladi(this DateTime value)
        {
            return value.ToString("yyyy/MM/dd") + "--" +
                value.Hour.ToString("00") + ":" +
                value.Minute.ToString("00");
        }
    }
}
