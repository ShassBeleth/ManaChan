using ManaChan.Infrastructure.Enums;

namespace ManaChan.Infrastructure.Models.Events.ChangeCharacterEmotionTypeEvent {

	/// <summary>
	/// キャラクター表情種別変更時イベント
	/// </summary>
	public class ChangeCharacterEmotionTypeEventValue {

		/// <summary>
		/// キャラクター表情種別
		/// </summary>
		public CharacterEmotionType CharacterEmotionType { set; get; }

	}

}
