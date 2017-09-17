using System;
using ManaChan.Infrastructure.Enums;
using ManaChan.Infrastructure.Models.Events.ClosePopUps;
using Microsoft.Practices.Unity;
using Prism.Events;

namespace ManaChan.Infrastructure.Models.Publishers.ClosePopUps {

	public class ClosePopUpPublisher : IClosePopUpPublisher {

		/// <summary>
		/// イベントアグリゲータ
		/// </summary>
		[Dependency]
		public IEventAggregator EventAggregator { set; get; }

		/// <summary>
		/// 発行
		/// </summary>
		/// <param name="popUpName">ポップアップ名</param>
		public void Publish( PopUpNames popUpName )
			=> this.EventAggregator
				.GetEvent<PubSubEvent<ClosePopUpEventValue>>()
				.Publish(
					new ClosePopUpEventValue {
						PopUpName = popUpName ,
						Guid = Guid.NewGuid().ToString()
					}
				);

	}

}