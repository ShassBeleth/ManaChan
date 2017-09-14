using System;
using System.Collections.ObjectModel;
using System.Windows;
using Prism.Mvvm;

namespace ManaChan.ClipBoardManager.ViewModels {

	/// <summary>
	/// クリップボード管理のViewModel
	/// </summary>
	public partial class ClipBoardManagerViewModel : BindableBase {
		
		#region テスト用

		public string test = "123123123awefawfwfwfwfwefwefwfwe";

		public string Test {
			private set => SetProperty( ref this.test , value );
			get => this.test;
		}

		#endregion

		#region クリップボード保存データ一覧
		
		/// <summary>
		/// クリップボード監視者
		/// </summary>
		private ClipBoardMonitor clipBoardMonitor = new ClipBoardMonitor();

		/// <summary>
		/// クリップボード保存データ一覧
		/// </summary>
		public ObservableCollection<ClipBoardData> ClipBoardDataList { set; get; } = new ObservableCollection<ClipBoardData>();

		/// <summary>
		/// クリップボード更新時イベント
		/// </summary>
		private void OnClipBoardContentChanged() {

			IDataObject data = Clipboard.GetDataObject();

			string simpleFormat = 
				data != null ? (
					data.GetDataPresent( DataFormats.Text ) ? "テキスト" :
					data.GetDataPresent( DataFormats.Bitmap ) ? "画像" :
					"その他データ"
				) : "";
			
			string content = 
				data != null ? (
					data.GetDataPresent( DataFormats.Text ) ? (string)data?.GetData( DataFormats.Text ) :
					data.GetDataPresent( DataFormats.Bitmap ) ? "画像" :
					"その他データ" 
				) : "";

			string[] formats = data?.GetFormats();

			this.ClipBoardDataList.Add( 
				new ClipBoardData() {
					Time = DateTime.Now.ToString( "MM/dd hh:mm:ss" ) ,
					SimpleFormat = simpleFormat ,
					Content = content ,
					Formats = formats
				} 
			);
			
		}

		#endregion

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public ClipBoardManagerViewModel()
		=> this.clipBoardMonitor.OnClipboardContentChanged += ( sender , e ) => this.OnClipBoardContentChanged();

	}

}
