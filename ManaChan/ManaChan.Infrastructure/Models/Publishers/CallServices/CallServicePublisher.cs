using System;
using ManaChan.Infrastructure.Enums;
using ManaChan.Infrastructure.Models.Events.CallServices;
using Microsoft.Practices.Unity;
using Prism.Events;

namespace ManaChan.Infrastructure.Models.Publishers.CallServices {

	public class CallServicePublisher : ICallServicePublisher {

		/// <summary>
		/// イベントアグリゲータ
		/// </summary>
		[Dependency]
		public IEventAggregator EventAggregator { set; get; }

		/// <summary>
		/// 発行
		/// </summary>
		/// <param name="serviceName">サービス名</param>
		public void Publish( ServiceNames serviceName )
		=> this.EventAggregator
			.GetEvent<PubSubEvent<CallServiceEventValue>>()
			.Publish( 
				new CallServiceEventValue {
					ServiceName = serviceName ,
					Guid = Guid.NewGuid().ToString()
				} 
			);

	}

}
