using System;
using System.Collections;
using System.Text;
using Xamarin.Forms;
using Artists.Models;
using System.Collections.Generic;

namespace Artists.Models
{
    public class HeightListView : ListView
    {
        private int cellHeight;
        public new int RowHeight { get { return base.RowHeight; }
            set { updateCellSize(value); }
        }

        public HeightListView() : base()
        {
        }

        public HeightListView(ListViewCachingStrategy cachingStrategy) :
                base(cachingStrategy)
        {
        }

        public void updateCellSize(object cellwrapper)
        {
            var stacklayout = cellwrapper as StackLayout;
            int newHeight = (int)Math.Ceiling(stacklayout.Height);
            updateCellSize(newHeight);
        }

        public void updateCellSize(int newCellHeight)
        {
            if (newCellHeight != cellHeight)
            {
                cellHeight = newCellHeight;
                updateListViewSize();
            }
        }

        public void updateListViewSize()
        {
            base.RowHeight = cellHeight;
            this.HeightRequest = cellHeight * ((IList)ItemsSource).Count;
        }


    }
}
