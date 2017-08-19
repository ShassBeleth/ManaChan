﻿using ManaChan.MainCharacter.Enums;

namespace ManaChan.MainCharacter.Events.ChangeCharacterType {

	/// <summary>
	/// キャラクター種別変更時イベント
	/// </summary>
	public class ChangeCharacterTypeEvent {

		/// <summary>
		/// キャラクター種別
		/// </summary>
		public CharacterType Value { get; set; }

	}

}
