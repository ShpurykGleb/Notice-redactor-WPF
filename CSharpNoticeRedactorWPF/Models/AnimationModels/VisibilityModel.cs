using System;
using System.Windows;
using System.Windows.Controls;

namespace CSharpNoticeRedactorWPF.Model
{
    //Model that changes the visibility of objects
    internal class VisibilityModel : IDisposable
    {
        //Standart constructor
        public VisibilityModel() { }

        //Method that changes visibility of Labels which explain displaying data about the note
        private void ChangeLabelsVisibility(Label LabelNoticeName, Label LabelNoticeCreationTime, Label LabelNoticeText, Visibility visibility)
        {
            LabelNoticeName.Visibility = visibility;
            LabelNoticeCreationTime.Visibility = visibility;
            LabelNoticeText.Visibility = visibility;
        }

        //Method that changes visibility of TextBoxes which displaying data about the note
        private void ChangeTextBoxesVisibility(TextBox NoticeNameTextBox, TextBox NoticeCreationTimeTextBox, TextBox NoticeTextTextBox, TextBox MaxLengthCounter, Visibility visibility)
        {
            NoticeNameTextBox.Visibility = visibility;
            NoticeCreationTimeTextBox.Visibility = visibility;
            NoticeTextTextBox.Visibility = visibility;
            MaxLengthCounter.Visibility = visibility;
        }

        //Method that changes visibility of Button that delete notice
        private void MakeDeleteButtonVisible(Button DeleteNoticeButton, Visibility visibility) => DeleteNoticeButton.Visibility = visibility;

        //Method that changes visibility of elements in MainWindow
        public void ChangeElementsVisibilityForMainWindow(Label LabelNoticeName, Label LabelNoticeCreationTime, Label LabelNoticeText, TextBox NoticeNameTextBox, TextBox NoticeCreationTimeTextBox, TextBox NoticeTextTextBox, TextBox MaxLengthCounter, Button DeleteNoticeButton, Visibility visibility)
        {
            ChangeLabelsVisibility(LabelNoticeName, LabelNoticeCreationTime, LabelNoticeText, visibility);

            ChangeTextBoxesVisibility(NoticeNameTextBox, NoticeCreationTimeTextBox, NoticeTextTextBox, MaxLengthCounter, visibility);

            MakeDeleteButtonVisible(DeleteNoticeButton, visibility);
        }

        //Method that changes visibility of elements in SearchWindow
        public void ChangeElementsVisibilityForSearchWindow(Label LabelNoticeName, Label LabelNoticeCreationTime, Label LabelNoticeText, TextBox NoticeNameTextBox, TextBox NoticeCreationTimeTextBox, TextBox NoticeTextTextBox, TextBox MaxLengthCounter, Visibility visibility)
        {
            ChangeLabelsVisibility(LabelNoticeName, LabelNoticeCreationTime, LabelNoticeText, visibility);

            ChangeTextBoxesVisibility(NoticeNameTextBox, NoticeCreationTimeTextBox, NoticeTextTextBox, MaxLengthCounter, visibility);
        }

        //Method that changes visibility of elements in search by name style in SearchWindow
        public void ChangeElementsVisibilityForSearchByName(Label LabelEnterNoticeName, TextBox NoticeEnterNameTextBox, Visibility visibility)
        {
            LabelEnterNoticeName.Visibility = visibility;
            NoticeEnterNameTextBox.Visibility = visibility;
        }

        //Destructor
        public void Dispose() { }
    }
}
