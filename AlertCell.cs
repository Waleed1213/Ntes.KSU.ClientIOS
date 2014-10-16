
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Ntes.KSU.ClientIOS
{
	public partial class AlertCell : UITableViewCell
	{
		public static readonly UINib Nib = UINib.FromName ("AlertCell", NSBundle.MainBundle);
		public static readonly NSString Key = new NSString ("AlertCell");

		public AlertCell (IntPtr handle) : base (handle)
		{
		}

		public static AlertCell Create ()
		{
			return (AlertCell)Nib.Instantiate (null, null) [0];
		}
		public UILabel Lbl_InformerName {
			get{return lbl_alert_Uname; }
			set{ lbl_alert_Uname = value; }
		}
		public UILabel Lbl_AlertTime {
			get{ return lbl_alert_time;}
			set{lbl_alert_time=value;}
		}
		public UILabel Lbl_AlertDesc {
			get{ return lbl_alert_desc;}
			set{ lbl_alert_desc = value;}
		
			}
		public UIImageView Img_alert_dp {
			get{ return img_alert_dp;}
			set{img_alert_dp=value;}
		}
		}

}

