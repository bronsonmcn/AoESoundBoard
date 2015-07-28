//Written by Bronson McNaughton, 2015.
using System;
using Xamarin.Forms;
using AoE2SoundBoard.Droid;
using Android.Media;

[assembly: Dependency(typeof(PlayAudio_Android))]

namespace AoE2SoundBoard.Droid
{
    public class PlayAudio_Android : IPlayAudio
    {
        public PlayAudio_Android() { }

        private MediaPlayer _player;

        public bool Play()
        {
            _player = MediaPlayer.Create(global::Android.App.Application.Context, Resource.Raw._01yes);
            _player.Start();
            _player.Completion += delegate
            {
                _player.Release();
            };

            return true;
        }
    }
}
