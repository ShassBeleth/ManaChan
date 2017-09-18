using System.Windows.Controls;
using SharpGL;
using SharpGL.SceneGraph;

namespace ManaChan.MainCharacter.Views {

	/// <summary>
	/// HelloWorldView.xaml の相互作用ロジック
	/// </summary>
	public partial class MainCharacterView : UserControl {
		
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public MainCharacterView() => InitializeComponent();

		private float RotatePyramid { set; get; } = 50;
		private float Rquad { set; get; } = 100;
		
		private void OpenGLDraw( object sender , OpenGLEventArgs args ) {
			OpenGL openGl = args.OpenGL;
			openGl.Clear( OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT );
			openGl.LoadIdentity();
			openGl.Translate( -1.5f , 0.0f , -6.0f );
			openGl.Rotate( this.RotatePyramid , 0.0f , 1.0f , 0.0f );

			openGl.Begin( OpenGL.GL_TRIANGLES );

			openGl.Color( 1.0f , 0.0f , 0.0f );
			openGl.Vertex( 0.0f , 1.0f , 0.0f );
			openGl.Color( 0.0f , 1.0f , 0.0f );
			openGl.Vertex( -1.0f , -1.0f , 1.0f );
			openGl.Color( 0.0f , 0.0f , 1.0f );
			openGl.Vertex( 1.0f , -1.0f , 1.0f );

			openGl.Color( 1.0f , 0.0f , 0.0f );
			openGl.Vertex( 0.0f , 1.0f , 0.0f );
			openGl.Color( 0.0f , 0.0f , 1.0f );
			openGl.Vertex( 1.0f , -1.0f , 1.0f );
			openGl.Color( 0.0f , 1.0f , 0.0f );
			openGl.Vertex( 1.0f , -1.0f , -1.0f );

			openGl.Color( 1.0f , 0.0f , 0.0f );
			openGl.Vertex( 0.0f , 1.0f , 0.0f );
			openGl.Color( 0.0f , 1.0f , 0.0f );
			openGl.Vertex( 1.0f , -1.0f , -1.0f );
			openGl.Color( 0.0f , 0.0f , 1.0f );
			openGl.Vertex( -1.0f , -1.0f , -1.0f );

			openGl.Color( 1.0f , 0.0f , 0.0f );
			openGl.Vertex( 0.0f , 1.0f , 0.0f );
			openGl.Color( 0.0f , 0.0f , 1.0f );
			openGl.Vertex( -1.0f , -1.0f , -1.0f );
			openGl.Color( 0.0f , 1.0f , 0.0f );
			openGl.Vertex( -1.0f , -1.0f , 1.0f );

			openGl.End();

			//  Reset the modelview.
			openGl.LoadIdentity();

			//  Move into a more central position.
			openGl.Translate( 1.5f , 0.0f , -7.0f );

			//  Rotate the cube.
			openGl.Rotate( this.Rquad , 1.0f , 1.0f , 1.0f );

			//  Provide the cube colors and geometry.
			openGl.Begin( OpenGL.GL_QUADS );

			openGl.Color( 0.0f , 1.0f , 0.0f );
			openGl.Vertex( 1.0f , 1.0f , -1.0f );
			openGl.Vertex( -1.0f , 1.0f , -1.0f );
			openGl.Vertex( -1.0f , 1.0f , 1.0f );
			openGl.Vertex( 1.0f , 1.0f , 1.0f );

			openGl.Color( 1.0f , 0.5f , 0.0f );
			openGl.Vertex( 1.0f , -1.0f , 1.0f );
			openGl.Vertex( -1.0f , -1.0f , 1.0f );
			openGl.Vertex( -1.0f , -1.0f , -1.0f );
			openGl.Vertex( 1.0f , -1.0f , -1.0f );

			openGl.Color( 1.0f , 0.0f , 0.0f );
			openGl.Vertex( 1.0f , 1.0f , 1.0f );
			openGl.Vertex( -1.0f , 1.0f , 1.0f );
			openGl.Vertex( -1.0f , -1.0f , 1.0f );
			openGl.Vertex( 1.0f , -1.0f , 1.0f );

			openGl.Color( 1.0f , 1.0f , 0.0f );
			openGl.Vertex( 1.0f , -1.0f , -1.0f );
			openGl.Vertex( -1.0f , -1.0f , -1.0f );
			openGl.Vertex( -1.0f , 1.0f , -1.0f );
			openGl.Vertex( 1.0f , 1.0f , -1.0f );

			openGl.Color( 0.0f , 0.0f , 1.0f );
			openGl.Vertex( -1.0f , 1.0f , 1.0f );
			openGl.Vertex( -1.0f , 1.0f , -1.0f );
			openGl.Vertex( -1.0f , -1.0f , -1.0f );
			openGl.Vertex( -1.0f , -1.0f , 1.0f );

			openGl.Color( 1.0f , 0.0f , 1.0f );
			openGl.Vertex( 1.0f , 1.0f , -1.0f );
			openGl.Vertex( 1.0f , 1.0f , 1.0f );
			openGl.Vertex( 1.0f , -1.0f , 1.0f );
			openGl.Vertex( 1.0f , -1.0f , -1.0f );

			openGl.End();

			//  Flush OpenGL.
			openGl.Flush();

			//  Rotate the geometry a bit.
			this.RotatePyramid += 3.0f;
			this.Rquad -= 3.0f;

		}

		private void OpenGLInitialized( object sender , OpenGLEventArgs args )
			=> args.OpenGL.Enable( OpenGL.GL_DEPTH_TEST );

		private void Resized( object sender , OpenGLEventArgs args ) {
			OpenGL openGl = args.OpenGL;
			openGl.MatrixMode( OpenGL.GL_PROJECTION );
			openGl.LoadIdentity();
			openGl.Perspective( 
				45.0f , 
				(float)openGl.RenderContextProvider.Width / (float)openGl.RenderContextProvider.Height ,
				0.1f , 
				100.0f 
			);
			openGl.MatrixMode( OpenGL.GL_MODELVIEW );
		}

	}

}
