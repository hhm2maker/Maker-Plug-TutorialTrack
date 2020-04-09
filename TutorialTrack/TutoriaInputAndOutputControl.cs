using Operation;
using PlugLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorialTrack
{
    class TutoriaInputAndOutputControl : IInputAndOutputControl
    {
        public void OnInput(int position, InputAndOutputControlEnum.KeyModel keyModel)
        {
            if (FileUtils.tutorialParagraphLightIntList.Count > FileUtils.tutorialPosition) {
                if (keyModel == InputAndOutputControlEnum.KeyModel.KeyDown)
                {
                    if (FileUtils.tutorialParagraphLightIntList[FileUtils.tutorialPosition].Contains(position))
                    {
                        FileUtils.tutorialParagraphLightIntList[FileUtils.tutorialPosition].Remove((int)position);
                        List<Light> ll = new List<Light>() { new Light(0, 128, position, 64) };
                        FileBusiness.CreateInstance().ReplaceControl(ll, FileBusiness.CreateInstance().midiArr);
                        if (FileUtils.sendLight != null)
                        {
                            FileUtils.sendLight(ll);
                        }
                    }

                    if (FileUtils.tutorialParagraphLightIntList[FileUtils.tutorialPosition].Count == 0)
                    {
                        FileUtils.tutorialPosition++;
                        FileUtils.tutorialPosition = FileUtils.tutorialPosition % FileUtils.tutorialParagraphLightIntList.Count;

                        List<Light> ll = new List<Light>();
                        for (int j = 0; j < FileUtils.tutorialParagraphLightIntList[FileUtils.tutorialPosition].Count; j++)
                        {
                            ll.Add(new Light(0, 144, FileUtils.tutorialParagraphLightIntList[FileUtils.tutorialPosition][j], 3));
                        }
                        FileBusiness.CreateInstance().ReplaceControl(ll, FileBusiness.CreateInstance().midiArr);

                        FileUtils.sendLight(ll);
                    }
                }
            }
        }

        
        public void OutputLight(InputAndOutputControlEnum.SendLight sendLight)
        {
            FileUtils.sendLight = sendLight;
        }
    }
}