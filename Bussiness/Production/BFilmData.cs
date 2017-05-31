using System;
using Model.Production;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using DataAccess.Production;
using DataAccess;
using Bussiness;
using Model;

namespace Bussiness.Production
{
    public class BFilmData
    {
        DAFilmData dadata;
        DataSet DS;

        public int filmdata(MFilmData receive)
        {
            dadata = new DAFilmData();
            int Result = 0;
            try
            {

                Result = dadata.filmdata(receive);

            }
            catch (Exception)
            {
                throw;
            }
            return Result;
        }

        public DataSet GetFilmDetailsById(int Id)
        {
            dadata = new DAFilmData();
            return dadata.GetFilmDetailsById(Id);
        }
        public DataSet GetFilmDetails(RMRecieve R)
        {
            dadata = new DAFilmData();
            return dadata.GetFilmDetails(R);
        }
    }
}