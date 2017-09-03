using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ManaChan.MainWindow.Views {
	/// <summary>
	/// MainWindowView.xaml の相互作用ロジック
	/// </summary>
	public partial class MainWindowView : UserControl {

		/// <summary>
		/// ドラッグ中かどうか
		/// </summary>
		private bool isDrag = false;

		/// <summary>
		/// ドラッグ中の座標
		/// </summary>
		private Point dragOffset;

		public MainWindowView() =>
			InitializeComponent();
		
		/// <summary>
		/// ドラッグ開始イベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CharacterMouseLeftButtonDown( object sender , MouseButtonEventArgs e ) {
			if( sender is UIElement uiElement ) {
				this.isDrag = true;
				this.dragOffset = e.GetPosition( uiElement );
				uiElement.CaptureMouse();
			}
		}

		/// <summary>
		/// ドラッグ終了イベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CharacterMouseLeftButtonUp( object sender , MouseButtonEventArgs e ) {
			if( this.isDrag ) {
				UIElement uiElement = sender as UIElement;
				uiElement.ReleaseMouseCapture();
				this.isDrag = false;
			}
		}

		/// <summary>
		/// ドラック中
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CharacterMouseMove( object sender , MouseEventArgs e ) {
			if( this.isDrag == true ) {
				Point point = Mouse.GetPosition( this.canvas );
				UIElement urElement = sender as UIElement;
				Canvas.SetLeft( urElement , point.X - this.dragOffset.X );
				Canvas.SetTop( urElement , point.Y - this.dragOffset.Y );
			}
		}

	}
	
}
