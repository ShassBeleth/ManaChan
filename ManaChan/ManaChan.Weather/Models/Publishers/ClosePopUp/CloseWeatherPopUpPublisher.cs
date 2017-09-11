using System;
using ManaChan.Infrastructure.Models.Events.ClosePopUpEvent;
using Microsoft.Practices.Unity;
using Prism.Events;

namespace ManaChan.Weather.Models.Publishers.ClosePopUp {

	/// <summary>
	/// 天気情報ポップアップを閉じるための発行者
	/// </summary>
	public class CloseWeatherPopUpPublisher : ICloseWeatherPopUpPublisher{

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
			.GetEvent<PubSubEvent<CloseWeatherPopUpEventValue>>()
			.Publish( new CloseWeatherPopUpEventValue { Guid = Guid.NewGuid().ToString() } );

	}
	
}
