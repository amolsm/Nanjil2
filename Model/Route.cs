using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model
{
    public class Route : User
    {

        private int _RouteID;
        private string _RouteName;
        private string _RouteDesc;
        private int _ASOID;
        private string _RouteCode;
        private string _Discription;
        private bool _IsArchive;
        private int _Category;
        private int _CenterID;

        public int CenterID
        {
            get
            {
                return _CenterID;
            }
            set
            {
                _CenterID = value;
            }
        }
        public int Category
        {
            get
            {
                return _Category;
            }
            set
            {
                _Category = value;
            }
        }

        public bool IsArchive
        {
            get
            {
                return _IsArchive;
            }
            set
            {
                _IsArchive = value;
            }
        }
        public int RouteID
        {
            get
            {
                return _RouteID;
            }
            set
            {
                _RouteID = value;
            }
        }
        public string RouteName
        {
            get
            {
                return _RouteName;
            }
            set
            {
                _RouteName = value;
            }
        }
        public string RouteDesc
        {
            get
            {
                return _RouteDesc;
            }
            set
            {
                _RouteDesc = value;
            }
        }
        public string Discription
        {
            get
            {
                return _Discription;
            }
            set
            {
                _Discription = value;
            }
        }
        public int ASOID
        {
            get
            {
                return _ASOID;
            }
            set
            {
                _ASOID = value;
            }
        }
        public string RouteCode
        {
            get
            {
                return _RouteCode;
            }
            set
            {
                _RouteCode = value;
            }
 
        }

        public int QIncentiveId { get; set; }
    }
}