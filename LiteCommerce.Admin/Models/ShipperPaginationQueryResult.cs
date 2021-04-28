﻿using LiteCommerce.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiteCommerce.Admin.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class ShipperPaginationQueryResult : BasePaginationQueryResult
    {
        /// <summary>
        /// 
        /// </summary>
        public List<Shipper> Data { get; set; }
    }
}