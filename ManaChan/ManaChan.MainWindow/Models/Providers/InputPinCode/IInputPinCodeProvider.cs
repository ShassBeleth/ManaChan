using System.ComponentModel;

namespace ManaChan.MainWindow.Models.Providers.InputPinCode {

	/// <summary>
	/// PINコード購読者
	/// </summary>
	public interface IInputPinCodeProvider : INotifyPropertyChanged {

		/// <summary>
		/// PINコード
		/// </summary>
		int PinCode { get; }

	}
}
