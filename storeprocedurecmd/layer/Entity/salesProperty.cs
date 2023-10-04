using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
namespace DBL
{
	// this file is the Property of the class
	public class salesProperty
	{

		#region Points to Remember
		// 1) Write your connection string in <appSettings/>
		//    E.g. <appSettings>
		//             <add key="connStr" value=""/>
		//             <add key="provider" value=""/>
		//                 Provider Value: 0=Sql Server
		//                                 1=OleDB
		//                                 2=ODBC
		//         <appSettings>
		// 2) Datetime Fields of database are created as string here.
		// 3) For new functionality or property create a customized class
		//    and inherit that customized class into this class and use its methods or properties
		// 4) All properties having datatype as numeric in database are created as float here
		//    so that it works for both numeric(9,0) or numeric(9,2)
		//    make sure to convert it at front end into float
		// 5) Date format:
		//         > Insertion:yyyy-MM-dd (Handled by DBL),so just pass into dd/MM/yyyy format
		//         > Display:dd/MM/yyyy
		//         > Retrival:Convert into custom format as below:
		//             -> SQL Server: CONVERT(varchar,<Column Name>,103)
		//             -> Access: FORMAT(<Column Name>,'dd/MM/yyyy')
		// 6) int?, float?, double? use for assigning null value to property.
		#endregion

		#region "Variables & GET/SET"

			private string _Table_name  = "sales";
			public string Table_name 
			{
				get { return _Table_name ;}
				set { _Table_name = value; }
			}


			private int? _s_id;
			public int? s_id
			{
				get { return _s_id;}
				set { _s_id= value; }
			}


			private string _product_name;
			public string product_name
			{
				get { return _product_name;}
				set { _product_name= value; }
			}


			private int? _unit;
			public int? unit
			{
				get { return _unit;}
				set { _unit= value; }
			}


			private int? _cost;
			public int? cost
			{
				get { return _cost;}
				set { _cost= value; }
			}


			private int? _gst;
			public int? gst
			{
				get { return _gst;}
				set { _gst= value; }
			}


			private int? _total;
			public int? total
			{
				get { return _total;}
				set { _total= value; }
			}


		#endregion
		}
}
