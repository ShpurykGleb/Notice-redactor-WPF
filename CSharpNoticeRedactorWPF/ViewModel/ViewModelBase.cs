using System.ComponentModel;

namespace CSharpNoticeRedactorWPF.ViewModel
{
    //ViewModel that needed for inheritance to another ViewModels
    public class ViewModelBase : INotifyPropertyChanged
    {
        //Display name property
        public string DisplayName { get; set; }

        //PropertyChanged event
        public event PropertyChangedEventHandler PropertyChanged;

        //Raise property changed method
        protected virtual void RaisePropertyChanged(string propertyName = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
