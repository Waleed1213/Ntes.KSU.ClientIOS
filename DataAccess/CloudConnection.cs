using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using RestSharp;
using System.Collections.ObjectModel;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net;

namespace Ntes.KSU.ClientIOS.DataAccess
{
    class CloudConnection
    {
        private static RestClient _restClient;

        public static RestClient Rest_Client
        {
            get {
                if(_restClient==null)
                {
                    try
                    {
                        _restClient = new RestClient("https://ntestechnologies.com/dev/ksu/");
                    }
					catch(Exception E){
                       // MainActivity.CloseApplication();
                    }
                }
				return _restClient;
                }
            set { _restClient = value; }
        }
        
     
        public static void insertUser(users u)
        {
           try{
				//FBWebViewAuthActivity.pg.Show();
                       var  client = Rest_Client;

                        var request = new RestRequest("userAdd.php", Method.POST);
          
                        request.AddParameter("first_name", u.first_name);
                        request.AddParameter("last_name", u.last_name);
                        request.AddParameter("dp", u.dp);
                        request.AddParameter("facebook_id", u.facebook_id);
                        request.AddParameter("user_fb_token", u.user_fb_token);
                        request.AddParameter("created", u.created);
             RestResponse response = (RestResponse)client.Execute(request);
                         var content = response.Content; // raw content a
				//FBWebViewAuthActivity.pg.Hide();			
			}
           catch (Exception) { Console.WriteLine("Exception in Cloud insertion"); }
        }

        public static void insertComment(Comments c)
        {
            try
            {
                //FBWebViewAuthActivity.pg.Show();
                var client = Rest_Client;
                var request = new RestRequest("addComment.php", Method.POST);
              

                request.AddParameter("description",c.description);
                request.AddParameter("user_id", c.user_id);
                request.AddParameter("alert_id", c.alert_id);
                request.AddParameter("date_time", c.date_time);
                
                RestResponse response = (RestResponse)client.Execute(request);
                var content = response.Content; // raw content a
                //FBWebViewAuthActivity.pg.Hide();			
            }
            catch (Exception) { Console.WriteLine("Exception in Cloud Comment insertion"); }
        }

        public static void insertAlert(Alert A)
        {
            try
            {
               
                var client = Rest_Client;
                var request = new RestRequest("addAlert.php", Method.POST);
                
                request.AddParameter("description", A.description);
                request.AddParameter("photo", A.photo);
                request.AddParameter("user_id", A.user_id);
                request.AddParameter("date_time", A.date_time);
                
               
                RestResponse response = (RestResponse)client.Execute(request);
                var content = response.Content; // raw content a
              		
            }
            catch (Exception) { Console.WriteLine("Exception in Cloud insertion(Alert)"); }
        }

        public static ObservableCollection<AlertJson> GetAllAlerts()
        {
            ObservableCollection<AlertJson> jarray=new ObservableCollection<AlertJson>();
            try
            {
                var client = Rest_Client;
                var request = new RestRequest(Method.GET);
                request.Resource = "alerts.php";
                request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };

                IRestResponse Response = client.Execute(request);
				string str=Response.Content;
                jarray = JsonConvert.DeserializeObject<ObservableCollection<AlertJson>>(Response.Content);
				if(Response.ErrorException!=null)
				{
					//MainActivity.CloseApplication();
				}
            }
            catch(Exception E)
            {

                string str = E.Message;
            }
            return jarray;
        }

        public static users GetUser(string fb_id)
        {
            try
            {
                var client = Rest_Client;
                var request = new RestRequest(Method.POST);
                request.Resource = "userInfo.php";
                request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
                request.AddParameter("id", fb_id);
                
                IRestResponse Response = client.Execute(request);
                var selecteduser = JsonConvert.DeserializeObject<users>(Response.Content);
				if(Response.ErrorException!=null)
				{
					//MainActivity.CloseApplication();
				}
               return selecteduser;
            }
            catch (Exception)
            {
                Console.WriteLine("Exception in Cloud Get All Users(selecteduser)");
                return null;
            }
        }

        public static ObservableCollection<CommentJson> GetComments(int Alert_Id)
        {
            try
            {
                var client = Rest_Client;
                var request = new RestRequest(Method.POST);
                request.Resource = "alertComments.php";
                request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
                request.AddParameter("alert_id", Alert_Id);

                IRestResponse Response = client.Execute(request);
                var selecteduser = JsonConvert.DeserializeObject<ObservableCollection<CommentJson>>(Response.Content);
				if(Response.ErrorException!=null)
				{
				//	MainActivity.CloseApplication();
				}
				return selecteduser;
            }
            catch (Exception)
            {
                Console.WriteLine("Exception in Cloud Get All Comments against an alert");
                return null;
            }
        }
        public static void insertFavourite( AlertJson A)
        {
            try
            {
                //FBWebViewAuthActivity.pg.Show();
                var client = Rest_Client;
                var request = new RestRequest("makeFav.php", Method.POST);
               
                int id = Convert.ToInt32(A.alert_id);
                DateTime date=Convert.ToDateTime(A.date_time);
                //request.AddParameter("user_id", MainActivity.u.facebook_id);
               // request.AddParameter("alert_id", A.alert_id);
            
              

               
                RestResponse response = (RestResponse)client.Execute(request);
				if(response.ErrorException!=null)
				{
				//	MainActivity.CloseApplication();
				}
				var content = response.Content; // raw content a
               			
            }
            catch (Exception) { Console.WriteLine("Exception in Cloud insertion(Alert)"); }
           
        }
        public static void removeFavourite(users u, AlertJson A)
        {
            try
            {
                //FBWebViewAuthActivity.pg.Show();
                var client = Rest_Client;
                var request = new RestRequest("removeFav.php", Method.POST);
              
                int id = Convert.ToInt32(A.alert_id);
                DateTime date=Convert.ToDateTime(A.date_time);
                request.AddParameter("user_id", u.facebook_id);
                request.AddParameter("alert_id", A.alert_id);
            
                RestResponse response = (RestResponse)client.Execute(request);
				if(response.ErrorException!=null)
				{
				//	MainActivity.CloseApplication();
				}
				var content = response.Content; // raw content a
               	
            }
            catch (Exception) { Console.WriteLine("Exception in Cloud insertion(Alert)"); }
           
        }

    }
}