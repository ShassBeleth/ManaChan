using ManaChan.Infrastructure.Enums;
using System.ComponentModel;

namespace ManaChan.MainCharacter.Models.Providers.ChangeCharacterEmotionType {

	/// <summary>
	/// キャラクター表情種別値購読者
	/// </summary>
	public interface IChangeCharacterEmotionTypeProvider : INotifyPropertyChanged{

		/// <summary>
		/// キャラクター表情種別
		/// </summary>
		CharacterEmotionType CharacterEmotionType { get; }

	}

}
