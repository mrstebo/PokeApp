using System.Linq;
using Android.App;
using Android.Graphics.Drawables;
using Android.Views;
using Android.Widget;
using PokeApp.CustomControls;
using PokeApp.Models;
using Square.Picasso;

namespace PokeApp.Droid.ListAdapters
{
    public class CustomListViewAdapter : BaseAdapter
    {
        private readonly Activity context;
        private readonly CustomListView listView;

        public CustomListViewAdapter(Activity context, CustomListView listView)
        {
            this.context = context;
            this.listView = listView;
        }

        public override int Count => listView?.ItemsSource.Cast<CustomListViewItem>().Count() ?? 0;

        public override Java.Lang.Object GetItem(int position)
        {
            return listView.ItemsSource.Cast<CustomListViewItem>().ElementAt(position).Name;
        }

        public override long GetItemId(int position)
        {
            return listView.ItemsSource.Cast<CustomListViewItem>().ElementAt(position).Id;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = listView.ItemsSource.Cast<CustomListViewItem>().ElementAt(position);
            var view = convertView ?? context.LayoutInflater.Inflate(Resource.Layout.CustomListViewCell, null);
            var imageView = view.FindViewById<ImageView>(Resource.Id.custom_list_view_cell_image);

            view.FindViewById<TextView>(Resource.Id.custom_list_view_cell_title).Text = item.Name;
            view.FindViewById<TextView>(Resource.Id.custom_list_view_cell_caption).Text = item.Id.ToString();

            // grab the old image and dispose of it
            if (imageView.Drawable != null)
            {
                using (var image = imageView.Drawable as BitmapDrawable)
                {
                    if (image != null)
                    {
                        if (image.Bitmap != null)
                        {
                            //image.Bitmap.Recycle ();
                            image.Bitmap.Dispose();
                        }
                    }
                }
            }

            if (!string.IsNullOrWhiteSpace(item.ImageUrl))
            {
                Picasso.Get()
                    .Load(Android.Net.Uri.Parse(item.ImageUrl))
                    .Fit()
                    .CenterCrop()
                    .Placeholder(Resource.Drawable.abc_ic_star_black_48dp)
                    .Into(imageView);
            }
            else
            {
                // clear the image
                imageView.SetImageBitmap(null);
            }

            return view;
        }
    }
}
