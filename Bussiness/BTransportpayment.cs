﻿using DataAccess;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Bussiness
{
    public class BTransportpayment
    {
        DBTransportpayment dbtp = new DBTransportpayment();
        public DataSet TransportPaymentDetails(MTransportPayment p)
        {
            return dbtp.TransportPaymentDetails(p);
        }
    }
}