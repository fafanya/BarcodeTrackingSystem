using System;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class Service : IService
    {
        public int InsertRouteSheet(RouteSheet routeSheet)
        {
            using (var db = new ServiceContext())
            {
                db.Add(routeSheet);
                db.SaveChanges();
                return routeSheet.RouteSheetId;
            }
        }
        public void UpdateRouteSheet(RouteSheet routeSheet)
        {
            using (var db = new ServiceContext())
            {
                db.Update(routeSheet);
                db.SaveChanges();
            }
        }
        public void DeleteRouteSheet(int routeSheetId)
        {
            using (var db = new ServiceContext())
            {
                RouteSheet routeSheet = new RouteSheet { RouteSheetId = routeSheetId };
                db.Attach(routeSheet);
                db.Remove(routeSheet);
                db.SaveChanges();
            }
        }
        public IEnumerable<RouteSheet> LoadRouteSheetList(DateTime periodBegin, DateTime periodEnd)
        {
            using (var db = new ServiceContext())
            {
                return db.RouteSheets.Where(x => x.RouteMarks.Max(y => y.Stamp) >= periodBegin &&
                                                 x.RouteMarks.Max(y => y.Stamp) <= periodEnd);
            }
        }

        public int InsertRouteMark(RouteMark routeMark)
        {
            using (var db = new ServiceContext())
            {
                if(routeMark.RouteSheet != null)
                {
                    RouteSheet routeSheet = db.RouteSheets.FirstOrDefault(x => x.Barcode == routeMark.RouteSheet.Barcode);
                    if (routeSheet != null)
                    {
                        routeMark.RouteSheetId = routeSheet.RouteSheetId;
                    }
                    else
                    {
                        db.Add(routeMark.RouteSheet);
                    }
                }

                if(routeMark.RoutePoint != null)
                {
                    RoutePoint routePoint = db.RoutePoints.FirstOrDefault(x => x.Name == routeMark.RoutePoint.Name);
                    if (routePoint != null)
                    {
                        routeMark.RoutePointId = routePoint.RoutePointId;
                    }
                    else
                    {
                        db.Add(routeMark.RoutePoint);
                    }
                }

                db.Add(routeMark);
                db.SaveChanges();
                return routeMark.RouteMarkId;
            }
        }
        public void UpdateRouteMark(RouteMark routeMark)
        {
            using (var db = new ServiceContext())
            {
                db.Update(routeMark);
                db.SaveChanges();
            }
        }
        public void DeleteRouteMark(int routeMarkId)
        {
            using (var db = new ServiceContext())
            {
                RouteMark routeMark = new RouteMark { RouteMarkId = routeMarkId };
                db.RouteMarks.Attach(routeMark);
                db.RouteMarks.Remove(routeMark);
                db.SaveChanges();
            }
        }
        public IEnumerable<RouteMark> LoadRouteMarkList(int routeSheetId)
        {
            using (var db = new ServiceContext())
            {
                return db.RouteMarks.Where(x => x.RouteSheetId == routeSheetId);
            }
        }

        public int InsertRoutePoint(RoutePoint routePoint)
        {
            using (var db = new ServiceContext())
            {
                db.Add(routePoint);
                db.SaveChanges();
                return routePoint.RoutePointId;
            }
        }
        public void UpdateRoutePoint(RoutePoint routePoint)
        {
            using (var db = new ServiceContext())
            {
                db.Update(routePoint);
                db.SaveChanges();
            }
        }
        public void DeleteRoutePoint(int routePointId)
        {
            using (var db = new ServiceContext())
            {
                RoutePoint routePoint = new RoutePoint { RoutePointId = routePointId };
                db.RoutePoints.Attach(routePoint);
                db.RoutePoints.Remove(routePoint);
                db.SaveChanges();
            }
        }
        public IEnumerable<RoutePoint> LoadRoutePointList()
        {
            using (var db = new ServiceContext())
            {
                return db.RoutePoints;
            }
        }
    }
}