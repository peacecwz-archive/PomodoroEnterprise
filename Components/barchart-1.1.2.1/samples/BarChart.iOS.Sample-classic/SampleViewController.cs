using System;
using System.Collections.Generic;

#if __UNIFIED__
using UIKit;
using Foundation;
using CoreGraphics;
using CoreAnimation;

#else
using System.Drawing;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using MonoTouch.CoreAnimation;
using MonoTouch.CoreGraphics;
using CGRect = global::System.Drawing.RectangleF;
using CGSize = global::System.Drawing.SizeF;
using CGPoint = global::System.Drawing.PointF;
using nfloat = global::System.Single;
#endif

using BarChart;

namespace iOS.Sample
{
	public partial class SampleViewController : UIViewController
	{
		const float BarChartTopMargin = 5f;
		const float BarChartBottomMargin = 50f;
		const float BarChartHorizontalMargin = 30f;

		BarChartView barChart;
		UIImageView imageView;

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			using (var image = UIImage.FromBundle("back.png"))
			{
				imageView = new UIImageView(image);
				imageView.Frame = View.Frame;
				imageView.AutoresizingMask = UIViewAutoresizing.FlexibleDimensions;
				View.AddSubview(imageView);
			}

			barChart = new BarChartView ();
//			barChart.MinimumValue = -50000f;
//			barChart.MaximumValue = 50000f;
//			barChart.BarColor = UIColor.Green;
			barChart.BarOffset = 2f;
			barChart.BarWidth = 40f;
			barChart.BarCaptionInnerColor = UIColor.White;
			barChart.BarCaptionInnerShadowColor = UIColor.Black;
			barChart.BarCaptionOuterColor = UIColor.Black;
			barChart.BarCaptionOuterShadowColor = UIColor.White;

			barChart.BarClick += OnBarClick;
			barChart.Frame = new CGRect (
				BarChartHorizontalMargin, 
				BarChartTopMargin,
				View.Bounds.Width - 2 * BarChartHorizontalMargin,
				View.Bounds.Height - BarChartTopMargin - BarChartBottomMargin);

			View.AddSubview (barChart);


			UIButton randomize = new UIButton ();
			randomize.Frame = new CGRect (
				BarChartHorizontalMargin, 
				barChart.Frame.Bottom + BarChartTopMargin, 
				barChart.Frame.Width,
				BarChartBottomMargin - BarChartTopMargin - BarChartTopMargin);
			randomize.BackgroundColor = UIColor.DarkGray;
			randomize.AutoresizingMask = UIViewAutoresizing.FlexibleMargins;
			randomize.SetTitle ("Randomize Data", UIControlState.Normal);
			randomize.TouchUpInside += delegate {
				barChart.ItemsSource = GenerateTestData ();
			};
			View.AddSubview (randomize);


			barChart.ItemsSource = GenerateTestData ();

//			barChart.AddLevelIndicator (0f, "0");
//			barChart.AddLevelIndicator (100f, "100");
//			barChart.AddLevelIndicator (-100f, "-100");

//			barChart.GridHidden = true;
//			barChart.LegendHidden = true;
//			barChart.LevelsHidden = true;
		}

		void OnBarClick (object sender, BarClickEventArgs e)
		{
			Console.WriteLine ("bar clicked: name = {0}, value = {1}", e.Bar.Legend, e.Bar.Value);
		}

		public List<BarModel> GenerateTestData ()
		{
			var models = new List<BarModel> ();

			var rnd = new Random ((int)DateTime.UtcNow.Ticks);

			for (var i = 0; i < rnd.Next (10) + 5; i += 1) {
				models.Add (new BarModel () { Value = rnd.Next (-5000, 5000), Color = UIColor.Gray, Legend = "1H" });
				models.Add (new BarModel () { Value = rnd.Next (-5000, 5000), Color = UIColor.Brown, Legend = "6H" });
				models.Add (new BarModel () { Value = rnd.Next (-5000, 5000), Color = UIColor.Gray, Legend = "12H" });
				models.Add (new BarModel () { Value = rnd.Next (-5000, 5000), Legend = "24H" });			
				models.Add (new BarModel () { Value = rnd.Next (-5000, 5000), Legend = "32H" });
			}

			return models;
		}

		public override void ViewDidLayoutSubviews ()
		{
			base.ViewDidLayoutSubviews ();

			barChart.Frame = new CGRect (
				BarChartHorizontalMargin, 
				BarChartTopMargin, 
				View.Bounds.Width - 2 * BarChartHorizontalMargin,
				View.Bounds.Height - BarChartTopMargin - BarChartBottomMargin);
		}
	}
}
