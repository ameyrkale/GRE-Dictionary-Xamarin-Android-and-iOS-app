using System;
using System.IO;
using Android.App;
using System.Collections.Generic;
using Vocab.Models;
using System.ComponentModel;
using System.Threading.Tasks;


namespace Vocab.Droid
{
   
	public class FileAccessHelper
	{
        static bool exists = false;

		public static string GetLocalFilePath (string filename)
		{
			string path = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
			string dbPath = Path.Combine (path, filename);

			//string folder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			//var databasePath = Path.Combine(folder, dbName);



			CopyDatabaseIfNotExists (dbPath);

            //DisplayAlert("Alert", "Clicked ", "OK");

			return dbPath;
		}

		private static void CopyDatabaseIfNotExists (string dbPath)
		{
			if (!File.Exists (dbPath)) {
				using (var br = new BinaryReader (Application.Context.Assets.Open ("people.db3"))) {
					using (var bw = new BinaryWriter (new FileStream (dbPath, FileMode.Create))) {
						byte[] buffer = new byte[2048];
						int length = 0;
						while ((length = br.Read (buffer, 0, buffer.Length)) > 0) {
							bw.Write (buffer, 0, length);
						}
					}
				}
                exists = true;
			}
            else
            {

                exists = false;

			}
		}

    }


}

/*
 public class FileAccessHelper
    {
        public static string GetLocalFilePath(string filename)
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }

            string dbPath = Path.Combine(libFolder, filename);

            CopyDatabaseIfNotExists(dbPath);

            return dbPath;
        }

        private static void CopyDatabaseIfNotExists(string dbPath)
        {
            if (!File.Exists(dbPath))
            {
                var existingDb = NSBundle.MainBundle.PathForResource("people", "db3");
                File.Copy(existingDb, dbPath);
            }
        }
    }

 */
