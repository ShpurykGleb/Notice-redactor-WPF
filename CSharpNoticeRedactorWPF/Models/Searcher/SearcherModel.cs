using CSharpNoticeRedactorWPF.Model;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace CSharpNoticeRedactorWPF.Models.Searcher
{
    //Model that search notices in collection
    public class SearcherModel : IDisposable
    {
        //Standart constructor
        public SearcherModel() { }

        //Method that search notices by name
        public ObservableCollection<NoticeModel> SearchNoticeWithName(ObservableCollection<NoticeModel> listWithNotices, string noticeName) => new ObservableCollection<NoticeModel>(listWithNotices.Where(x => x.Name.Contains(noticeName)));

        //Method that search notices by creation date
        public ObservableCollection<NoticeModel> SearchNoticeWithCreationDate(ObservableCollection<NoticeModel> listWithNotices, string noticeCreationdate) => new ObservableCollection<NoticeModel>(listWithNotices.Where(x => x.CreationDate.ToString() == noticeCreationdate));

        //Method that search notices by text
        public ObservableCollection<NoticeModel> SearchNoticeWithText(ObservableCollection<NoticeModel> listWithNotices, string noticeText) => new ObservableCollection<NoticeModel>(listWithNotices.Where(x => x.Text.Contains(noticeText)));

        //Destructor
        public void Dispose() { }
    }
}
