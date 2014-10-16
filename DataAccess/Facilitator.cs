
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using MonoTouch.UIKit;
using MonoTouch.Foundation;


namespace Ntes.KSU.ClientIOS.DataAccess
{
    public class Facilitator
    {
        public static Dictionary<string,UIImage> dic_urls;
        private static Facilitator _default;
       // private static TwitterService mTwitter;
        public static Facilitator Default
        {
            get {
                if(_default==null)
                {
                    _default = new Facilitator();
                }
                return _default; }
            set { _default = value; }
        }
        
       private Facilitator()
        {
            dic_urls = new Dictionary<string,UIImage>();
        }

		public static void loadImage(UIImageView imageView)
        {
            UIImage imageUIImage;
			imageView.Image=UIImage.FromBundle("defaultImage.png");
            if (!(dic_urls.ContainsKey(imageView.Tag + "")))
            {
               
               
                   dic_urls.Add(imageView.Tag + "", GetImageUIImageFromUrl(imageView.Tag + ""));
               
              
               
            }
            
                imageUIImage = dic_urls[imageView.Tag + ""];
            
             
                // UIImage rounded_bmp = getRoundedShape(imageUIImage);
               
                //UIImage circleUIImage = UIImage.CreateUIImage(bitmapwidth, bitmaphight, UIImage.Config.Argb8888);

               /* UIImageShader shader = new UIImageShader(imageUIImage, Android.Graphics.Shader.TileMode.Clamp, Android.Graphics.Shader.TileMode.Clamp);
                Paint paint = new Paint();
                paint.SetShader(shader);
                paint.AntiAlias = true;
                Canvas c = new Canvas(circleUIImage);
                c.DrawCircle(bitmapwidth / 2, bitmaphight / 2, radius, paint);
                //  bmpCopy.DrawImage(0, 0, bmpMyUIImage, 0, 0, bmpMyUIImage.Width, bmpMyUIImage.Height);
                //  imageUIImage.Ecl   */
                
            
        }
        public string TimeToShow(DateTime D)
        {
            string str = "";
            TimeSpan TimeDifference = DateTime.Now - D;
            if (TimeDifference.TotalMinutes < 1)
            {
                str = "Just Now";
            }
            if (TimeDifference.TotalMinutes >= 1 && TimeDifference.TotalHours < 1)
            {
                str = Convert.ToInt32(TimeDifference.TotalMinutes )+ "M";
            }
            else if (TimeDifference.TotalHours >= 1 && TimeDifference.TotalHours <= 12)
            {
                str = Convert.ToInt32(TimeDifference.TotalHours) + "H";
            }
            else if (TimeDifference.TotalHours > 12)
            {
                str = D.Day + "-" + D.Month + "-" + D.Year;
            }
            return str;
        }
		public static UIImage GetImageUIImageFromUrl (string uri)
		{
			using (var url = new NSUrl (uri))
			using (var data = NSData.FromUrl (url))
				return UIImage.LoadFromData (data);
		}
       
       /* public UIImage getRoundedShape(UIImage scaleUIImageImage, int targetWidth, int targetHeight)
        {
            
            UIImage targetUIImage = UIImage.CreateUIImage(targetWidth,
                                targetHeight, UIImage.Config.Argb8888);

            Canvas canvas = new Canvas(targetUIImage);
            Path path = new Path();
            path.AddCircle(((float)targetWidth - 1) / 2,
                ((float)targetHeight - 1) / 2,
                (Math.Min(((float)targetWidth),
                ((float)targetHeight)) / 2),
                Path.Direction.Ccw);

            canvas.ClipPath(path);
            UIImage sourceUIImage = scaleUIImageImage;
            canvas.DrawUIImage(sourceUIImage, new Rect(0, 0, sourceUIImage.Width, sourceUIImage.Height), new Rect(0, 0, targetWidth, targetHeight), null);
            return targetUIImage;
        }
        static string ConsumerKey = "ROifEyIJOfYuiGeV2Eslm9U40";
        static string ConsumerSecret = "3kNqQPhM7NVN1y8q6r1bZ2ClTJNX60WLEiNw2fm028eSSO8ife";
        static Uri CallbackUrl = new Uri("https://www.facebook.com/connect/login_success.html");
        public static TwitterService Twitter
        {

            get
            {

                if (mTwitter == null)
                {
                    mTwitter = new TwitterService
                    {
                        ConsumerKey = "ROifEyIJOfYuiGeV2Eslm9U40",
                        ConsumerSecret = "3kNqQPhM7NVN1y8q6r1bZ2ClTJNX60WLEiNw2fm028eSSO8ife",
                        CallbackUrl = new Uri("https://www.facebook.com/connect/login_success.html")
                    };
                }
               
                return mTwitter;
            }
        }*/
    }
}
