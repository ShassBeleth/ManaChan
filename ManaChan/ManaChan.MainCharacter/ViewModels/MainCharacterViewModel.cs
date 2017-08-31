using ManaChan.Infrastructure.Enums;
using ManaChan.Infrastructure.Models.Passer.Providers;
using Prism.Mvvm;

namespace ManaChan.MainCharacter.ViewModels {

	/// <summary>
	/// MainCharacterのViewModel
	/// </summary>
	public class MainCharacterViewModel : BindableBase {
		
		/// <summary>
		/// 画像URL
		/// </summary>
		private string sourceUrl = "../Graphics/Pictures/Akane/Normal.png";

		/// <summary>
		/// 画像URL
		/// </summary>
		public string SourceUrl {
			set => this.SetProperty( ref this.sourceUrl , value );
			get => this.sourceUrl;
		}

		/// <summary>
		/// 画像URL更新
		/// </summary>
		/// <param name="characterType">キャラクター種別</param>
		private void UpdateSourceUrl( CharacterType characterType )
			=> this.SourceUrl = "../Graphics/Pictures/" + characterType + "/Normal.png";

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="providerOfPasser">キャラクター種別値購読者</param>
		public MainCharacterViewModel( IProviderOfPasser providerOfPasser ) 
		=> providerOfPasser.PropertyChanged += ( _ , e ) => {
			if( e.PropertyName == "CharacterType" )
				this.UpdateSourceUrl( providerOfPasser.CharacterType );
		};
	}
}
