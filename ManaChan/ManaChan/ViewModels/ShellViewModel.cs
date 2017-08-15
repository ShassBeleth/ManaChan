using ManaChan.Models.ScreenSize;
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

		#region キャラクターの表示座標

		#region キャラクターの高さ

		/// <summary>
		/// キャラクターの最小の描画高さ
		/// </summary>
		private const int CharacterMinHeight = 300;

		/// <summary>
		/// キャラクターの描画高さ
		/// </summary>
		private int characterHeight = CharacterMinHeight;

		/// <summary>
		/// キャラクターの描画高さ
		/// </summary>
		public int CharacterHeight {
			set => SetProperty( ref this.characterHeight , value );
			get => this.characterHeight;
		}

		#endregion

		#region キャラクターの幅

		/// <summary>
		/// キャラクターの最小の描画幅
		/// </summary>
		private const int CharacterMinWidth = 300;

		/// <summary>
		/// キャラクターの描画幅
		/// </summary>
		private int characterWidth = CharacterMinWidth;

		/// <summary>
		/// キャラクターの描画幅
		/// </summary>
		public int CharacterWidth {
			set => SetProperty( ref this.characterWidth , value );
			get => this.characterWidth;
		}

		#endregion

		#region キャラクターのX座標
		
		/// <summary>
		/// キャラクターのX座標
		/// </summary>
		private int characterPosX;

		/// <summary>
		/// キャラクターのX座標
		/// </summary>
		public int CharacterPosX {
			set => SetProperty( ref this.characterPosX , value );
			get => this.characterPosX;
		}

		#endregion

		#region キャラクターのY座標

		/// <summary>
		/// キャラクターのY座標
		/// </summary>
		private int characterPosY;

		/// <summary>
		/// キャラクターのY座標
		/// </summary>
		public int CharacterPosY {
			set => SetProperty( ref this.characterPosY , value );
			get => this.characterPosY;
		}

		#endregion

		#endregion

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public ShellViewModel() {

			// キャラクターのサイズ更新
			this.UpdateCharacterSize();

			// キャラクターの座標更新
			this.UpdateCharacterPosition();
		}

		/// <summary>
		/// キャラクターのサイズ更新
		/// </summary>
		private void UpdateCharacterSize() {

			// 分割数
			int divisionHeightNum = 2;
			int divisionWidthNum = 5;

			this.CharacterHeight = this.PrimaryScreenSize.Height / divisionHeightNum > CharacterMinHeight ? (int)( this.PrimaryScreenSize.Height / divisionHeightNum ) : CharacterMinHeight;
			this.CharacterWidth = this.PrimaryScreenSize.Width / divisionWidthNum > CharacterMinWidth ? (int)( this.PrimaryScreenSize.Width / divisionWidthNum ) : CharacterMinWidth;
			
		}

		/// <summary>
		/// キャラクターの座標更新
		/// </summary>
		private void UpdateCharacterPosition() {

			this.CharacterPosX = (int)this.PrimaryScreenSize.Width - this.CharacterWidth;
			this.CharacterPosY = (int)this.PrimaryScreenSize.Height - this.CharacterHeight;

		}

	}

}