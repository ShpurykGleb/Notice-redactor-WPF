using CSharpNoticeRedactorWPF.Model;
using CSharpNoticeRedactorWPF.Models.AnimationModels;
using CSharpNoticeRedactorWPF.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;

namespace CSharpNoticeRedactorWPF
{
    /// <summary>
    /// Логика взаимодействия для AddNoticeWindow.xaml
    /// </summary>
    public partial class AddNoticeWindow : Window
    {
        //ViewModel of notices
        private readonly NoticeViewModel _noticeViewModel;

        //Parametric constructor
        public AddNoticeWindow(NoticeViewModel noticeViewModel)
        {
            InitializeComponent();

            _noticeViewModel = noticeViewModel;

            //If notices limit has been reached 
            if (_noticeViewModel.Notices.Count >= _noticeViewModel.NoticesMaxSize)
            {
                ButtonCreateNotice.IsEnabled = false;
                ButtonCreateNotice.Content = "You have reached the note limit";
            }
        }

        //Back to main window button action
        private void ButtonBackToMainWindow_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(_noticeViewModel);
            mainWindow.Show();

            Close();
        }

        //Notice text TextBox text changed action
        private void NoticeTextTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            using (CounterMaxLengthController counterMaxLengthController = new CounterMaxLengthController())
            {
                MaxLengthCounter.Text = counterMaxLengthController.CountMaxLength(NoticeTextTextBox.Text.Length);
            }
        }

        //Button create notice action
        private void ButtonCreateNotice_Click(object sender, RoutedEventArgs e)
        {
            NoticeModel newNotice;

            if (!NoticeNameTextBox.Text.Equals(""))
            {
                newNotice = new NoticeModel(NoticeNameTextBox.Text, NoticeTextTextBox.Text, DateTime.Now);
            }
            else
            {
                newNotice = new NoticeModel("ROUGH COPY", NoticeTextTextBox.Text, DateTime.Now);
            }

            _noticeViewModel.AddNotice(newNotice);

            NoticeNameTextBox.Text = "";
            NoticeTextTextBox.Text = "";

            using (AnimationModel animationModel = new AnimationModel())
            {
                animationModel.AnimationForTextBlock(TextBlockToolTip, OpacityProperty, 1, 0, 1);
            }

            using (AnimationModel animationModel = new AnimationModel())
            {
                animationModel.AnimationForTextBlock(TextBlockToolTip, OpacityProperty, 1.5, 1, 0);
            }
        }
    }
}
