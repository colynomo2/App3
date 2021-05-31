using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace App3
{
    internal class IamgeHolder: RecyclerView.ViewHolder
    {
        private View itemView;
        public ImageButton ImageButton { get; private set; }
        public int position;
        public IamgeHolder(View itemView) : base(itemView)
        {
            this.itemView = itemView;
            ImageButton = itemView.FindViewById<ImageButton>(Resource.Id.imageButton);
            ImageButton.Click += ImageButton_Click;

        }

        private void ImageButton_Click(object sender, System.EventArgs e)
        {
            Gallery.viewPager.SetCurrentItem(Position,true);
            Gallery.viewPager.Visibility = ViewStates.Visible;
            Gallery.mRecyclerView.Visibility = ViewStates.Gone;

        }
    }
}