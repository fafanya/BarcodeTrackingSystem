using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Service
{
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        int InsertRouteSheet(RouteSheet routeSheet);
        [OperationContract]
        void UpdateRouteSheet(RouteSheet routeSheet);
        [OperationContract]
        void DeleteRouteSheet(int routeSheetId);
        [OperationContract]
        IEnumerable<RouteSheet> LoadRouteSheetList(DateTime periodBegin, DateTime periodEnd);

        [OperationContract]
        int InsertRouteMark(RouteMark routeMark);
        [OperationContract]
        void UpdateRouteMark(RouteMark routeMark);
        [OperationContract]
        void DeleteRouteMark(int routeMarkId);
        [OperationContract]
        IEnumerable<RouteMark> LoadRouteMarkList(int routeSheetId);

        [OperationContract]
        int InsertRoutePoint(RoutePoint routePoint);
        [OperationContract]
        void UpdateRoutePoint(RoutePoint routePoint);
        [OperationContract]
        void DeleteRoutePoint(int routePointId);
        [OperationContract]
        IEnumerable<RoutePoint> LoadRoutePointList();
    }
}