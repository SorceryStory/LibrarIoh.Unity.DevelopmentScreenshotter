using SorceressSpell.LibrarIoh.Core;
using SorceressSpell.LibrarIoh.IO;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace SorceressSpell.LibrarIoh.Unity.DevelopmentScreenshotter
{
    public class DevelopmentScreenshotter : MonoBehaviour
    {
        #region Fields

        public string RelativePathToSave = "../../DevelopmentScreenshots";
        public bool PrintToConsole = true;

        public List<float> TimesToTakeScrenshot;

        #endregion Fields

        #region Methods

        public void TakeScreenshot(string pathToSave, bool printToConsole)
        {
            string directoryPath = PathOperations.Combine(Application.dataPath, pathToSave);

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            string finalPath = directoryPath + "/" + DateTime.Now.GetFileDateTimeString() + "_" + Application.productName + ".png";
            ScreenCapture.CaptureScreenshot(finalPath);

            if (printToConsole)
            {
                Debug.Log(string.Format(DevelopmentScreenshotterStrings.TextConsoleString, finalPath));
            }
        }

        public void TakeScreenshot()
        {
            TakeScreenshot(RelativePathToSave, PrintToConsole);
        }

        private void Update()
        {
            for (int i = 0; i < TimesToTakeScrenshot.Count; ++i)
            {
                if (Time.realtimeSinceStartup >= TimesToTakeScrenshot[i])
                {
                    TakeScreenshot(RelativePathToSave, PrintToConsole);

                    TimesToTakeScrenshot.RemoveAt(i);

                    --i;
                }
            }
        }

        #endregion Methods
    }
}
