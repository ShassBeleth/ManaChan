using CoreTweet;

namespace ManaChan.Twitter.Services {

	/// <summary>
	/// Twitter認証インタフェース
	/// </summary>
	public interface IAuthenticatedService {

		/// <summary>
		/// トークン
		/// </summary>
		Tokens Token { get; }

		/// <summary>
		/// 認証
		/// </summary>
		void Authorize();

		/// <summary>
		/// PINコードを設定する
		/// </summary>
		/// <param name="pinCode">PINコード</param>
		void SetPinCode( int pinCode );
		
	}

}
