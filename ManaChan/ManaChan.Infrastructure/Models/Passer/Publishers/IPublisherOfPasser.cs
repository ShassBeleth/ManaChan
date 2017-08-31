using ManaChan.Infrastructure.Enums;

namespace ManaChan.Infrastructure.Models.Passer.Publishers {

	/// <summary>
	/// キャラクター種別値発行者
	/// </summary>
	public interface IPublisherOfPasser {

		/// <summary>
		/// キャラクター種別発行
		/// </summary>
		/// <param name="characterType">キャラクター種別</param>
		void CharacterTypePublish( CharacterType characterType );

		/// <summary>
		/// PINコード発行
		/// </summary>
		/// <param name="pinCode">PINコード</param>
		void PinCodePublish( int pinCode );

	}

}
