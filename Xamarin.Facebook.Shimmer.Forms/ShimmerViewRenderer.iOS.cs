using System;
using System.Linq;
using System.ComponentModel;

using Foundation;
using Facebook.Shimmer;

using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ShimmerView),typeof(Facebook.Shimmer.iOS.ShimmerViewRenderer))]
namespace Facebook.Shimmer.iOS
{
    /// <summary>
    /// ShimmerView Implementation
    /// </summary>
    [Preserve(AllMembers = true)]
	public class ShimmerViewRenderer : ViewRenderer<ShimmerView, FBShimmeringView>
	{
        private FBShimmeringView _shimmerView;

        /// <summary>
        ///     Used for registration with dependency service
        /// </summary>
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
        public static void Init()
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword
        {
#pragma warning disable 0219
            var temp = DateTime.Now;
#pragma warning restore 0219
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _shimmerView?.Dispose();
            _shimmerView = null;
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
        }

        protected override void OnElementChanged(ElementChangedEventArgs<ShimmerView> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {

            }

            if (e.NewElement != null)
            {
                if (Control == null)
                {
                    _shimmerView = new FBShimmeringView();
                    SetNativeControl(_shimmerView);
                }

                _shimmerView.Shimmering = (e.NewElement as ShimmerView).Play;
                _shimmerView.ShimmeringSpeed = (e.NewElement as ShimmerView).Duration;
                _shimmerView.ShimmeringDirection = (FBShimmerDirection)(e.NewElement as ShimmerView).Direction;
                _shimmerView.ContentView = Subviews.FirstOrDefault();
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (Element == null)
                return;

            if (e.PropertyName == ShimmerView.PlayProperty.PropertyName)
            {
                _shimmerView.Shimmering = (Element as ShimmerView).Play;
            }            
        }
    }
}