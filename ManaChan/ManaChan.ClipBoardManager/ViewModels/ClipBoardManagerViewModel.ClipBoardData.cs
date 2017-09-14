using Prism.Mvvm;

namespace ManaChan.ClipBoardManager.ViewModels {
	public partial class ClipBoardManagerViewModel : BindableBase {

		/// <summary>
		/// 表示用データ
		/// </summary>
		public class ClipBoardData {

			/// <summary>
			/// 保存時間
			/// </summary>
			public string Time { set; get; }

			/// <summary>
			/// 内容
			/// </summary>
			public string Content { set; get; }

		}

	}
}
