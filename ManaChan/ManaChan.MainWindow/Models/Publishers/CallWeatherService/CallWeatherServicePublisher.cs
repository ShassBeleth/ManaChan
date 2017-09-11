using System;
using ManaChan.Infrastructure.Models.Events.CallWeatherServiceEvent;
using Microsoft.Practices.Unity;
using Prism.Events;

namespace ManaChan.MainWindow.Models.Publishers.CallWeatherService {

	/// <summary>
	/// 天気情報サービス呼び出し発行者
	/// </summary>
	public class CallWeatherServicePublisher : ICallWeatherServicePublisher {

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
			.GetEvent<PubSubEvent<CallWeatherServiceEventValue>>()
			.Publish( new CallWeatherServiceEventValue { Guid = Guid.NewGuid().ToString() } );
		
	}

}

