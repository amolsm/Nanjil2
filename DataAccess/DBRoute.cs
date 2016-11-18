using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;
using DataAcess;
using System.Data;
namespace DataAccess
{
    public class DBRoute
    {
        DBHelper _DBHelper = new DBHelper();
        public int InsertRoute(Route route)
        {
            int result = 0;
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@routeId", route.RouteID));
                paramCollection.Add(new DBParameter("@RouteCode", route.RouteCode));
                paramCollection.Add(new DBParameter("@RouteName", route.RouteName));
                paramCollection.Add(new DBParameter("@RouteDesc", route.RouteDesc));
                paramCollection.Add(new DBParameter("@ASOName", route.ASOID));
                paramCollection.Add(new DBParameter("@Discription", route.Discription));
                paramCollection.Add(new DBParameter("@IsArchive", route.IsActive));
                paramCollection.Add(new DBParameter("@ModifiedBy", route.ModifiedBy));
                paramCollection.Add(new DBParameter("@ModifiedDate", route.ModifiedDate));
                paramCollection.Add(new DBParameter("@CreatedBy", route.CreatedBy));
                paramCollection.Add(new DBParameter("@CreatedDate", route.Createddate));
                paramCollection.Add(new DBParameter("@flag", route.flag));
                result = _DBHelper.ExecuteNonQuery("Sp_InsertRoute", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception)
            {


            }
            return result;
        }
        public DataSet GetAllRouteDetails()
        {
            DataSet DS = new DataSet();
            try
            {


                DBParameterCollection paramCollection = new DBParameterCollection();
                DS = _DBHelper.ExecuteDataSet("sp_GetAllRouteDetails", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {


            }
            return DS;
        }
        public DataSet GetRouteDetailsbyID(int routeID)
        {
            DataSet DS = new DataSet();
            try
            {


                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@routeID", routeID));
                DS = _DBHelper.ExecuteDataSet("sp_GetRouteDetailsbyID", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {

            }
            return DS;
        }
        public int InsertMilkCollectionRoute(Route route)
        {
            int result = 0;
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@routeId", route.RouteID));
                paramCollection.Add(new DBParameter("@RouteCode", route.RouteCode));
                paramCollection.Add(new DBParameter("@CenterID", route.CenterID));
                paramCollection.Add(new DBParameter("@RouteName", route.RouteName));
                paramCollection.Add(new DBParameter("@RouteDesc", route.RouteDesc));
                paramCollection.Add(new DBParameter("@ASOName", route.ASOID));
                paramCollection.Add(new DBParameter("@Discription", route.Discription));
                paramCollection.Add(new DBParameter("@Category", route.Category));
                paramCollection.Add(new DBParameter("@QIncentiveId", route.QIncentiveId));
                paramCollection.Add(new DBParameter("@IsArchive", route.IsActive));
                paramCollection.Add(new DBParameter("@ModifiedBy", route.ModifiedBy));
                paramCollection.Add(new DBParameter("@ModifiedDate", route.ModifiedDate));
                paramCollection.Add(new DBParameter("@CreatedBy", route.CreatedBy));
                paramCollection.Add(new DBParameter("@CreatedDate", route.Createddate));
                paramCollection.Add(new DBParameter("@flag", route.flag));
                result = _DBHelper.ExecuteNonQuery("Proc_Sp_InsertMilkCollectionRoute", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception)
            {


            }
            return result;
        }
        public DataSet GetAllMilkCollectionRouteDetails()
        {
            DataSet DS = new DataSet();
            try
            {


                DBParameterCollection paramCollection = new DBParameterCollection();
                DS = _DBHelper.ExecuteDataSet("Proc_sp_GetAllMilkCollectionRouteDetails", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {


            }
            return DS;
        }
        public DataSet GetMilkCollectionRouteDetailsbyID(int routeID)
        {
            DataSet DS = new DataSet();
            try
            {


                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@routeID", routeID));
                DS = _DBHelper.ExecuteDataSet("Proc_sp_GetMilkCollectionRouteDetailsbyID", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {

            }
            return DS;
        }
    }
}