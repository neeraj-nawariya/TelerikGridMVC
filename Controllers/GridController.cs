using System;
﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using TelerikGridMVC.Models;
using TelerikGridMVC.Entities;
using System.Data.SqlClient;
using System.Data;

namespace TelerikGridMVC.Controllers
{
	public partial class GridController : Controller
    {
		public ActionResult Orders_Read([DataSourceRequest]DataSourceRequest request)
		{
			var result = Enumerable.Range(0, 50).Select(i => new OrderViewModel
			{
				OrderID = i,
				Freight = i * 10,
				OrderDate = DateTime.Now.AddDays(i),
				ShipName = "ShipName " + i,
				ShipCity = "ShipCity " + i
			});

			return Json(result.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		}

		public ActionResult Products_Read([DataSourceRequest] DataSourceRequest request)
		{
            try { 
			using (TelerikEntities entities = new TelerikEntities()) {
					var data = entities.Products.AsNoTracking().ToList();
					return Json(data.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
			}
            }
            catch (EntityException ee)
            {
				return null;
            }
            catch (SqlException ex)
            {
				return null;
            }
            catch (Exception e)
            {
				string type = e.GetType().Name;
				return null;
            }
		}

		public JsonResult Remote_Data_Binding_Get_Employees(int? id)
		{
			
			using (TelerikEntities entities = new TelerikEntities())
			{
				var data = from e in entities.Products
						   where (id.HasValue ? e.ParentId == id : e.ParentId == null)
						   select new
						   {
							   id = e.ProductId,
							   Name = e.ProductName,
							   hasChildren = e.Products1.Any()

						   };
				return Json(data, JsonRequestBehavior.AllowGet);
			}
		}
	}
}
