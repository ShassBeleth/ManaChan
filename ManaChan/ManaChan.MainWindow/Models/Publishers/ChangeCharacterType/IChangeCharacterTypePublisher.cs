using ManaChan.Infrastructure.Enums;

namespace ManaChan.MainWindow.Models.Publishers.ChangeCharacterType {

	/// <summary>
	/// キャラクター種別値発行者
	/// </summary>
	public interface IChangeCharacterTypePublisher {

		/// <summary>
		/// キャラクター種別発行
		/// </summary>
		/// <param name="characterType">キャラクター種別</param>
		void Publish( CharacterType characterType );
		
	}

}
