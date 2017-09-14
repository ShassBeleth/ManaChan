using System;
using System.Collections.ObjectModel;
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

			this.ClipBoardDataList.Add( new ClipBoardData() { Time = DateTime.Now.ToString( "MM/dd hh:mm:ss" ) , Content = "aaa" } );

			Console.WriteLine( "ok" );

			/*
			IDataObject data = Clipboard.GetDataObject();
			string[] formats = data.GetFormats();
			Console.WriteLine( "formats" );
			foreach( string format in formats ) {
				Console.WriteLine( format );
			}
			*/
		}

		#endregion

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public ClipBoardManagerViewModel()
		=> this.clipBoardMonitor.OnClipboardContentChanged += ( sender , e ) => this.OnClipBoardContentChanged();

	}

}
