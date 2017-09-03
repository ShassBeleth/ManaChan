using Prism.Mvvm;

namespace ManaChan.MainWindow.ViewModels {
	public partial class MainWindowViewModel : BindableBase {

		/// <summary>
		/// サイズ
		/// </summary>
		public enum Size {

			/// <summary>
			/// ドアップ
			/// </summary>
			SpecialLarge,

			/// <summary>
			/// 大
			/// </summary>
			Large,

			/// <summary>
			/// 中
			/// </summary>
			Medium,

			/// <summary>
			/// 小
			/// </summary>
			Small,

			/// <summary>
			/// 要素数
			/// </summary>
			Num

		};
		
	}
}
