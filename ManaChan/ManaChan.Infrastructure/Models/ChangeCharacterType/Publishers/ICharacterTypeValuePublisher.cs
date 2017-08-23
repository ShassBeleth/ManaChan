using ManaChan.Infrastructure.Enums;

namespace ManaChan.Infrastructure.Models.ChangeCharacterType.Publishers {

	/// <summary>
	/// キャラクター種別値発行者
	/// </summary>
	public interface ICharacterTypeValuePublisher {

		/// <summary>
		/// 発行
		/// </summary>
		/// <param name="characterType">キャラクター種別</param>
		void Publish( CharacterType characterType );
	}

}
