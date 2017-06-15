using System;
using System.Collections.Generic;

using Xamarin.Forms;
using XLabs.Forms.Controls;

namespace LesPitonneuxCommunityApp
{
    public partial class Profile : ContentPage
    {
        public Profile()
        {
            InitializeComponent();
			this.BackgroundColor = Color.LightGray;
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			LoadLayout();
		}

        protected void LoadLayout()
        {
            stkPageProfile.Children.Clear();

			RelativeLayout rltPage = new RelativeLayout();

			#region Background image
			//var imgBackground = new Image()
			//{
			//	Source = "Background_LesPitonneux.jpg",
			//	Aspect = Aspect.AspectFill,
			//	HeightRequest = Login.ScreenHeight,
			//	WidthRequest = Login.ScreenWidth
			//};

			//rltPage.Children.Add(imgBackground,
				//Constraint.Constant(0),
				//Constraint.Constant(0));
			#endregion

			var lblTitle = new ExtendedLabel()
			{
				Text = "Build Your Profile",
				TextColor = Color.DarkOliveGreen,
				FontSize = 20,
                FontAttributes = FontAttributes.Bold,
				IsUnderline = true
			};

			Func<RelativeLayout, double> getLblTitleWidth = (p) => lblTitle.Measure(this.Width, this.Height).Request.Width;
			Func<RelativeLayout, double> getLblTitleHeight = (p) => lblTitle.Measure(this.Width, this.Height).Request.Height;

			rltPage.Children.Add(lblTitle,
				Constraint.RelativeToParent((parent) => (parent.Width * .5) - (getLblTitleWidth(parent) * .5)),
				Constraint.RelativeToParent((parent) => (parent.Height * .10) - (getLblTitleHeight(parent) * .5))
			);
			//Constraint.Constant(0),
			//Constraint.Constant(0));

			stkPageProfile.Children.Add(rltPage);
		}
	}
}
