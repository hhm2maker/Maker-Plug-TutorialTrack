using Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TutorialTrack
{
    /// <summary>
    /// TutorialTrackUserControl.xaml 的交互逻辑
    /// </summary>
    public partial class TutorialTrackUserControl : UserControl
    {
        public TutorialTrackUserControl()
        {
            InitializeComponent();
        }


        private void LoadTutorial(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.OpenFileDialog openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            openFileDialog1.Filter = "MIDI文件|*.mid;*.midi";
            //openFileDialog1.Filter = _fileExtension.Substring(1) + "文件(*" + _fileExtension + ")|*" + _fileExtension + "|All files(*.*)|*.*";
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                List<Light> tutorialLightList = FileBusiness.CreateInstance().ReadMidiFile(openFileDialog1.FileName);
                FileUtils.oldTutorialParagraphLightIntList = LightBusiness.GetParagraphLightIntListList(tutorialLightList);
                if (FileUtils.oldTutorialParagraphLightIntList.Count == 0)
                    FileUtils.tutorialParagraphLightIntList = null;

                StartTutorial();
            }
        }

        public void StartTutorial()
        {
            if (FileUtils.tutorialParagraphLightIntList == null)
                FileUtils.tutorialParagraphLightIntList = new List<List<int>>();
            FileUtils.tutorialPosition = 0;
            FileUtils.tutorialParagraphLightIntList.Clear();

            foreach (var item in FileUtils.oldTutorialParagraphLightIntList)
            {
                List<int> ints = new List<int>();
                for (int i = 0; i < item.Count; i++)
                {
                    ints.Add(item[i]);
                }
                FileUtils.tutorialParagraphLightIntList.Add(ints);
            }
            if (FileUtils.sendLight != null)
            {
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
