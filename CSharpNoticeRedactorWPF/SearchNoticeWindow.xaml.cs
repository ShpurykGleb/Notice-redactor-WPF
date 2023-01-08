using CSharpNoticeRedactorWPF.Model;
using CSharpNoticeRedactorWPF.Models.Searcher;
using CSharpNoticeRedactorWPF.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace CSharpNoticeRedactorWPF
{
    /// <summary>
    /// Логика взаимодействия для SearchNoticeWIndow.xaml
    /// </summary>
    public partial class SearchNoticeWindow : Window
    {
        //ViewModel of notices
        private readonly NoticeViewModel _noticeViewModel;

        //Standart constructor
        public SearchNoticeWindow()
        {
            InitializeComponent();

            _noticeViewModel = new NoticeViewModel();

            RadioButtonSearchWithName.IsChecked = true;
        }

        //Parametric constructor
        public SearchNoticeWindow(NoticeViewModel noticeViewModel)
        {
            InitializeComponent();

            _noticeViewModel = noticeViewModel;

            RadioButtonSearchWithName.IsChecked = true;
        }

        //Back to main window button click
        private void ButtonBackToMainWindow_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(_noticeViewModel);
            mainWindow.Show();

            Close();
        }

        //ListBox with notices selection changed action
        private void ListBoxWithNotices_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            using (VisibilityModel visibilityModel = new VisibilityModel())
            {
                visibilityModel.ChangeElementsVisibilityForSearchWindow(LabelNoticeName, LabelNoticeCreationTime, LabelNoticeText, NoticeNameTextBox, NoticeCreationTimeTextBox, NoticeTextTextBox, MaxLengthCounter, Visibility.Visible);
            }
        }

        //Notice text TextBox text changed action
        private void NoticeTextTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            using (CounterMaxLengthController counterMaxLengthController = new CounterMaxLengthController())
            {
                MaxLengthCounter.Text = counterMaxLengthController.CountMaxLength(NoticeTextTextBox.Text.Length);
            }
        }

        //RadioButton search with name checked action
        private void RadioButtonSearchWithName_Checked(object sender, RoutedEventArgs e)
        {
            using (VisibilityModel visibilityModel = new VisibilityModel())
            {
                visibilityModel.ChangeElementsVisibilityForSearchByName(LabelEnterNoticeName, NoticeEnterNameTextBox, Visibility.Visible);
            }
        }

        //RadioButton search with name unchecked action
        private void RadioButtonSearchWithName_Unchecked(object sender, RoutedEventArgs e)
        {
            ListBoxWithNotices.UnselectAll();
            using (VisibilityModel visibilityModel = new VisibilityModel())
            {
                visibilityModel.ChangeElementsVisibilityForSearchByName(LabelEnterNoticeName, NoticeEnterNameTextBox, Visibility.Hidden);

                NoticeEnterNameTextBox.Text = "";

                LabelFoundNotes.Content = "Notes not found";

                NoticeViewModel temp = new NoticeViewModel();
                temp.Notices.Clear();

                DataContext = temp;
            }
        }

        //Notice enter name TextBox text changed action
        private void NoticeEnterNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            using (SearcherModel searcherModel = new SearcherModel())
            {
                NoticeViewModel temp = new NoticeViewModel();

                if (!NoticeEnterNameTextBox.Text.Equals(""))
                {
                    temp.Notices = searcherModel.SearchNoticeWithName(_noticeViewModel.Notices, NoticeEnterNameTextBox.Text);
                }
                else
                {
                    temp.Notices.Clear();
                    LabelFoundNotes.Content = "Notes not found";
                }

                if (temp.Notices.Count > 0)
                {
                    LabelFoundNotes.Content = "Found notes";
                }

                DataContext = temp;
            }
        }
        
        //Notice name TextBox text changed action
        private void NoticeNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var temp = DataContext as NoticeViewModel;
            for (int i = 0; i < _noticeViewModel.Notices.Count; i++)
            {
                if (_noticeViewModel.Notices[i].CreationDate == temp.SelectedNotice.CreationDate)
                {
                    _noticeViewModel.Notices[i] = temp.Notices[ListBoxWithNotices.SelectedIndex];
                }
            }
        }

        //Notice enter creation date TextBox text changed action
        private void NoticeEnterCreationDateTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            using (SearcherModel searcherModel = new SearcherModel())
            {
                string date = NoticeEnterCreationDateTextBox.Text;
                NoticeViewModel temp = new NoticeViewModel
                {
                    Notices = searcherModel.SearchNoticeWithCreationDate(_noticeViewModel.Notices, date)
                };

                if (!date.Equals(""))
                {
                    temp.Notices = searcherModel.SearchNoticeWithCreationDate(_noticeViewModel.Notices, date);
                }
                else
                {
                    temp.Notices.Clear();
                    LabelFoundNotes.Content = "Notes not found";
                }

                if (temp.Notices.Count > 0)
                {
                    LabelFoundNotes.Content = "Found notes";

                }

                DataContext = temp;
            }
        }

        //RadioButton search with creation date checked action
        private void RadioButtonSearchWithCreationDate_Checked(object sender, RoutedEventArgs e)
        {
            using (VisibilityModel visibilityModel = new VisibilityModel())
            {
                visibilityModel.ChangeElementsVisibilityForSearchByName(LabelEnterCreationDate, NoticeEnterCreationDateTextBox, Visibility.Visible);
            }
        }

        //RadioButton search with creation date unchecked action
        private void RadioButtonSearchWithCreationDate_Unchecked(object sender, RoutedEventArgs e)
        {
            ListBoxWithNotices.UnselectAll();
            using (VisibilityModel visibilityModel = new VisibilityModel())
            {
                visibilityModel.ChangeElementsVisibilityForSearchByName(LabelEnterCreationDate, NoticeEnterCreationDateTextBox, Visibility.Hidden);

                NoticeEnterTextTextBox.Text = "";

                LabelFoundNotes.Content = "Notes not found";

                NoticeViewModel temp = new NoticeViewModel();
                temp.Notices.Clear();

                DataContext = temp;
            }
        }

        //Notice enter text TextBox text changed action
        private void NoticeEnterTextTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            using (CounterMaxLengthController counterMaxLengthController = new CounterMaxLengthController())
            {
                MaxLengthCounterForEnterText.Text = counterMaxLengthController.CountMaxLength(NoticeEnterTextTextBox.Text.Length);
            }

            using (SearcherModel searcherModel = new SearcherModel())
            {

                NoticeViewModel temp = new NoticeViewModel();

                if (!NoticeEnterTextTextBox.Text.Equals(""))
                {
                    temp.Notices = searcherModel.SearchNoticeWithText(_noticeViewModel.Notices, NoticeEnterTextTextBox.Text);
                }
                else
                {
                    temp.Notices.Clear();
                    LabelFoundNotes.Content = "Notes not found";
                }

                if (temp.Notices.Count > 0)
                {
                    LabelFoundNotes.Content = "Found notes";
                }

                DataContext = temp;
            }
        }

        //RadioButton search with text checked action
        private void RadioButtonSearchWithText_Checked(object sender, RoutedEventArgs e)
        {
            using (VisibilityModel visibilityModel = new VisibilityModel())
            {
                visibilityModel.ChangeElementsVisibilityForSearchByName(LabelEnterText, NoticeEnterTextTextBox, Visibility.Visible);
                MaxLengthCounterForEnterText.Visibility = Visibility.Visible;
            }
        }

        //RadioButton search with text unchecked action
        private void RadioButtonSearchWithText_Unchecked(object sender, RoutedEventArgs e)
        {
            ListBoxWithNotices.UnselectAll();
            using (VisibilityModel visibilityModel = new VisibilityModel())
            {
                visibilityModel.ChangeElementsVisibilityForSearchByName(LabelEnterText, NoticeEnterTextTextBox, Visibility.Hidden);

                MaxLengthCounterForEnterText.Visibility = Visibility.Hidden;

                NoticeEnterTextTextBox.Text = "";

                LabelFoundNotes.Content = "Notes not found";

                NoticeViewModel temp = new NoticeViewModel();
                temp.Notices.Clear();

                DataContext = temp;
            }
        }
    }
}
