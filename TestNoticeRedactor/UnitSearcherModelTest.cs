using CSharpNoticeRedactorWPF.Model;
using CSharpNoticeRedactorWPF.Models.Searcher;
using System.Collections.ObjectModel;

namespace TestNoticeRedactor
{
    //Test SearcherModel
    public class UnitSearcherModelTest
    {
        //Test SearchNoticeWithName
        [Fact]
        public void TestSearchNoticeWithName()
        {
            ObservableCollection<NoticeModel> listWithNotices = new ObservableCollection<NoticeModel>
            {
                new NoticeModel("bebebe", "rarara", DateTime.Now),
                new NoticeModel("rerere", "rarara", DateTime.Now),
                new NoticeModel("lololo", "rarara", DateTime.Now)
            };

            using (SearcherModel searcherModel = new SearcherModel())
            {
                Assert.Contains(listWithNotices[0], searcherModel.SearchNoticeWithName(listWithNotices, "bebebe"));
            }
        }

        //Test SearchNoticeWithCreationDate
        [Fact]
        public void TestSearchNoticeWithCreationDate()
        {
            DateTime date = DateTime.Now;
            ObservableCollection<NoticeModel> listWithNotices = new ObservableCollection<NoticeModel>
            {
                new NoticeModel("bebebe", "rarara", date),
                new NoticeModel("rerere", "rarara", date),
                new NoticeModel("lololo", "rarara", date)
            };

            using (SearcherModel searcherModel = new SearcherModel())
            {
                Assert.Contains(listWithNotices[1], searcherModel.SearchNoticeWithCreationDate(listWithNotices, date.ToString()));
            }
        }

        //Test SearchNoticeWithText
        [Fact]
        public void TestSearchNoticeWithText()
        {
            ObservableCollection<NoticeModel> listWithNotices = new ObservableCollection<NoticeModel>
            {
                new NoticeModel("bebebe", "rarara", DateTime.Now),
                new NoticeModel("rerere", "rarara", DateTime.Now),
                new NoticeModel("lololo", "ADSSSASDSSDSSDSDDSrarara", DateTime.Now)
            };

            using (SearcherModel searcherModel = new SearcherModel())
            {
                Assert.Contains(listWithNotices[2], searcherModel.SearchNoticeWithText(listWithNotices, "ADSSSASDSSDSSDSDDSrarara"));
            }
        }
    }
}
