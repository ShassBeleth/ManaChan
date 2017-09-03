using ManaChan.Infrastructure.Models.Events.InputPinCodeEvent;
using Microsoft.Practices.Unity;
using Prism.Events;

namespace ManaChan.PopUp.Models {

	/// <summary>
	/// PINコード発行者
	/// </summary>
	public class PinCodePublisher : IPinCodePublisher {

		/// <summary>
		/// イベントアグリゲータ
		/// </summary>
		[Dependency]
		public IEventAggregator EventAggregator { set; get; }

		/// <summary>
		/// 発行
		/// </summary>
		/// <param name="pinCode">PINコード</param>
		public void Publish( int pinCode )
			=> this.EventAggregator
				.GetEvent<PubSubEvent<InputPinCodeEventValue>>()
				.Publish( 
					new InputPinCodeEventValue {
						PinCode = pinCode
					} 
				);
		
	}

}
