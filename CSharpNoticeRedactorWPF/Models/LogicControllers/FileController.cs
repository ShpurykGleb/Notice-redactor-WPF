using CSharpNoticeRedactorWPF.Model;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.IO;

namespace CSharpNoticeRedactorWPF.Controller
{
    //Controller that works with database of notices
    public class FileController
    {
        //Database path to notices
        private static readonly string _databasePath = "Notices database.txt";

        //Static object of FileController
        private static FileController _fileController;

        //Private standart constructor
        private FileController() { }

        //Method that gives object of FileController
        public static FileController GetInstance()
        {
            if (_fileController is null)
            {
                _fileController = new FileController();
            }

            return _fileController;
        }

        //Method that gives list with notes from database
        public static ObservableCollection<NoticeModel> GetListWithNoticesFromDatabase()
        {
            try
            {
                ObservableCollection<NoticeModel> notices = JsonConvert.DeserializeObject<ObservableCollection<NoticeModel>>(File.ReadAllText(_databasePath));

                return notices;
            }
            catch (Exception)
            {
                return new ObservableCollection<NoticeModel>();
            }
        }

        //Method that write list with notes to database
        public static void WriteListWithNoticesToDatabase(ObservableCollection<NoticeModel> notices)
        {
            string JSONnotices = JsonConvert.SerializeObject(notices);

            File.WriteAllText(_databasePath, JSONnotices);
        }
    }
}
