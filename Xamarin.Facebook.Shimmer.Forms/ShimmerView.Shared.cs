using System;
using System.Windows.Input;
using System.ComponentModel;

using Xamarin.Forms;

namespace Facebook.Shimmer
{
    /// <summary>
    /// ShimmerView Interface
    /// </summary>
    [DesignTimeVisible(true)]
	public class ShimmerView : ContentView
    {
		public static readonly BindableProperty DirectonProperty = BindableProperty.Create(nameof(Direction), typeof(Direction), typeof(ShimmerView), Direction.LeftToRight);
        public Direction Direction
        {
            get { return (Direction)GetValue(DirectonProperty); }
            set { SetValue(DirectonProperty, value); }
        }

		public static readonly BindableProperty DurationProperty = BindableProperty.Create(nameof(Duration), typeof(int), typeof(ShimmerView), 0);
        public int Duration
        {
            get { return (int)GetValue(DurationProperty); }
            set { SetValue(DurationProperty, value); }
        }

        public static readonly BindableProperty PlayProperty = BindableProperty.Create(nameof(Play), typeof(bool), typeof(ShimmerView), false);
        public bool Play
        {
            get { return (bool)GetValue(PlayProperty); }
            set { SetValue(PlayProperty, value); }
        }

        public ShimmerView()
        {
            IsClippedToBounds = true;
            VerticalOptions = LayoutOptions.FillAndExpand;
            HorizontalOptions = LayoutOptions.FillAndExpand;
        }
    }

    public enum Direction
    {
        LeftToRight = 0,
        RightToLeft = 1,                
        TopToBottom = 2,
        BottomToTop = 3,
    }
}