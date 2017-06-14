using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using LesPitonneuxCommunityApp;
using LesPitonneuxCommunityApp.Droid;
using Xamarin.Auth;
using Android.App;
using Android.Net;

[assembly: ExportRenderer(typeof(Login.LoginFacebook), typeof(LoginRendererFacebook))]
[assembly: ExportRenderer(typeof(Login), typeof(LoginRenderer))]

namespace LesPitonneuxCommunityApp.Droid
{
	public class LoginRenderer : PageRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Page> e)
		{
			base.OnElementChanged(e);

			var activity = this.Context as Activity;

			if (LPConnection.DetectNetwork(activity))
			{
				Login.SaveConnectionError(false);
			}
			else
			{
				Login.SaveConnectionError(true);
			}
		}
	}

	public class LoginRendererFacebook : PageRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Page> e)
		{
			base.OnElementChanged(e);

			var activity = this.Context as Activity;

			if (LPConnection.DetectNetwork(activity))
			{

				var auth = new OAuth2Authenticator(
							  clientId: "1730746240513468",
							  scope: "",
							  authorizeUrl: new System.Uri("https://m.facebook.com/dialog/oauth/"),
							  redirectUrl: new System.Uri("http://www.facebook.com/connect/login_success.html")
						  );

				try
				{
					auth.Completed += (sender, eventArgs) =>
					{
						if (eventArgs.IsAuthenticated)
						{
							// Use eventArgs.Account to do wonderful things
							Usuario.SaveUserToken(eventArgs.Account.Properties["access_token"]);

							//Salvar conta do usuario na aplicacao
							//AccountStore.Create (activity).Save (eventArgs.Account, "Facebook");
							//App.Current.Properties ["id"] = eventArgs.Account.Properties ["access_token"];

							var request = new OAuth2Request("GET", new System.Uri("https://graph.facebook.com/me?fields=email,bio,name,picture.type(normal)"), null, eventArgs.Account);
							request.GetResponseAsync().ContinueWith(t =>
							{
								if (!t.IsFaulted)
								{

									Usuario.SaveUserJson(t.Result.GetResponseText());

									UsuarioModel user = Usuario.CadastroUsuarioSocial();

									if (user.IdSocial != null)
									{

										//Verifica usuario
										if (!APIUsuario.GetUserByIdSocial(user.IdSocial))
										{
											//Salvar usuario
											APIUsuario.CreateUserFacebook(user);
											Login.SaveSuccessLogin(1);
											Login.SaveAuthenticateLogin(true);
											//Login.FecharTelaAutenticacao.Invoke();
										}
										else
										{
											Login.SaveSuccessLogin(1);
											Login.FecharTelaAutenticacao();
											//Login.RedirecionarTelaAutenticacao();
											//Login.SaveAuthenticateLogin(true);
											//Login.FecharTelaAutenticacao.Invoke();
										}
									}
									else
									{
										Login.SaveSuccessLogin(2);
										Login.FecharTelaAutenticacao();
									}

								}
							});

							Login.SaveAuthenticateLogin(true);

						}
						else
						{
							//Dispose();

							// The user cancelled
							Login.FecharTelaAutenticacao();
						}
					};
				}
				catch (Exception ex)
				{
					var x = ex.Message;
				}
				activity.StartActivity(auth.GetUI(activity));
			}
			else
			{
				Login.SaveErroConexao(true);
			}
		}
	}
}



//using System;
//using Xamarin.Forms;
//using Xamarin.Forms.Platform.Android;
//using LesPitonneuxCommunityApp;
//using LesPitonneuxCommunityApp.Droid;
//using Android.App;
//using Android.Net;

//[assembly: ExportRenderer(typeof(Login), typeof(LoginRenderer))]

//namespace LesPitonneuxCommunityApp.Droid
//{
//	public class LoginRenderer : PageRenderer
//	{
//		protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Page> e)
//		{
//			base.OnElementChanged(e);

//			var activity = this.Context as Activity;
//		}
//	}
//}
