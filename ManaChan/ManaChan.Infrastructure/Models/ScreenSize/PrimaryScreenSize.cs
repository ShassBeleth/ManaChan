using System.Windows;

namespace ManaChan.Infrastructure.Models.ScreenSize {

	/// <summary>
	/// 画面サイズ
	/// </summary>
	public class PrimaryScreenSize {

		/// <summary>
		/// 画面幅
		/// </summary>
		public double Width { get; } = SystemParameters.PrimaryScreenWidth;
		
		/// <summary>
		/// 画面高さ
		/// </summary>
		public double Height { get; } = SystemParameters.PrimaryScreenHeight;
		
	}

}
