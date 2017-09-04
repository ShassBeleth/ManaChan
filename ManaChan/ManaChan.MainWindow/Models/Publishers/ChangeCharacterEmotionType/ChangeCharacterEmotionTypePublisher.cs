using ManaChan.Infrastructure.Enums;
using ManaChan.Infrastructure.Models.Events.ChangeCharacterEmotionTypeEvent;
using Microsoft.Practices.Unity;
using Prism.Events;

namespace ManaChan.MainWindow.Models.Publishers.ChangeCharacterEmotionType {

	/// <summary>
	/// キャラクター表情種別値発行者
	/// </summary>
	public class ChangeCharacterEmotionTypePublisher : IChangeCharacterEmotionTypePublisher {

		/// <summary>
		/// イベントアグリゲータ
		/// </summary>
		[Dependency]
		public IEventAggregator EventAggregator { set; get; }

		/// <summary>
		/// 発行
		/// </summary>
		/// <param name="characterEmotionType">キャラクター表情種別</param>
		public void Publish( CharacterEmotionType characterEmotionType )
			=> this.EventAggregator
				.GetEvent<PubSubEvent<ChangeCharacterEmotionTypeEventValue>>()
				.Publish( new ChangeCharacterEmotionTypeEventValue { CharacterEmotionType = characterEmotionType } );

	}

}
