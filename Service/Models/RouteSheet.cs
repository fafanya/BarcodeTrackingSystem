using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Service
{
    [DataContract]
    public class RouteSheet
    {
        [DataMember]
        public int RouteSheetId { get; set; }
        [DataMember]
        public string Barcode { get; set; }

        [DataMember]
        public ICollection<RouteMark> RouteMarks { get; set; }
    }
}