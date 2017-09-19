using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ManaChan.MainWindow.Views {
	/// <summary>
	/// MainWindowView.xaml の相互作用ロジック
	/// </summary>
	public partial class MainWindowView : UserControl {

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public MainWindowView() => InitializeComponent();

		#region キャラクターのドラッグ&ドロップ

		/// <summary>
		/// ドラッグ中かどうか
		/// </summary>
		private bool isDragCharacter = false;

		/// <summary>
		/// ドラッグ中の座標
		/// </summary>
		private Point dragOffsetCharacter;

		/// <summary>
		/// ドラッグ開始イベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CharacterMouseLeftButtonDown( object sender , MouseButtonEventArgs e ) {
			if( sender is UIElement uiElement ) {
				this.isDragCharacter = true;
				this.dragOffsetCharacter = e.GetPosition( uiElement );
				uiElement.CaptureMouse();
			}
		}

		/// <summary>
		/// ドラッグ終了イベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CharacterMouseLeftButtonUp( object sender , MouseButtonEventArgs e ) {
			if( this.isDragCharacter ) {
				UIElement uiElement = sender as UIElement;
				uiElement.ReleaseMouseCapture();
				this.isDragCharacter = false;
			}
		}

		/// <summary>
		/// ドラック中
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CharacterMouseMove( object sender , MouseEventArgs e ) {
			if( this.isDragCharacter == true ) {
				Point point = Mouse.GetPosition( this.canvas );
				UIElement urElement = sender as UIElement;
				Canvas.SetLeft( urElement , point.X - this.dragOffsetCharacter.X );
				Canvas.SetTop( urElement , point.Y - this.dragOffsetCharacter.Y );
			}
		}

		#endregion

		#region 天気情報ポップアップのドラッグ&ドロップ

		/// <summary>
		/// ドラッグ中かどうか
		/// </summary>
		private bool isDragWeatherPopUp = false;

		/// <summary>
		/// ドラッグ中の座標
		/// </summary>
		private Point dragOffsetWeatherPopUp;

		/// <summary>
		/// ドラッグ開始イベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void WeatherPopUpMouseLeftButtonDown( object sender , MouseButtonEventArgs e ) {
			if( sender is UIElement uiElement ) {
				this.isDragWeatherPopUp = true;
				this.dragOffsetWeatherPopUp = e.GetPosition( uiElement );
				uiElement.CaptureMouse();
			}
		}

		/// <summary>
		/// ドラッグ終了イベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void WeatherPopUpMouseLeftButtonUp( object sender , MouseButtonEventArgs e ) {
			if( this.isDragWeatherPopUp ) {
				UIElement uiElement = sender as UIElement;
				uiElement.ReleaseMouseCapture();
				this.isDragWeatherPopUp = false;
			}
		}

		/// <summary>
		/// ドラック中
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void WeatherPopUpMouseMove( object sender , MouseEventArgs e ) {
			if( this.isDragWeatherPopUp == true ) {
				Point point = Mouse.GetPosition( this.canvas );
				UIElement urElement = sender as UIElement;
				Canvas.SetLeft( urElement , point.X - this.dragOffsetWeatherPopUp.X );
				Canvas.SetTop( urElement , point.Y - this.dragOffsetWeatherPopUp.Y );
			}
		}

		#endregion

		#region クリップボードポップアップのドラッグ&ドロップ

		/// <summary>
		/// ドラッグ中かどうか
		/// </summary>
		private bool isDragClipBoardPopUp = false;

		/// <summary>
		/// ドラッグ中の座標
		/// </summary>
		private Point dragOffsetClipBoardPopUp;

		/// <summary>
		/// ドラッグ開始イベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ClipBoardPopUpMouseLeftButtonDown( object sender , MouseButtonEventArgs e ) {
			if( sender is UIElement uiElement ) {
				this.isDragClipBoardPopUp = true;
				this.dragOffsetClipBoardPopUp = e.GetPosition( uiElement );
				uiElement.CaptureMouse();
			}
		}

		/// <summary>
		/// ドラッグ終了イベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ClipBoardPopUpMouseLeftButtonUp( object sender , MouseButtonEventArgs e ) {
			if( this.isDragClipBoardPopUp ) {
				UIElement uiElement = sender as UIElement;
				uiElement.ReleaseMouseCapture();
				this.isDragClipBoardPopUp = false;
			}
		}

		/// <summary>
		/// ドラック中
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ClipBoardPopUpMouseMove( object sender , MouseEventArgs e ) {
			if( this.isDragClipBoardPopUp == true ) {
				Point point = Mouse.GetPosition( this.canvas );
				UIElement urElement = sender as UIElement;
				Canvas.SetLeft( urElement , point.X - this.dragOffsetClipBoardPopUp.X );
				Canvas.SetTop( urElement , point.Y - this.dragOffsetClipBoardPopUp.Y );
			}
		}

		#endregion

		#region ブックマークポップアップのドラッグ&ドロップ

		/// <summary>
		/// ドラッグ中かどうか
		/// </summary>
		private bool isDragBookmarksPopUp = false;

		/// <summary>
		/// ドラッグ中の座標
		/// </summary>
		private Point dragOffsetBookmarksPopUp;

		/// <summary>
		/// ドラッグ開始イベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BookmarksPopUpMouseLeftButtonDown( object sender , MouseButtonEventArgs e ) {
			if( sender is UIElement uiElement ) {
				this.isDragBookmarksPopUp = true;
				this.dragOffsetBookmarksPopUp = e.GetPosition( uiElement );
				uiElement.CaptureMouse();
			}
		}

		/// <summary>
		/// ドラッグ終了イベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BookmarksPopUpMouseLeftButtonUp( object sender , MouseButtonEventArgs e ) {
			if( this.isDragBookmarksPopUp ) {
				UIElement uiElement = sender as UIElement;
				uiElement.ReleaseMouseCapture();
				this.isDragBookmarksPopUp = false;
			}
		}

		/// <summary>
		/// ドラック中
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BookmarksPopUpMouseMove( object sender , MouseEventArgs e ) {
			if( this.isDragBookmarksPopUp == true ) {
				Point point = Mouse.GetPosition( this.canvas );
				UIElement urElement = sender as UIElement;
				Canvas.SetLeft( urElement , point.X - this.dragOffsetBookmarksPopUp.X );
				Canvas.SetTop( urElement , point.Y - this.dragOffsetBookmarksPopUp.Y );
			}
		}

		#endregion

	}

}
