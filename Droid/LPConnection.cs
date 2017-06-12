using System;
using Android.App;

namespace LesPitonneuxCommunityApp.Droid
{
	public class LPConnection
	{
		public LPConnection()
		{
		}

		public static bool DetectNetwork(Activity activity)
		{

			//var activity = this.Context as Activity;
			//public static bool DetectNetwork()
			//{
			Android.Net.ConnectivityManager connectivityManager = (Android.Net.ConnectivityManager)activity.GetSystemService(Activity.ConnectivityService);
			Android.Net.NetworkInfo activeConnection = connectivityManager.ActiveNetworkInfo;

			//Usado apenas para analisar todos os tipos de conexao.
			//Android.Net.NetworkInfo[] activeConnection1 = connectivityManager.GetAllNetworkInfo();//.ActiveNetworkInfo;

			bool isOnline = (activeConnection != null) && activeConnection.IsConnected;

			if (isOnline)
			{
				// Display the type of connection
				//Android.Net.NetworkInfo.State activeState = activeConnection.GetState ();
				//_connectionType.Text = activeConnection.TypeName;

				// Check for a WiFi connection
				Android.Net.NetworkInfo wifiInfo = connectivityManager.GetNetworkInfo(Android.Net.ConnectivityType.Wifi);
				if (wifiInfo.IsConnected)
				{
					//Wifi connected
					return true;
				}
				else
				{
					//Wifi disconnected
					// Check if roaming or mobile
					Android.Net.NetworkInfo mobileInfo = connectivityManager.GetNetworkInfo(Android.Net.ConnectivityType.Mobile);
					if (mobileInfo.IsRoaming || mobileInfo.IsConnected)
					{
						//roaming or mobile connected.
						return true;
					}
					else
					{
						//roaming or mobile disconnected
						return false;
					}
				}
			}
			else
			{
				return false;
			}
		}

	}
}
