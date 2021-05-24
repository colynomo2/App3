using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.Content;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace App3
{
    public class SwipeToDeleteCallback : Android.Support.V7.Widget.Helper.ItemTouchHelper.SimpleCallback
    {
        private Context context;
        private Products madapter;
        private Android.Graphics.Drawables.Drawable deleteIcon;
        private int intrinsicWidth;
        private int intrinsicHeight;
        private Android.Graphics.Drawables.ColorDrawable background;
        private Color backgroundColor;
        private Paint clearPaint;

        public SwipeToDeleteCallback(int dragDirs, int swipeDirs, Context context) : base(dragDirs, swipeDirs)
        {
            this.context = context;
            deleteIcon = ContextCompat.GetDrawable(context, Resource.Drawable.notification_template_icon_bg);
            intrinsicWidth = deleteIcon.IntrinsicWidth;
            intrinsicHeight = deleteIcon.IntrinsicHeight;
            background = new Android.Graphics.Drawables.ColorDrawable();
            backgroundColor = Color.ParseColor("#f44336");
            clearPaint = new Paint();
            clearPaint.SetXfermode(new PorterDuffXfermode(PorterDuff.Mode.Clear));
        }

        public SwipeToDeleteCallback(int dragDirs, int swipeDirs, Context context, Products mRecyclerView) : this(dragDirs, swipeDirs, context)
        {
            this.context = context;
            this.madapter = mRecyclerView;
            deleteIcon = ContextCompat.GetDrawable(context, Resource.Drawable.navigation_empty_icon);
            intrinsicWidth = deleteIcon.IntrinsicWidth;
            intrinsicHeight = deleteIcon.IntrinsicHeight;
            background = new Android.Graphics.Drawables.ColorDrawable();
            backgroundColor = Color.ParseColor("#f44336");
            clearPaint = new Paint();
            clearPaint.SetXfermode(new PorterDuffXfermode(PorterDuff.Mode.Clear));
        }

        public override int GetMovementFlags(RecyclerView recyclerView, RecyclerView.ViewHolder viewHolder)
        {
            if (viewHolder.AdapterPosition == 10)
            {
                return 0;
            }
            return base.GetMovementFlags(recyclerView, viewHolder);
        }

        public override void OnChildDraw(Canvas c, RecyclerView recyclerView, RecyclerView.ViewHolder viewHolder, float dX, float dY, int actionState, bool isCurrentlyActive)
        {
            base.OnChildDraw(c, recyclerView, viewHolder, dX, dY, actionState, isCurrentlyActive);
        }

        public override bool OnMove(RecyclerView recyclerView, RecyclerView.ViewHolder viewHolder, RecyclerView.ViewHolder target)
        {
            //throw new NotImplementedException();
            return false;
        }

        public override void OnChildDrawOver(Canvas c, RecyclerView recyclerView, RecyclerView.ViewHolder viewHolder, float dX, float dY, int actionState, bool isCurrentlyActive)
        {
            var itemView = viewHolder.ItemView;
            var itemHeight = itemView.Bottom - itemView.Top;
            var isCanceled = dX == 0f && !isCurrentlyActive;

            if (isCanceled)
            {
                clearCanvas(c, itemView.Right + dX, (float)itemView.Top, (float)itemView.Right, (float)itemView.Bottom);
                base.OnChildDrawOver(c, recyclerView
                    , viewHolder, dX, dY, actionState, isCurrentlyActive);
                return;
            }
            background.Color = backgroundColor;
            background.SetBounds(itemView.Right + (int)dX, itemView.Top, itemView.Right, itemView.Bottom);
            background.Draw(c);

            var deleteIconTop = itemView.Top + (itemHeight - intrinsicHeight) / 2;
            var deleteIconMargin = (itemHeight - intrinsicHeight) / 2;
            var deleteIconLeft = itemView.Right - deleteIconMargin - intrinsicWidth;
            var deleteIconRight = itemView.Right - deleteIconMargin;
            var deleteIconBottom = deleteIconTop + intrinsicHeight;

            deleteIcon.SetBounds(deleteIconLeft, deleteIconTop, deleteIconRight, deleteIconBottom);
            deleteIcon.Draw(c);

            base.OnChildDrawOver(c, recyclerView, viewHolder, dX, dY, actionState, isCurrentlyActive);
        }

        private void clearCanvas(Canvas c, float v, float top, float right, float bottom)
        {
            c.DrawRect(v, top, right, bottom, clearPaint);
        }

        public override void OnSwiped(RecyclerView.ViewHolder viewHolder, int direction)
        {
            //Invoke Removing Item method from adapter
            RecycleActivity.itemsAdapter.delete(viewHolder.AdapterPosition);
            
            
            
        }

        public override void ClearView(RecyclerView recyclerView, RecyclerView.ViewHolder viewHolder)
        {
            base.ClearView(recyclerView, viewHolder);
        }

       
    }
    public class SwipeToEditCallback : Android.Support.V7.Widget.Helper.ItemTouchHelper.SimpleCallback
    {
        private Context context;
        private Products madapter;
        private Android.Graphics.Drawables.Drawable deleteIcon;
        private int intrinsicWidth;
        private int intrinsicHeight;
        private Android.Graphics.Drawables.ColorDrawable background;
        private Color backgroundColor;
        private Paint clearPaint;
        private ItemsAdapter itemsAdapter;
        static int buttonWidth = 200;

        public SwipeToEditCallback(int dragDirs, int swipeDirs, Context context) : base(dragDirs, swipeDirs)
        {
            this.context = context;
            deleteIcon = ContextCompat.GetDrawable(context, Resource.Drawable.notification_template_icon_bg);
            intrinsicWidth = deleteIcon.IntrinsicWidth;
            intrinsicHeight = deleteIcon.IntrinsicHeight;
            background = new Android.Graphics.Drawables.ColorDrawable();
            backgroundColor = Color.ParseColor("#f44336");
            clearPaint = new Paint();
            clearPaint.SetXfermode(new PorterDuffXfermode(PorterDuff.Mode.Clear));
        }

        public SwipeToEditCallback(int dragDirs, int swipeDirs, Context context, Products mRecyclerView,ItemsAdapter itemsAdapter) : this(dragDirs, swipeDirs, context)
        {
            this.context = context;
            this.madapter = mRecyclerView;
            this.itemsAdapter = itemsAdapter;
            deleteIcon = ContextCompat.GetDrawable(context, Resource.Drawable.navigation_empty_icon);
            intrinsicWidth = deleteIcon.IntrinsicWidth;
            intrinsicHeight = deleteIcon.IntrinsicHeight;
            background = new Android.Graphics.Drawables.ColorDrawable();
            backgroundColor = Color.ParseColor("#f44300");
            clearPaint = new Paint();
            clearPaint.SetXfermode(new PorterDuffXfermode(PorterDuff.Mode.Clear));
            
        }

        public override int GetMovementFlags(RecyclerView recyclerView, RecyclerView.ViewHolder viewHolder)
        {
            if (viewHolder.AdapterPosition == 10)
            {
                return 0;
            }
            return base.GetMovementFlags(recyclerView, viewHolder);
        }

        public override void OnChildDraw(Canvas c, RecyclerView recyclerView, RecyclerView.ViewHolder viewHolder, float dX, float dY, int actionState, bool isCurrentlyActive)
        {
            base.OnChildDraw(c, recyclerView, viewHolder, dX/ 10, dY, actionState, isCurrentlyActive);
        }

        public override bool OnMove(RecyclerView recyclerView, RecyclerView.ViewHolder viewHolder, RecyclerView.ViewHolder target)
        {
            //throw new NotImplementedException();
            return false;
        }

        public override void OnChildDrawOver(Canvas c, RecyclerView recyclerView, RecyclerView.ViewHolder viewHolder, float dX, float dY, int actionState, bool isCurrentlyActive)
        {
            var itemView = viewHolder.ItemView;
            var itemHeight = itemView.Bottom - itemView.Top;
            var isCanceled = dX == 0f && !isCurrentlyActive;

            if (isCanceled)
            {
                clearCanvas(c, itemView.Left + dX, (float)itemView.Top, (float)itemView.Left, (float)itemView.Bottom);
                base.OnChildDrawOver(c, recyclerView
                    , viewHolder, dX/ 10, dY, actionState, isCurrentlyActive);
                return;
            }
           

           
                float buttonWidthWithoutPadding = buttonWidth - 20;
                float corners = 32;
            Button delete = ((ItemHolder)viewHolder).hiddenDelete;
            Button edit = ((ItemHolder)viewHolder).hiddenEdit;
            delete.SetWidth((int)dX / 6);
            var layoutParamDelete = delete.LayoutParameters;
            var layoutParamEdit = edit.LayoutParameters;
            delete.LayoutParameters.Width = (int)dX / 20;
            edit.LayoutParameters.Width = (int)dX / 20;
            
            
            //     Paint p = new Paint();


            //     RectF leftButton = new RectF(itemView.Left, itemView.Top, dX/6, itemView.Bottom);
            //     p.Color=Color.Orange;
            //     c.DrawRoundRect(leftButton, corners, corners, p);

            //drawText("EDIT", c, leftButton, p);

            //     RectF rightButton = new RectF(itemView.Left + leftButton.Width(), itemView.Top, dX/3, itemView.Bottom);
            //     p.Color=Color.Red;
            //     c.DrawRoundRect(rightButton, corners, corners, p);
            //     drawText("DELETE", c, rightButton, p);









            base.OnChildDrawOver(c, recyclerView, viewHolder, dX/10, dY, actionState, isCurrentlyActive);
        }

        private void ItemView_Touch(object sender, View.TouchEventArgs e)
        {
            string x = "";
            x += "x:" + e.Event.XPrecision;
            x += "y:" + e.Event.YPrecision;
            Toast.MakeText(context,x ,ToastLength.Long);
            
        }

        private void drawText(String text, Canvas c, RectF button, Paint p)
        {
            float textSize = 30;
            p.Color=Color.White;
            p.AntiAlias=true;
            p.TextSize=textSize;

            float textWidth = p.MeasureText(text);
            c.DrawText(text, button.CenterX() - (textWidth / 2), button.CenterY() + (textSize / 2), p);
        }

        private void clearCanvas(Canvas c, float v, float top, float right, float bottom)
        {
            c.DrawRect(v, top, right, bottom, clearPaint);
        }

        public override void OnSwiped(RecyclerView.ViewHolder viewHolder, int direction)
        {
            //Invoke Removing Item method from adapter
            //itemsAdapter.edit(viewHolder.AdapterPosition);
          


        }

        public override void ClearView(RecyclerView recyclerView, RecyclerView.ViewHolder viewHolder)
        {
            base.ClearView(recyclerView, viewHolder);
        }


    }
}