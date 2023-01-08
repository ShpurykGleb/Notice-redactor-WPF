using System;

namespace CSharpNoticeRedactorWPF.Model
{
    //Controller that count symbols in notice text TextBox
    public class CounterMaxLengthController : IDisposable
    {
        //Max length of text
        private readonly string _maxLength = "256";

        //Standart constructor
        public CounterMaxLengthController() { }

        //Method that counts symbols in notice text TextBox
        public string CountMaxLength(int textLength) => textLength.ToString() + "/" + _maxLength;

        //Destructor
        public void Dispose() { }
    }
}
