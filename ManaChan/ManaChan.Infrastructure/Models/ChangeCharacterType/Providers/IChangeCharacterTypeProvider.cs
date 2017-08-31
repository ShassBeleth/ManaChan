using System.ComponentModel;
using ManaChan.Infrastructure.Enums;

namespace ManaChan.Infrastructure.Models.ChangeCharacterType.Providers {

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
