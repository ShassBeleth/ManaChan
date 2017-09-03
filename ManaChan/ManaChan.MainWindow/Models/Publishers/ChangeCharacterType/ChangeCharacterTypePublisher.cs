using ManaChan.Infrastructure.Enums;
using ManaChan.Infrastructure.Models.Events.ChangeCharacterTypeEvent;
using Microsoft.Practices.Unity;
using Prism.Events;

namespace ManaChan.MainWindow.Models.Publishers.ChangeCharacterType {

	/// <summary>
	/// キャラクター種別値発行者
	/// </summary>
	public class ChangeCharacterTypePublisher : IChangeCharacterTypePublisher {

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
				.GetEvent<PubSubEvent<ChangeCharacterTypeEventValue>>()
				.Publish( new ChangeCharacterTypeEventValue { CharacterType = characterType } );
		
	}
}
