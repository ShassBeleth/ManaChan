using ManaChan.Infrastructure.Enums;
using ManaChan.Infrastructure.Models.ChangeCharacterType.Events;
using Microsoft.Practices.Unity;
using Prism.Events;

namespace ManaChan.Infrastructure.Models.ChangeCharacterType.Publishers {

	/// <summary>
	/// キャラクター種別値発行者
	/// </summary>
	public class CharacterTypeValuePublisher : ICharacterTypeValuePublisher {

		/// <summary>
		/// イベントアグリゲータ
		/// </summary>
		[Dependency]
		public IEventAggregator EventAggregator { set; get; }

		/// <summary>
		/// 発行
		/// </summary>
		/// <param name="characterType">キャラクター種別</param>
		public void Publish( CharacterType characterType )
			=> this.EventAggregator
				.GetEvent<PubSubEvent<ChangeCharacterTypeEvent>>()
				.Publish( new ChangeCharacterTypeEvent { Value = characterType } );

	}
}
