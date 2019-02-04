using System;
using System.Runtime.Serialization;

namespace Service
{
    [DataContract]
    public class RouteMark
    {
        [DataMember]
        public int RouteMarkId { get; set; }
        [DataMember]
        public DateTime Stamp { get; set; }

        [DataMember]
        public int RouteSheetId { get; set; }
        [DataMember]
        public RouteSheet RouteSheet { get; set; }

        [DataMember]
        public int RoutePointId { get; set; }
        [DataMember]
        public RoutePoint RoutePoint { get; set; }
    }
}