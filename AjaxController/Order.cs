using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AjaxController
{
    public class Order
    {
        /// <summary>
        /// Order Add
        /// </summary>
        /// <returns></returns>
        public string Add() {
            return "Order Added Success！";
        }

        /// <summary>
        /// Update Order
        /// </summary>
        /// <returns></returns>
        public string Update()
        {
            return "Order has been Updated！";
        }

        /// <summary>
        /// Order List
        /// </summary>
        /// <returns></returns>
        public string OrderList() {
            return "Order Lists!";
        }

    }
}