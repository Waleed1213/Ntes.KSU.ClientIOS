using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SQLite;
using System.IO;
namespace Ntes.KSU.ClientIOS.DataAccess
{
    public class ConnectionClass 
    {
        public static SQLiteConnection Db;
        public static string DatabaseFilePath
        {
            get
            {
                var sqliteFilename = "AppDB.db3";

                    #if NETFX_CORE
				                                    var path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, sqliteFilename);
                    #else

                    #if SILVERLIGHT
				                                    // Windows Phone expects a local path, not absolute
				                                    var path = sqliteFilename;
                    #else

                    #if __ANDROID__
                                    // Just use whatever directory SpecialFolder.Personal returns
                                    string libraryPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); ;
                    #else
				                                    // we need to put in /Library/ on iOS5.1 to meet Apple's iCloud terms
				                                    // (they don't want non-user-generated data in Documents)
				                                    string documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal); // Documents folder
				                                    string libraryPath = Path.Combine (documentsPath, "../Library/"); // Library folder
                    #endif
                                    var path = Path.Combine(libraryPath, sqliteFilename);
                    #endif

                    #endif
                return path;
            }
        }

       public ConnectionClass()
        {
            Db = new SQLiteConnection(DatabaseFilePath);
        }


       public  void CreateUserTable()
       {
          
               Db.CreateTable<users>();
           
       }

       public  void InsertUser(users usr)
       {
           try
           {
               Db.Insert(usr);

           }
            catch(Exception)
           {

           }
       }
      

        public  users SelectUser ()
        {
            var SelectedUser = Db.Query<users>("SELECT * FROM Users").FirstOrDefault();
            return SelectedUser;

        }


    }

}