using ManaChan.Infrastructure.Enums;

namespace ManaChan.Infrastructure.Models.Publishers.CallServices {

	/// <summary>
	/// サービス呼び出し発行者
	/// </summary>
	public interface ICallServicePublisher {

		/// <summary>
		/// 発行
		/// </summary>
		/// <param name="serviceName">サービス名</param>
		void Publish( ServiceNames serviceName );

	}

}
