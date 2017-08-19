using ManaChan.MainCharacter.Enums;
using ManaChan.MainCharacter.Events.ChangeCharacterType;
using Microsoft.Practices.Unity;
using Prism.Events;

namespace ManaChan.Models {

	/// <summary>
	/// キャラクター種別値発行者
	/// </summary>
	public class CharacterTypeValuePublisher : ICharacterTypeValuePublisher {

		/// <summary>
		/// イベントアグリゲータ
		/// </summary>
		[Dependency]
		public IEventAggregator EventAggregator { set; get; }

		public void Publish( CharacterType characterType ) => this.EventAggregator
				.GetEvent<PubSubEvent<ChangeCharacterTypeEvent>>()
				.Publish( new ChangeCharacterTypeEvent { Value = characterType } );

	}
}
