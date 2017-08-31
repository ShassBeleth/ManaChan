using System.ComponentModel;
using ManaChan.Infrastructure.Enums;

namespace ManaChan.Infrastructure.Models.Passer.Providers {

	/// <summary>
	/// キャラクター種別値購読者
	/// </summary>
	public interface IProviderOfPasser : INotifyPropertyChanged {

		/// <summary>
		/// キャラクター種別
		/// </summary>
		CharacterType CharacterType { get; }

		/// <summary>
		/// PINコード
		/// </summary>
		int PinCode { get; }

	}

}
