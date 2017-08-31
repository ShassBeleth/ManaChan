using ManaChan.Infrastructure.Enums;

namespace ManaChan.Infrastructure.Models.Passer.Events {

	/// <summary>
	/// イベント
	/// </summary>
	public class EventOfPasser {

		/// <summary>
		/// キャラクター種別
		/// </summary>
		public CharacterType CharacterType { set; get; }

		/// <summary>
		/// PINコード
		/// </summary>
		public int PinCode { set; get; }

	}

}
