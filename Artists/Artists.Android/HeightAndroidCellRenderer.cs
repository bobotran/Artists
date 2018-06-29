using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Artists.Droid;
//using Artists.Forms.Platform.Droid;
using Artists.Models;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(HeightCell), typeof(HeightAndroidCellRenderer))]
namespace Artists.Droid
{
    public class HeightAndroidCellRenderer : ViewCellRenderer
    {
        /**
         * Calculated height of the cells in the ListView currently being rendered. 
         * Intended for use only in ListViews with even rows.
         * */
        public static int CurrentCellHeight { get; private set; }
        protected override Android.Views.View GetCellCore(Cell item, Android.Views.View convertView, ViewGroup parent, Context context)
        {
            Android.Views.View cell = base.GetCellCore(item, convertView, parent, context);
            
            cell.Measure(parent.Width, parent.Height);
            //var a = cell.Width;
            //var b = cell.Height;
            //var c = cell.MinimumWidth;
            //var d = cell.MinimumHeight;
            //var e = cell.MeasuredWidth;
            var f = cell.MeasuredHeight;
            //var g = cell.MeasuredWidthAndState;
            //var h = cell.MeasuredHeightAndState;
            CurrentCellHeight = cell.MeasuredHeight;
            return cell;
        }
    }
}