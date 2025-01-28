using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ShopProductManagerApp
{
    public class TextBoxWithPlaceholder : TextBox
    {
        public static readonly DependencyProperty PlaceholderProperty =
            DependencyProperty.Register("Placeholder", typeof(string), typeof(TextBoxWithPlaceholder), new PropertyMetadata(string.Empty));

        public string Placeholder
        {
            get { return (string)GetValue(PlaceholderProperty); }
            set { SetValue(PlaceholderProperty, value); }
        }

        protected override void OnGotFocus(RoutedEventArgs e)
        {
            base.OnGotFocus(e);

            if (Text.Equals(Placeholder))
            {
                Text = string.Empty;
                Foreground = System.Windows.Media.Brushes.Black;
            }
        }

        protected override void OnLostFocus(RoutedEventArgs e)
        {
            base.OnLostFocus(e);

            if (string.IsNullOrEmpty(Text))
            {
                Text = Placeholder;
                Foreground = System.Windows.Media.Brushes.Gray;
            }
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            Text = Placeholder;
            Foreground = System.Windows.Media.Brushes.Gray;
        }
    }
}
