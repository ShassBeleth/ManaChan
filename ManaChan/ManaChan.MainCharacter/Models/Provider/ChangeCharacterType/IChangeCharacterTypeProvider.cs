using System.ComponentModel;
using ManaChan.MainCharacter.Enums;

namespace ManaChan.MainCharacter.Models {

	/// <summary>
	/// キャラクター種別値購読者
	/// </summary>
	public interface IChangeCharacterTypeProvider : INotifyPropertyChanged {

		/// <summary>
		/// キャラクター種別
		/// </summary>
		CharacterType Value { get; }

	}

}
