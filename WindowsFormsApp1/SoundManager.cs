using NAudio.Dmo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMPLib;

namespace WindowsFormsApp1
{
    internal class SoundManager
    {
        WindowsMediaPlayer player = new WindowsMediaPlayer();

        public void MusicPlay()
        {
            player.URL = @"C:\GitHub\LiteFE\LiteFETheme\Theme1.mp3";
            player.controls.play();
        }

     
    }
}
