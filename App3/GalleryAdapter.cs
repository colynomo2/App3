using System.Collections.Generic;
using Android.Graphics;
using Android.Support.V7.Widget;
using Android.Views;

namespace App3
{
    public class GalleryAdapter : RecyclerView.Adapter
    {
        private List<Bitmap> images;
        private RecyclerView mRecyclerView;
        
        public GalleryAdapter(List<Bitmap> images, RecyclerView mRecyclerView)
        {
            this.images = images;
            this.mRecyclerView = mRecyclerView;
        }

        public override int ItemCount => images.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
           IamgeHolder vh = holder as IamgeHolder;
            vh.ImageButton.SetImageBitmap(images[position]);
            vh.position = position;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).
                                    Inflate(Resource.Layout.card3y, parent, false);

            IamgeHolder vh = new IamgeHolder(itemView);
            return vh;
        }
    }
}