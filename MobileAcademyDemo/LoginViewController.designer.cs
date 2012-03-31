// WARNING
//
// This file has been generated automatically by MonoDevelop to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace MobileAcademyDemo
{
	[Register ("LoginViewController")]
	partial class LoginViewController
	{
		[Outlet]
		MonoTouch.UIKit.UILabel lblMessage { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField textPassword { get; set; }

		[Action ("OnTapped:")]
		partial void OnTapped (MonoTouch.UIKit.UIButton sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (lblMessage != null) {
				lblMessage.Dispose ();
				lblMessage = null;
			}

			if (textPassword != null) {
				textPassword.Dispose ();
				textPassword = null;
			}
		}
	}
}
