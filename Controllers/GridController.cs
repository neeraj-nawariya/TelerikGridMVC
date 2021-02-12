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
				//ProductViewModel model = new ProductViewModel();
				//var data = entities.Products.AsNoTracking().ToList();
				var attr = from a in
						  (from a1 in entities.Products
						   join a2 in entities.Products on a1.ProductId equals a2.ParentId into ag
						   from aa in ag.DefaultIfEmpty()
						   where (id.HasValue ? a1.ParentId == id : (a1.ParentId == null) || (a1.ParentId == 0))
						   select new { Id = a1.ProductId, Name = a1.ProductName, hasPar = aa.ProductId != null ? 1 : 0 })
						   group a by new { a.Id, a.Name } into ga
						   select new { Id = ga.Key.Id, Name = ga.Key.Name, hasParent = ga.Max(a => a.hasPar) != 0 };

				var data1 = from e in entities.Products
						   where (id.HasValue ? e.ParentId == id : e.ParentId == null)
						   select new
						   {
							   id = e.ProductId,
							   Name = e.ProductName,
							   hasChildren = e.Products1.Any()

						   };
				return Json(attr, JsonRequestBehavior.AllowGet);
			}

			//var employees = from e in dataContext.Employees
			//				where (id.HasValue ? e.ReportsTo == id : e.ReportsTo == null)
			//				select new
			//				{
			//					id = e.EmployeeID,
			//					Name = e.FirstName + " " + e.LastName,
			//					hasChildren = e.Employees1.Any()
			//				};

			//return Json(employees, JsonRequestBehavior.AllowGet);
		}
	}
}
