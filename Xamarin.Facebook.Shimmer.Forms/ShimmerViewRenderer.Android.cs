using System;
using System.ComponentModel;

using Android.Animation;
using Android.Content;
using Color = Android.Graphics;
using Android.Runtime;
using Facebook.Shimmer;

using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ShimmerView),typeof(Facebook.Shimmer.Android.ShimmerViewRenderer))]
namespace Facebook.Shimmer.Android
{
    /// <summary>
    /// ShimmerView Implementation
    /// </summary>
    [Preserve(AllMembers = true)]
	public class ShimmerViewRenderer : Xamarin.Forms.Platform.Android.AppCompat.ViewRenderer<ShimmerView, ShimmerFrameLayout>
	{
        private ShimmerFrameLayout _shimmerView;
        private Shimmer.Builder _shimmerBuilder;

#pragma warning disable CS0618 // Type or member is obsolete
        public ShimmerViewRenderer() : base()
#pragma warning restore CS0618 // Type or member is obsolete
        {

        }

        public ShimmerViewRenderer(Context context) : base(context)
        {

        }

        /// <summary>
        ///     Used for registration with dependency service
        /// </summary>
        public static void Init()
        {
#pragma warning disable 0219
            var temp = DateTime.Now;
#pragma warning restore 0219            
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _shimmerBuilder?.Dispose();
            _shimmerView?.Dispose();
            _shimmerBuilder = null;
            _shimmerView = null;
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
                    _shimmerView = new ShimmerFrameLayout(Context);
                    _shimmerBuilder = new Shimmer.AlphaHighlightBuilder();
                    //_shimmerBuilder.SetDirection((int)e.NewElement.Direction);
                    //_shimmerBuilder.SetDuration(e.NewElement.Duration);
                    _shimmerBuilder.SetDuration(1000L);
                    _shimmerBuilder.SetRepeatMode((int)ValueAnimatorRepeatMode.Reverse);
                    _shimmerBuilder.SetAutoStart(e.NewElement.Play);
                    _shimmerView.SetShimmer(_shimmerBuilder?.Build());
                    _shimmerView.SetBackgroundColor(Color.Color.Blue);
                    SetNativeControl(_shimmerView);
                }
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == ShimmerView.PlayProperty.PropertyName)
            {
                if (Element.Play)
                    _shimmerView.StartShimmer();
                else
                    _shimmerView.StopShimmer();
            }
        }
    }
}
