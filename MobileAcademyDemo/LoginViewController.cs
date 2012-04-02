using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace MobileAcademyDemo
{
	public partial class LoginViewController : UIViewController
	{
		public LoginViewController () : base ("LoginViewController", null)
		{
		}
		
		partial void OnTapped (MonoTouch.UIKit.UIButton sender){
			if (textPassword.Text != "123")
				new UIAlertView("My Notes", "Wrong password!", null, "Ok").Show();
			else
			{
				var controller = new NotesTableViewController();
				var navigationController = new UINavigationController(controller);
				navigationController.SetToolbarHidden(false, false);
				this.PresentModalViewController(navigationController, true);
			}
		}
		
		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			// Perform any additional setup after loading the view, typically from a nib.
		}
		
		public override void ViewDidUnload ()
		{
			base.ViewDidUnload ();
			
			// Clear any references to subviews of the main view in order to
			// allow the Garbage Collector to collect them sooner.
			//
			// e.g. myOutlet.Dispose (); myOutlet = null;
			
			ReleaseDesignerOutlets ();
		}
		
		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			// Return true for supported orientations
			return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
		}
	}
}

