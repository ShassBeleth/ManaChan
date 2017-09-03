using ManaChan.Infrastructure.Enums;

namespace ManaChan.Infrastructure.Models.Events.ChangeCharacterTypeEvent{

	/// <summary>
	/// キャラクター種別変更時イベント
	/// </summary>
	public class ChangeCharacterTypeEventValue {

		/// <summary>
		/// キャラクター種別
		/// </summary>
		public CharacterType CharacterType { set; get; }
		
	}

}
