// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace Ntes.KSU.ClientIOS
{
	[Register ("AlertCell")]
	partial class AlertCell
	{
		[Outlet]
		MonoTouch.UIKit.UIImageView img_alert_dp { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel lbl_alert_desc { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel lbl_alert_time { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel lbl_alert_Uname { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (img_alert_dp != null) {
				img_alert_dp.Dispose ();
				img_alert_dp = null;
			}

			if (lbl_alert_Uname != null) {
				lbl_alert_Uname.Dispose ();
				lbl_alert_Uname = null;
			}

			if (lbl_alert_time != null) {
				lbl_alert_time.Dispose ();
				lbl_alert_time = null;
			}

			if (lbl_alert_desc != null) {
				lbl_alert_desc.Dispose ();
				lbl_alert_desc = null;
			}
		}
	}
}
