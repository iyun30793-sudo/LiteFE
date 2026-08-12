using System.IO;
using System.Windows.Forms;
using WMPLib;

namespace WindowsFormsApp1
{
    internal class SoundManager
    {
        WindowsMediaPlayer player = new WindowsMediaPlayer();

        public void MusicPlay()
        {
            string theme1Path = Path.Combine(Path.GetTempPath(),"Theme1.mp3");

            File.WriteAllBytes(theme1Path, Properties.Resources.Theme1);

            player.URL = theme1Path;

            player.controls.play();
            player.controls.currentPosition = 28;

        }
       
     
    }
}
