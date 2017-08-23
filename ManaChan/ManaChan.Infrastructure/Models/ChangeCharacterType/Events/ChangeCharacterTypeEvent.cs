using ManaChan.Infrastructure.Enums;

namespace ManaChan.Infrastructure.Models.ChangeCharacterType.Events {

	/// <summary>
	/// キャラクター種別変更時イベント
	/// </summary>
	public class ChangeCharacterTypeEvent {

		/// <summary>
		/// キャラクター種別
		/// </summary>
		public CharacterType Value { set; get; }

	}

}
