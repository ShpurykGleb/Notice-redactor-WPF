using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace CSharpNoticeRedactorWPF.Models.AnimationModels
{
    //Model that animates appearence/disappearence of TextBlock when adding a note
    internal class AnimationModel : IDisposable
    {
        //Standart constructor
        public AnimationModel() { }

        //Method that animates appearence/disappearence of TextBlock when adding a note
        public void AnimationForTextBlock(TextBlock textBlockToShow, DependencyProperty opacityProperty, double animationTime, double opacityFrom, double opacityTo)
        {
            DoubleAnimation opacityAnimationForTextBLock = new DoubleAnimation
            {
                From = opacityFrom,
                To = opacityTo,

                Duration = TimeSpan.FromSeconds(animationTime)
            };

            textBlockToShow.BeginAnimation(opacityProperty, opacityAnimationForTextBLock);
        }

        //Destructor
        public void Dispose() { }
    }
}
