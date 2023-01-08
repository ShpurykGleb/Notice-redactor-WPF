using CSharpNoticeRedactorWPF.Model;

namespace TestNoticeRedactor
{
    //Test CounterMaxLengthController 
    public class UnitCounterMaxLengthControllerTest
    {
        //Test CountMaxLength
        [Fact]
        public void TestCountMaxLength()
        {
            using (CounterMaxLengthController counterMaxLengthController = new CounterMaxLengthController())
            {
                Assert.Equal("130/256", counterMaxLengthController.CountMaxLength(130));
            }
        }
    }
}