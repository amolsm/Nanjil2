﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using DataAccess;
using Model;

namespace Bussiness
{
    public class MarketingData
    {
        DataSet DS = new DataSet();
     
        DBMarketing dbMarketing = new DBMarketing();
        public DataSet GetAgentInfoForSchemeRefund(int AgentID)
        {
            dbMarketing = new DBMarketing();
            return dbMarketing.GetAgentInfoForSchemeRefund(AgentID);
        }

        public DataSet GetSchemeRefundInfo(Marketings marketing)
        {

            dbMarketing = new DBMarketing();
            DS = new DataSet();

            try
            {
                DS = dbMarketing.GetSchemeRefundInfo(marketing);
                return DS;
            }
            catch (Exception)
            {

                throw;
            }


       
        }

        public int AddSchemeRefund(Marketings marketing)
        {
            dbMarketing = new DBMarketing();
            int Result = 0;
            try
            {
                Result = dbMarketing.AddSchemeRefund(marketing);
                return Result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataSet AgentRefundSchemeSummary(string StartDate, string EndDate, int RouteID, int AgentID)
        {
            return dbMarketing.AgentRefundSchemeSummary(StartDate, EndDate, RouteID, AgentID);
        }

        public DataSet ItemWiseStaffSalesSummarybyDate(string StartDate, string EndDate, int EmployeID)
        {
            return dbMarketing.ItemWiseStaffSalesSummarybyDate(StartDate, EndDate, EmployeID);
        }

        public DataSet BillWiseStaffSalesSummarybyDate(string StartDate, string EndDate, int EmployeID)
        {
            return dbMarketing.BillWiseStaffSalesSummarybyDate(StartDate, EndDate, EmployeID);
        }

        public int AddAgentDamageReplacementRateSetup(string agentId, int routeid, int categoryid, int typeid, int commodityid, string damagereplacementrate, bool isActive)
        {
            dbMarketing = new DBMarketing();
            return dbMarketing.AddAgentDamageReplacementRateSetup(agentId, routeid, categoryid, typeid, commodityid, damagereplacementrate, isActive);
        }

        public DataSet ReturnComparisionreportbyDate(string Start1Date, string End1Date, string Start2Date, string End2Date, int AgentID, int BrandID)
        {
            return dbMarketing.ReturnComparisionreportbyDate(Start1Date, End1Date, Start2Date, End2Date,  AgentID, BrandID);
        }

        public DataSet ViewNewAgentList(string Date, int RouteID)
        {
            dbMarketing = new DBMarketing();
            return dbMarketing.ViewNewAgentList(Date, RouteID);
        }

        public DataSet ViewAgentListNotPlacedOrder(string StartDate, string EndDate, int RouteID)
        {
            dbMarketing = new DBMarketing();
            return dbMarketing.ViewAgentListNotPlacedOrder(StartDate, EndDate, RouteID);
        }
        public DataSet ViewDeactiveAgentList(string StartDate, string EndDate, int RouteID)
        {
            dbMarketing = new DBMarketing();
            return dbMarketing.ViewDeactiveAgentList(StartDate, EndDate, RouteID);
        }

        public DataSet ViewAgentSlabReportList(int RouteID, int SlabId, int TypeId)
        {
            dbMarketing = new DBMarketing();
            return dbMarketing.ViewAgentSlabReportList(RouteID, SlabId, TypeId);
        }

        public DataSet ViewItemwisePurchaseAgentList(string StartDate, string EndDate, int RouteID, int TypeID, int CommodityID)
        {
            dbMarketing = new DBMarketing();
            return dbMarketing.ViewItemwisePurchaseAgentList(StartDate, EndDate, RouteID, TypeID, CommodityID);
        }

        public DataSet AmountwiseIceCreamReport(string Date, int RouteID, double startamt, double endamt)
        {
            dbMarketing = new DBMarketing();
            return dbMarketing.AmountwiseIceCreamReport(Date, RouteID, startamt, endamt);
        }
    }
}