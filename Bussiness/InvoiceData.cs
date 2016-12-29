using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;
using DataAccess;
using System.Data;
namespace Bussiness
{
    public class InvoiceData
    {
        DBInvoice dbinvoice = new DBInvoice();
        public bool InsertTempInvoiceItam(Invoice invoice)
        {
            return dbinvoice.InsertTempInvoiceItam(invoice);
        }
        public bool CheckTempInvoiceItam(Invoice invoice, int flag)
        {
            return dbinvoice.CheckTempInvoiceItam(invoice, flag);
        }
        public bool InsertTempBulkItam(Invoice invoice)
        {
            return dbinvoice.InsertTempBulkItam(invoice);
        }
        public bool DeleteBulkOrderItems(int id)
        {
            return dbinvoice.DeleteBulkOrderItems(id);
        }
        public bool returnSchemeAmount(int orderid, int returnBy)
        {
            return dbinvoice.returnSchemeAmount(orderid, returnBy);
        }
        
        public bool UpdateOrderID(int ids, int newid)
        {
            return dbinvoice.UpdateOrderID(ids, newid);
        }
        public bool UpdateBulkOrderEditItem(Invoice inv)
        {
            return dbinvoice.UpdateBulkOrderEditItem(inv);
        }
        public bool updateBillNo(int ids,string orderdate)
        {
            return dbinvoice.updateBillNo(ids, orderdate);
        }
        public bool updateAgentScheme(int ids)
        {
            return dbinvoice.updateAgentScheme(ids);
        }
        public DataSet chkScheme(Invoice invoice)
        {
            return dbinvoice.chkScheme(invoice);
        }
        public DataSet GetTempItam(Invoice invoice)
        {
            return dbinvoice.GetTempItam(invoice);
        }
        public DataSet GetBulkTempItam(Invoice invoice)
        {
            return dbinvoice.GetBulkTempItam(invoice);
        }
        public DataSet getBulkOrderDetailsForEdit(int id)
        {
            return dbinvoice.getBulkOrderDetailsForEdit(id);
        }
        public int  DeleteItes(Invoice invoice)
        {
            return dbinvoice.DeleteTempItems(invoice);
        }
        public int InsertOrder(Invoice invoice)
        {
            return dbinvoice.InserOrder(invoice);
        }
        public int TempDelete(int tempId, int prvOrdId=0)
        {
            return dbinvoice.TempDelete(tempId, prvOrdId);
        }
        public DataSet GetUnitPriceBysablID( Invoice invoice)
        {
            return dbinvoice.GetUnitPriceBysablID(invoice);
        }
        public DataSet GetPreviousDayOrder(Invoice invoice)
        {
            return dbinvoice.GetPreviousDayOrder(invoice);
        }
        public DataSet GetPreviousDayOrderRouteWise(Invoice invoice)
        {
            return dbinvoice.GetPreviousDayOrderRouteWise(invoice);
        }

        public bool AddSchemeOnRollback(int orderid)
        {
            return dbinvoice.AddSchemeOnRollback(orderid);
        }

        public DataSet GetPreviousDayOrderRouteWiseEmp(Invoice invoice)
        {
            return dbinvoice.GetPreviousDayOrderRouteWiseEmp(invoice);
        }
        public DataSet GetDetailsforUpdateOrderID(Invoice invoice)
        {
            return dbinvoice.GetDetailsforUpdateOrderID(invoice);
        }
        public DataSet GetOrdersForSubmit(Invoice invoice)
        {
            return dbinvoice.GetOrdersForSubmit(invoice);
        }
        public DataSet GetDetailsBulkBillNo()
        {
            return dbinvoice.GetDetailsBulkBillNo();
        }
        public DataSet GetBulkSchemeDetails()
        {
            return dbinvoice.GetBulkSchemeDetails();
        }
        public DataSet GetStock(int boothid)
        {
            return dbinvoice.GetStock(boothid);
        }
        public DataSet GetStockAgent(int boothid)
        {
            return dbinvoice.GetStockAgent(boothid);
        }
        public DataSet updateStockUser(int boothid, int userid)
        {
            return dbinvoice.updateStockUser(boothid, userid);
        }
        public DataSet CheckBoothTemp(Invoice invoice, int chkflg)
        {
            return dbinvoice.CheckBoothTemp(invoice, chkflg);
        }
        public int BoothInserOrder(Invoice invoice)
        {
            return dbinvoice.BoothInserOrder(invoice);
        }
        public int BoothLocalInserOrder(Invoice invoice)
        {
            return dbinvoice.BoothLocalInserOrder(invoice);
        }

        public bool Booth_InsertTempInvoiceItam(Invoice invoice)
        {
            return dbinvoice.Booth_InsertTempInvoiceItam(invoice);
        }
        public bool updateBulkFlag(int routeid, int types)
        {
            return dbinvoice.updateBulkFlag(routeid, types);
        }
        
        public DataSet checkStock(Invoice invoice)
        {
            return dbinvoice.checkStock(invoice);
        }
        
        public int BoothTempDelete(int tempId)
        {
            return dbinvoice.BoothTempDelete(tempId);
        }
       
        public int DeleteBoothTempItems(Invoice invoice)
        {
            return dbinvoice.DeleteBoothTempItems(invoice);
        }

        public DataSet GetBoothTempItam(Invoice invoice)
        {
            return dbinvoice.GetBoothTempItam(invoice);
        }
        public DataSet GetSlabID(Invoice invoice)
        {
            return dbinvoice.GetSlabID(invoice);
        }
        public DataSet getBillCount(string dates, int boothIds)
        {
            return dbinvoice.getBillCount(dates, boothIds);
        }
        public DataSet getBoothAgentBillCount(string dates, int boothIds)
        {
            return dbinvoice.getBoothAgentBillCount(dates, boothIds);
        }
        public DataSet GetSchemeRoutewise(Invoice invoice)
        {
            return dbinvoice.GetSchemeRoutewise(invoice);
        }
        public DataSet getBulkEmpSlabPrice(Invoice inv)
        {
            return dbinvoice.getBulkEmpSlabPrice(inv);
        }

        public DataSet Checkempduplicateorder(Invoice invoice)
        {
            return dbinvoice.Checkempduplicateorder(invoice);
        }
    }
}