using ManaChan.Infrastructure.Enums;
using ManaChan.MainCharacter.Models.Providers.ChangeCharacterEmotionType;
using ManaChan.MainCharacter.Models.Providers.ChangeCharacterType;
using Prism.Mvvm;

namespace ManaChan.MainCharacter.ViewModels {

	/// <summary>
	/// MainCharacterのViewModel
	/// </summary>
	public class MainCharacterViewModel : BindableBase {

		/// <summary>
		/// 画像URLヘッダー
		/// </summary>
		private string SourceUrlHeader { get; } = "../Graphics/Pictures/";

		/// <summary>
		/// 画像URL末尾
		/// </summary>
		private string SourceUrlFooter { get; } = ".png";

		/// <summary>
		/// 選択中のキャラクター種別
		/// </summary>
		private CharacterType SelectedCharacterType { set; get; } = CharacterType.Akane;

		/// <summary>
		/// 選択中のキャラクター表情種別
		/// </summary>
		private CharacterEmotionType SelectedCharacterEmotionType { set; get; } = CharacterEmotionType.Normal;

		/// <summary>
		/// 画像URL
		/// </summary>
		private string sourceUrl = "../Graphics/Pictures/Akane/Normal.png";

		/// <summary>
		/// 画像URL
		/// </summary>
		public string SourceUrl {
			private set => this.SetProperty( ref this.sourceUrl , value );
			get => this.sourceUrl;
		}

		/// <summary>
		/// 画像URL更新
		/// </summary>
		private void UpdateSourceUrl()
		=> this.SourceUrl = this.SourceUrlHeader + this.SelectedCharacterType + "/" + this.SelectedCharacterEmotionType  + this.SourceUrlFooter;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="changeCharacterTypeProvider">キャラクター種別値購読者</param>
		/// <param name="changeCharacterEmotionTypeProvider">キャラクター表情種別値購読者</param>
		public MainCharacterViewModel( 
			IChangeCharacterTypeProvider changeCharacterTypeProvider ,
			IChangeCharacterEmotionTypeProvider changeCharacterEmotionTypeProvider
		){
			
			changeCharacterTypeProvider.PropertyChanged += ( _ , e ) => {
				if( e.PropertyName == "CharacterType" ) {
					this.SelectedCharacterType = changeCharacterTypeProvider.CharacterType;
					this.UpdateSourceUrl();
				}
			};

			changeCharacterEmotionTypeProvider.PropertyChanged += ( _ , e ) => {
				if( e.PropertyName == "CharacterEmotionType" ) {
					this.SelectedCharacterEmotionType = changeCharacterEmotionTypeProvider.CharacterEmotionType;
					this.UpdateSourceUrl();
				}
			};

		}

	}
}
