using System;
using System.Linq;
using Foundation;
using PokeApp.CustomControls;
using PokeApp.Models;
using UIKit;

namespace PokeApp.iOS.ListViewSources
{
    public class CustomListViewSource : UITableViewSource
    {
        private static readonly NSString CellIdentifier = new NSString("CustomListViewItem");

        private readonly CustomListView listView;

        public CustomListViewSource(CustomListView listView)
        {
            this.listView = listView;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell(CellIdentifier) as CustomListViewCell;

            if (cell == null)
            {
                cell = new CustomListViewCell(CellIdentifier);
            }

            var item = listView.ItemsSource.Cast<CustomListViewItem>().ElementAt(indexPath.Row);

            cell.UpdateCell(item);

            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return listView.ItemsSource.Cast<CustomListViewItem>().Count();
        }
    }

    public class CustomListViewCell : UITableViewCell
    {
        private readonly UILabel nameLabel;
        private readonly UILabel idLabel;
        private readonly UIImageView imageView;

        public CustomListViewCell(NSString cellIdentifier)
            : base(UITableViewCellStyle.Default, cellIdentifier)
        {
            SelectionStyle = UITableViewCellSelectionStyle.Gray;

            ContentView.BackgroundColor = UIColor.FromRGB(218, 255, 127);

            imageView = new UIImageView();

            nameLabel = new UILabel()
            {
                Font = UIFont.FromName("Cochin-BoldItalic", 22f),
                TextColor = UIColor.FromRGB(127, 51, 0),
                BackgroundColor = UIColor.Clear
            };

            idLabel = new UILabel()
            {
                Font = UIFont.FromName("AmericanTypewriter", 12f),
                TextColor = UIColor.FromRGB(38, 127, 0),
                TextAlignment = UITextAlignment.Center,
                BackgroundColor = UIColor.Clear
            };

            ContentView.Add(nameLabel);
            ContentView.Add(idLabel);
            ContentView.Add(imageView);
        }

        public void UpdateCell(CustomListViewItem item)
        {
            nameLabel.Text = item.Name;
            idLabel.Text = item.Id.ToString();
            imageView.Image = LoadImage(item.ImageUrl);
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();

            nameLabel.Frame = new CoreGraphics.CGRect(5, 4, ContentView.Bounds.Width - 63, 25);
            idLabel.Frame = new CoreGraphics.CGRect(100, 18, 100, 20);
            imageView.Frame = new CoreGraphics.CGRect(ContentView.Bounds.Width - 63, 5, 33, 33);
        }

        private static UIImage LoadImage(string uri)
        {
            using (var url = new NSUrl(uri))
            {
                using (var data = NSData.FromUrl(url))
                {
                    return UIImage.LoadFromData(data);
                }
            }
        }
    }
}
