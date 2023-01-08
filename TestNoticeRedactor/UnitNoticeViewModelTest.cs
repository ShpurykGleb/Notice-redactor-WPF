using CSharpNoticeRedactorWPF.Model;
using CSharpNoticeRedactorWPF.ViewModel;

namespace TestNoticeRedactor
{
    //Test NoticeViewModel 
    public class UnitNoticeViewModelTest
    {
        //Test AddNotice
        [Fact]
        public void TestAddNotice()
        {
            NoticeViewModel noticeViewModel = new NoticeViewModel();
            noticeViewModel.AddNotice(new NoticeModel("asd", "asd", DateTime.Now));

            Assert.Contains(noticeViewModel.Notices[0], noticeViewModel.Notices);
        }

        //Test DeleteNotice
        [Fact]
        public void TestDeleteNotice()
        {
            NoticeViewModel noticeViewModel = new NoticeViewModel();

            noticeViewModel.AddNotice(new NoticeModel("asd", "asd", DateTime.Now));
            noticeViewModel.DeleteNotice(0);

            Assert.DoesNotContain(new NoticeModel("asd", "asd", DateTime.Now), noticeViewModel.Notices);
        }
    }
}
