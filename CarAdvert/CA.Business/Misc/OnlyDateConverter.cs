using Newtonsoft.Json.Converters;

namespace CA.Business.Misc
{
    public class OnlyDateConverter : IsoDateTimeConverter
    {
        public OnlyDateConverter()
        {
            DateTimeFormat = "dd-MM-yyyy";
        }
    }
}
