using CSharpNoticeRedactorWPF.Controller;
using CSharpNoticeRedactorWPF.Model;
using CSharpNoticeRedactorWPF.Models.Sorter;
using CSharpNoticeRedactorWPF.ViewModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace CSharpNoticeRedactorWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //ViewModel of notices
        private readonly NoticeViewModel _viewModel;

        //Standart constructor
        public MainWindow()
        {
            InitializeComponent();

            _viewModel = new NoticeViewModel();

            DataContext = _viewModel;

            Closing += MainWindow_Closing;
        }

        //Parametric constructor
        public MainWindow(NoticeViewModel noticeViewModel)
        {
            InitializeComponent();

            _viewModel = noticeViewModel;

            DataContext = _viewModel;

            Closing += MainWindow_Closing;
        }

        //Notice text TextBox text changed action
        private void NoticeTextTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            using (CounterMaxLengthController counterMaxLengthController = new CounterMaxLengthController())
            {
                MaxLengthCounter.Text = counterMaxLengthController.CountMaxLength(NoticeTextTextBox.Text.Length);
            }
        }

        //MainWindow closing action
        private void MainWindow_Closing(object sender, CancelEventArgs e) => FileController.WriteListWithNoticesToDatabase(_viewModel.Notices);

        //Button delete action
        private void ButtonDeleteNotice_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.DeleteNotice(ListBoxWithNotices.SelectedIndex);
            DataContext = _viewModel;

            using (VisibilityModel visibilityModel = new VisibilityModel())
            {
                visibilityModel.ChangeElementsVisibilityForMainWindow(LabelNoticeName, LabelNoticeCreationTime, LabelNoticeText, NoticeNameTextBox, NoticeCreationTimeTextBox, NoticeTextTextBox, MaxLengthCounter, ButtonDeleteNotice, Visibility.Hidden);
            }
        }

        //ListBox with notice selection changed action
        private void ListBoxWithNotices_SelectionChanged(object sender, RoutedEventArgs e)
        {
            using (VisibilityModel visibilityModel = new VisibilityModel())
            {
                visibilityModel.ChangeElementsVisibilityForMainWindow(LabelNoticeName, LabelNoticeCreationTime, LabelNoticeText, NoticeNameTextBox, NoticeCreationTimeTextBox, NoticeTextTextBox, MaxLengthCounter, ButtonDeleteNotice, Visibility.Visible);
            }
        }

        //Button add notice action
        private void ButtonAddNotice_Click(object sender, RoutedEventArgs e)
        {
            AddNoticeWindow addNoticeWindow = new AddNoticeWindow(_viewModel);
            addNoticeWindow.Show();

            Close();
        }

        //ComboBox with sort styles selection changed action
        private void ComboBoxWithSortStyles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            using (SorterModel sorterModel = new SorterModel())
            {
                sorterModel.Sort(ListBoxWithNotices, ComboBoxWithSortStyles.SelectedIndex);
            }
        }

        //Button find notice action
        private void ButtonFindNotice_Click(object sender, RoutedEventArgs e)
        {
            SearchNoticeWindow searchNoticeWIndow = new SearchNoticeWindow(_viewModel);
            searchNoticeWIndow.Show();

            Close();
        }
    }
}
