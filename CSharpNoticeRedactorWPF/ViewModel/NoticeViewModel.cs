using CSharpNoticeRedactorWPF.Controller;
using CSharpNoticeRedactorWPF.Model;
using System.Collections.ObjectModel;

namespace CSharpNoticeRedactorWPF.ViewModel
{
    //ViewModel that view collection with notices
    public class NoticeViewModel : ViewModelBase
    {
        //Selected notice in ListBox
        private NoticeModel _selectedNotice;

        //Collection of notices
        private ObservableCollection<NoticeModel> _notices;

        //Max size of notices collection
        public readonly int NoticesMaxSize = 300;

        //Selected notice property
        public NoticeModel SelectedNotice
        {
            get
            {
                return _selectedNotice;
            }
            set
            {
                _selectedNotice = value;
                RaisePropertyChanged("SelectedNotice");
            }
        }

        //Collection of notices property
        public ObservableCollection<NoticeModel> Notices
        {
            get
            {
                return _notices;
            }
            set
            {
                _notices = value;
                RaisePropertyChanged("Notices");
            }
        }

        //Standart constructor
        public NoticeViewModel() => _notices = FileController.GetListWithNoticesFromDatabase();

        //Method that add notice to collection
        public void AddNotice(NoticeModel newNotice) => _notices.Add(newNotice);

        //Method that delete notice from collection
        public void DeleteNotice(int noticeIndex)
        {
            if (noticeIndex < 0)
            {
                return;
            }

            _notices.RemoveAt(noticeIndex);
        }
    }
}
