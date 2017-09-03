namespace ManaChan.PopUp.Models {

	/// <summary>
	/// PINコード発行者
	/// </summary>
	public interface IPinCodePublisher {

		/// <summary>
		/// PINコード発行
		/// </summary>
		/// <param name="pinCode">PINコード</param>
		void Publish( int pinCode );

	}

}
