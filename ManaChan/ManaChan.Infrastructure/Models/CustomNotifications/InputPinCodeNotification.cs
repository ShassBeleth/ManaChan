using Prism.Interactivity.InteractionRequest;

namespace ManaChan.Infrastructure.Models.CustomNotifications {

	/// <summary>
	/// PINコードを入力させるアラート
	/// </summary>
	public class InputPinCodeNotification : Notification {

		/// <summary>
		/// PINコード
		/// </summary>
		public string InputText { set; get; }

	}

}
