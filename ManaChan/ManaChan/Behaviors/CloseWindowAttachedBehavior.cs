using System.Windows;

namespace ManaChan.Behaviors {

	/// <summary>
	/// ウィンドウを閉じる添付ビヘイビア
	/// </summary>
	public class CloseWindowAttachedBehavior {

		/// <summary>
		/// プロパティの取得
		/// </summary>
		/// <param name="dependencyObject"></param>
		/// <returns></returns>
		public static bool GetClose( DependencyObject dependencyObject )
			=> (bool)dependencyObject.GetValue( CloseProperty );

		/// <summary>
		/// プロパティの設定
		/// </summary>
		/// <param name="dependencyObject"></param>
		/// <param name="value"></param>
		public static void SetClose( DependencyObject dependencyObject , bool value )
			=> dependencyObject.SetValue( CloseProperty , value );

		/// <summary>
		/// IsCloseプロパティ作成
		/// </summary>
		public static readonly DependencyProperty CloseProperty = DependencyProperty.RegisterAttached(
			"Close" ,
			typeof( bool ) ,
			typeof( CloseWindowAttachedBehavior ) ,
			new PropertyMetadata( false , OnCloseChanged )
		);

		/// <summary>
		/// IsClose変化時イベント
		/// Windowを閉じる
		/// </summary>
		/// <remarks>
		/// この添付ビヘイビアがWindow以外のコントロールにつけられていた場合、
		/// そのコントロールが属しているWindowを閉じる
		/// </remarks>
		/// <param name="dependencyObject"></param>
		/// <param name="dependencyPropertyChangedEventArgs"></param>
		private static void OnCloseChanged(
			DependencyObject dependencyObject ,
			DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs
		) {

			Window window = dependencyObject as Window ?? Window.GetWindow( dependencyObject );

			if( GetClose( dependencyObject ) )
				window.Close();

		}

	}

}
