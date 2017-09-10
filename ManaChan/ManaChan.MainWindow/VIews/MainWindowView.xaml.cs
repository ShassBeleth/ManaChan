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

	}

}
