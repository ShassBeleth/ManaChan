using Prism.Mvvm;

namespace ManaChan.ViewModels {
	public partial class ShellViewModel : BindableBase {

		/// <summary>
		/// キャラ種別
		/// </summary>
		public enum CharacterType {

			/// <summary>
			/// 琴葉 茜
			/// </summary>
			Akane ,

			/// <summary>
			/// 琴葉 葵
			/// </summary>
			Aoi ,

			/// <summary>
			/// 弦巻 マキ
			/// </summary>
			Maki ,

			/// <summary>
			/// 結月 ゆかり
			/// </summary>
			Yukari ,

			/// <summary>
			/// 東北ずん子
			/// </summary>
			Zunko ,

			/// <summary>
			/// 要素数
			/// </summary>
			Num

		}

	}
}