using CSharpNoticeRedactorWPF.ViewModel;
using System;

namespace CSharpNoticeRedactorWPF.Model
{
    //The model that is used to work on it
    public class NoticeModel : ViewModelBase
    {
        //Notice name
        private string _name;

        //Notice text
        private string _text;

        //Notice creation date
        private DateTime _creationDate;

        //Notice name property
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                RaisePropertyChanged("Name");
            }
        }

        //Notice text property
        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
                RaisePropertyChanged("Text");
            }
        }

        //Notice creation date property
        public DateTime CreationDate
        {
            get
            {
                return _creationDate;
            }
            set
            {
                _creationDate = value;
                RaisePropertyChanged("CreationDate");
            }
        }

        //Standart constructor
        public NoticeModel() { }

        //Parametric constructor
        public NoticeModel(string name, string text, DateTime creationDate)
        {
            Name = name;
            Text = text;
            CreationDate = creationDate;
        }

    }
}
