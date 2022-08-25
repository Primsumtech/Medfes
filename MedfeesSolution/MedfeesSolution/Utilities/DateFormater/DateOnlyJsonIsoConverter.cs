namespace MedfeesSolution.Utilities.DateFormater
{
    public class DateOnlyJsonIsoConverter : Newtonsoft.Json.Converters.IsoDateTimeConverter
    {
        public DateOnlyJsonIsoConverter()
        {
            DateTimeFormat = "dd-MM-yyyyT00:00:00";
        }
    }
}
