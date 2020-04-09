using PlugLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorialTrack
{
    public class FileUtils
    {
        public static int tutorialPosition = 0;
        public static List<List<int>> oldTutorialParagraphLightIntList = new List<List<int>>();
        public static List<List<int>> tutorialParagraphLightIntList = new List<List<int>>();

        public static TutorialTrackUserControl tutorialTrackUserControl = new TutorialTrackUserControl();
        public static List<IControl> iControls = new List<IControl>() { new TutoriaInputAndOutputControl() };

        public static InputAndOutputControlEnum.SendLight sendLight;
    }
}
