using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AoE2SoundBoard
{
    class SoundBoardPage : ContentPage
    {
        int count = 0;

        public SoundBoardPage()
        {
            Button button = new Button
            {
                Text = String.Format("Test")
            };
            button.Clicked += (sender, args) =>
            {
                DependencyService.Get<IPlayAudio>().Play();
            };

            this.Content = button;
        }
    }
}
