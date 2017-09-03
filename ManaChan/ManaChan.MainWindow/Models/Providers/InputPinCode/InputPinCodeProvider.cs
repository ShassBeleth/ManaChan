using ManaChan.Infrastructure.Models.Events.InputPinCodeEvent;
using Prism.Events;
using Prism.Mvvm;

namespace ManaChan.MainWindow.Models.Providers.InputPinCode {

	/// <summary>
	/// PINコード購読者
	/// </summary>
	public class InputPinCodeProvider : BindableBase , IInputPinCodeProvider {
		
		/// <summary>
		/// PINコード
		/// </summary>
		private int pinCode;
		
		/// <summary>
		/// PINコード
		/// </summary>
		public int PinCode {
			private set => this.SetProperty( ref this.pinCode , value );
			get => this.pinCode;
		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="eventAggregator">イベントアグリゲータ</param>
		public InputPinCodeProvider( IEventAggregator eventAggregator )
			=> eventAggregator.GetEvent<PubSubEvent<InputPinCodeEventValue>>()
			.Subscribe(
				x => this.PinCode = x.PinCode ,
				ThreadOption.UIThread
			);

	}
}
