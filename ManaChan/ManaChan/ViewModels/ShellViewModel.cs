using ManaChan.Infrastructure.Models.ScreenSize;
using Microsoft.Practices.Unity;
using Prism.Mvvm;

namespace ManaChan.ViewModels {

	/// <summary>
	/// ShellのViewModel
	/// </summary>
	public class ShellViewModel : BindableBase {

		/// <summary>
		/// 画面サイズ
		/// </summary>
		[Dependency]
		public PrimaryScreenSize PrimaryScreenSize { get; } = new PrimaryScreenSize();

		/// <summary>
		/// タイトル
		/// </summary>
		public string Title { get; } = "ｱｶﾈﾁｬﾝｶﾜｲｲﾔｯﾀｰ";

	}

}