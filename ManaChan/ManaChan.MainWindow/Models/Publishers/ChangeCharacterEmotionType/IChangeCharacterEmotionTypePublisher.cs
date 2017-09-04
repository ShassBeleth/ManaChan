using ManaChan.Infrastructure.Enums;

namespace ManaChan.MainWindow.Models.Publishers.ChangeCharacterEmotionType {

	/// <summary>
	/// キャラクター表情種別値発行者
	/// </summary>
	public interface IChangeCharacterEmotionTypePublisher {

		/// <summary>
		/// キャラクター表情種別発行
		/// </summary>
		/// <param name="characterEmotionType">キャラクター表情種別</param>
		void Publish( CharacterEmotionType characterEmotionType );

	}

}
