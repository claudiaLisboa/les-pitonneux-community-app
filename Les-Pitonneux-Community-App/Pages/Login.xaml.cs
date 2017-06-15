using System;
using Xamarin.Forms;

namespace LesPitonneuxCommunityApp
{
    public partial class Login : ContentPage
    {
		public Login()
        {
            InitializeComponent();
            this.BackgroundColor = Color.FromHex("DF7401");
        }

		static double _ScreenHeight;
        public static double ScreenHeight
        {
            get { return _ScreenHeight; }
        }

        public static void SaveScreenHeight(double height)
        {
            _ScreenHeight = height;
        }

        static double _ScreenWidth;
        public static double ScreenWidth
        {
            get { return _ScreenWidth; }
        }

        public static void SaveScreenWidth(double width)
        {
            _ScreenWidth = width;
        }

		protected override void OnAppearing()
		{
			base.OnAppearing();
			LoadLayout();
		}

        protected void LoadLayout()
        {
            stkPageLogin.Children.Clear();

			RelativeLayout layoutPage = new RelativeLayout();

			#region Background image
			var imgBackground = new Image()
			{
				Source = "Background_LesPitonneux.jpg",
				Aspect = Aspect.AspectFill,
				HeightRequest = Login.ScreenHeight,
				WidthRequest = Login.ScreenWidth
			};

			layoutPage.Children.Add(imgBackground,
				Constraint.Constant(0),
				Constraint.Constant(0));
			#endregion

			#region Login buttons
			double btnWidth = 0;
			btnWidth = Login.ScreenWidth - 200;
			double btnHeight = 0;
			btnHeight = Login.ScreenHeight / 6;

			// Google button
			var imgButtonGoogle = new Image()
			{
				Source = "buttonLoginGoogle.png",
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				WidthRequest = btnWidth
			};
			// Slack button
			var imgButtonSlack = new Image()
			{
				Source = "buttonLoginSlack.png",
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				WidthRequest = btnWidth
			};

			// From https://stackoverflow.com/questions/40942691/xamarin-forms-how-to-center-views-using-relative-layout-width-and-height-r
			Func<RelativeLayout, double> getButtonGoogleWidth = (p) => imgButtonGoogle.Measure(layoutPage.Width, layoutPage.Height).Request.Width;
			Func<RelativeLayout, double> getButtonGoogleHeight = (p) => imgButtonGoogle.Measure(layoutPage.Width, layoutPage.Height).Request.Height;
			Func<RelativeLayout, double> getButtonSlackWidth = (p) => imgButtonSlack.Measure(layoutPage.Width, layoutPage.Height).Request.Width;
			Func<RelativeLayout, double> getButtonSlackHeight = (p) => imgButtonSlack.Measure(layoutPage.Width, layoutPage.Height).Request.Height;

			// Adding the Google button to the center of the screen.
			layoutPage.Children.Add(imgButtonGoogle,
                Constraint.RelativeToParent((parent) => (parent.Width * .5) - (getButtonGoogleWidth(parent) * .5)),
	            Constraint.RelativeToParent((parent) => (parent.Height * .80) - (getButtonGoogleHeight(parent) * .5))
			);
			// Adding the Slack button below the Google button.
			layoutPage.Children.Add(imgButtonSlack,
                Constraint.RelativeToParent((parent) => (parent.Width * .5) - (getButtonSlackWidth(parent) * .5)),
				Constraint.RelativeToView(imgButtonGoogle, (parent, view) => view.Y + getButtonGoogleHeight(parent) + 20)
			);

            // Gesture for the buttons.
			var tapGesture = new TapGestureRecognizer();
			tapGesture.NumberOfTapsRequired = 1;
			tapGesture.Tapped += (sender, e) =>
			{
				//Navigation.PushModalAsync(new Profile());
				Application.Current.MainPage = new Profile();
				Application.Current.MainPage.Navigation.PopModalAsync(false);
			};

            // Assigning the gesture to the buttons.
            imgButtonGoogle.GestureRecognizers.Add(tapGesture);
            imgButtonSlack.GestureRecognizers.Add(tapGesture);
			#endregion

			stkPageLogin.Children.Add(layoutPage);
		}
	}
}