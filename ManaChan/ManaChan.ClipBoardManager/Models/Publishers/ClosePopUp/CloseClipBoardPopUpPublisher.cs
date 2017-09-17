using System;
using ManaChan.Infrastructure.Models.Events.ClosePopUpEvent;
using Microsoft.Practices.Unity;
using Prism.Events;

namespace ManaChan.ClipBoardManager.Models.Publishers.ClosePopUp {

	/// <summary>
	/// クリップボードポップアップを閉じるための発行者
	/// </summary>
	public class CloseClipBoardPopUpPublisher : ICloseClipBoardPopUpPublisher {

		/// <summary>
		/// イベントアグリゲータ
		/// </summary>
		[Dependency]
		public IEventAggregator EventAggregator { set; get; }

		/// <summary>
		/// 発行
		/// </summary>
		public void Publish()
		=> this.EventAggregator
			.GetEvent<PubSubEvent<CloseClipBoardPopUpEventValue>>()
			.Publish( new CloseClipBoardPopUpEventValue { Guid = Guid.NewGuid().ToString() } );

	}

}
