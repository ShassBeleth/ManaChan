using ManaChan.Infrastructure.Enums;
using ManaChan.Infrastructure.Models.Passer.Events;
using Microsoft.Practices.Unity;
using Prism.Events;

namespace ManaChan.Infrastructure.Models.Passer.Publishers {

	/// <summary>
	/// キャラクター種別値発行者
	/// </summary>
	public class PublisherOfPasser : IPublisherOfPasser {

		/// <summary>
		/// イベントアグリゲータ
		/// </summary>
		[Dependency]
		public IEventAggregator EventAggregator { set; get; }

		/// <summary>
		/// 発行
		/// </summary>
		/// <param name="characterType">キャラクター種別</param>
		public void CharacterTypePublish( CharacterType characterType )
			=> this.EventAggregator
				.GetEvent<PubSubEvent<EventOfPasser>>()
				.Publish( new EventOfPasser { CharacterType = characterType } );

		public void PinCodePublish( int pinCode )
			=> this.EventAggregator
				.GetEvent<PubSubEvent<EventOfPasser>>()
				.Publish( new EventOfPasser { PinCode = pinCode } );

	}
}
