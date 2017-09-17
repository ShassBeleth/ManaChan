using System;
using System.Windows;
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

			/// <summary>
			/// 簡易フォーマット
			/// </summary>
			public string SimpleFormat { set; get; }

			/// <summary>
			/// 形式群
			/// </summary>
			public string[] Formats { set; get; }
			
			/// <summary>
			/// クリップボードに戻す際に指定する形式
			/// </summary>
			public string MainFormat { set; get; }

			/// <summary>
			/// クリップボードに戻すデータ
			/// </summary>
			public DataObject DataObject { set; get; }

			/// <summary>
			/// コンストラクタ
			/// </summary>
			/// <param name="data"></param>
			public ClipBoardData( IDataObject data ) {
				
				this.Time = DateTime.Now.ToString( "MM/dd hh:mm:ss" );

				this.SimpleFormat =
					data != null ? (
						data.GetDataPresent( DataFormats.Text ) ? "テキスト" :
						data.GetDataPresent( DataFormats.Bitmap ) ? "画像" :
						"その他データ"
					) : "";

				this.Content =
					data != null ? (
						data.GetDataPresent( DataFormats.Text ) ? (string)data?.GetData( DataFormats.Text ) :
						data.GetDataPresent( DataFormats.Bitmap ) ? "画像" :
						"その他データ"
					) : "";

				this.Formats = data?.GetFormats();

				this.DataObject = new DataObject();
				foreach( string format in this.Formats ) {
					this.DataObject.SetData( format , data.GetData( format ) );
				}

			}

		}

	}
}
