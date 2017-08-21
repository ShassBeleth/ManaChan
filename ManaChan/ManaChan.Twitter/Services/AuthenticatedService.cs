using CoreTweet;
using System;
using System.Configuration;
using System.Text;
using static CoreTweet.OAuth;

namespace ManaChan.Twitter.Services {

	/// <summary>
	/// Twitter認証クラス
	/// </summary>
	public class AuthenticatedService : IAuthenticatedService {

		/// <summary>
		/// コンシューマーキー
		/// </summary>
		private string ConsumerKey { get; }

		/// <summary>
		/// シークレットキー
		/// </summary>
		private string ConsumerSecret { get; }

		/// <summary>
		/// OAuthセッション情報
		/// </summary>
		private OAuthSession Session { set; get; }

		/// <summary>
		/// トークン
		/// </summary>
		public Tokens Token { private set; get; }

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public AuthenticatedService() {
			
			this.ConsumerKey = Encoding.GetEncoding( "UTF-8" ).GetString( Convert.FromBase64String( ConfigurationManager.AppSettings[ "ConsumerKey" ] ) );
			this.ConsumerSecret = Encoding.GetEncoding( "UTF-8" ).GetString( Convert.FromBase64String( ConfigurationManager.AppSettings[ "ConsumerSecret" ] ) );
			
		}

		/// <summary>
		/// 認証
		/// </summary>
		public void Authorize() {

			this.Session = OAuth.Authorize( this.ConsumerKey , this.ConsumerSecret );

			// ブラウザを開いてユーザに認証を行わせる
			System.Diagnostics.Process.Start( this.Session.AuthorizeUri.AbsoluteUri );
			
		}

		/// <summary>
		/// PINコードを設定する
		/// </summary>
		/// <param name="pinCode">PINコード</param>
		public void SetPinCode( int pinCode )
			=> this.Token = OAuth.GetTokens( this.Session , pinCode.ToString() );

	}

}
