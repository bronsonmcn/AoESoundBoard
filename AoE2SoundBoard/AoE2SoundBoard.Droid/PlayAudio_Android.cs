//Written by Bronson McNaughton, 2015.
using System;
using Android.Speech.Tts;
using Xamarin.Forms;
using AoE2SoundBoard.Droid;
using System.Collections.Generic;
using AoE2SoundBoard;

[assembly: Dependency(typeof(TextToSpeech_Android))]

namespace AoE2SoundBoard.Droid
{
    public class TextToSpeech_Android : Java.Lang.Object, IPlayAudio, TextToSpeech.IOnInitListener
    {
        TextToSpeech speaker; string toSpeak;
        public TextToSpeech_Android() { }

        public void Play(string text)
        {
            var c = Forms.Context;
            toSpeak = text;
            if (speaker == null)
            {
                speaker = new TextToSpeech(c, this);
            }
            else
            {
                var p = new Dictionary<string, string>();
                speaker.Speak(toSpeak, QueueMode.Flush, p);
                System.Diagnostics.Debug.WriteLine("spoke " + toSpeak);
            }
        }

        #region IOnInitListener implementation
        public void OnInit(OperationResult status)
        {
            if (status.Equals(OperationResult.Success))
            {
                System.Diagnostics.Debug.WriteLine("speaker init");
                var p = new Dictionary<string, string>();
                speaker.Speak(toSpeak, QueueMode.Flush, p);
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("was quiet");
            }
        }
        #endregion
    }
}
