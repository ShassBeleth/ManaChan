using Prism.Interactivity.InteractionRequest;

namespace ManaChan.Models {

	/// <summary>
	/// PINコードを入力させるアラート
	/// </summary>
	public class InputPinCodeNotification : Notification {

		/// <summary>
		/// PINコード
		/// </summary>
		public int InputPinCode { set; get; }

	}

}
