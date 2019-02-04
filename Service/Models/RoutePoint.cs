using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Service
{
    [DataContract]
    public class RoutePoint
    {
        [DataMember]
        public int RoutePointId { get; set; }
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public ICollection<RouteMark> RouteMarks { get; set; }
    }
}