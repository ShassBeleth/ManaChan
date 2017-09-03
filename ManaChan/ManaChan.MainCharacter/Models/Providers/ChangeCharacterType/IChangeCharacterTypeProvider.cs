using System.ComponentModel;
using ManaChan.Infrastructure.Enums;

namespace ManaChan.MainCharacter.Models.Providers.ChangeCharacterType {

	/// <summary>
	/// キャラクター種別値購読者
	/// </summary>
	public interface IChangeCharacterTypeProvider : INotifyPropertyChanged {

		/// <summary>
		/// キャラクター種別
		/// </summary>
		CharacterType CharacterType { get; }
		
	}

}
