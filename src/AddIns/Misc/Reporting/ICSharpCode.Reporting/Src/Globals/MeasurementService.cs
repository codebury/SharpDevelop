﻿/*
 * Created by SharpDevelop.
 * User: Peter Forstmeier
 * Date: 30.04.2013
 * Time: 19:44
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using ICSharpCode.Reporting.PageBuilder.ExportColumns;

namespace ICSharpCode.Reporting.Globals
{
	/// <summary>
	/// Description of MeasurementService.
	/// </summary>
	internal static class MeasurementService
	{
		
		
		public static Size Measure (IExportText item,Graphics graphics) {
			Console.WriteLine("Measure {0}",item.Text);
			if (!item.CanGrow) {
				return item.Size;
			}
			
			var sf = new StringFormat();
			sf.FormatFlags = StringFormatFlags.MeasureTrailingSpaces;
			if (!String.IsNullOrEmpty(item.Text)) {
				SizeF size = graphics.MeasureString(item.Text.TrimEnd(),
				                                    item.Font,
				                                    item.Size.Width,sf);
				
//				var i = (int)size.Height/item.Font.Height;
//				var x = i * item.Font.Height;
				if (size.Height < item.Size.Height) {
					return item.Size;
				}
				return new Size(item.Size.Width,(int)Math.Ceiling(size.Height));
			}
			
			return item.Size;
		}
	}
}