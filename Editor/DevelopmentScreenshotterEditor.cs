using UnityEditor;
using UnityEngine;

namespace SorceressSpell.LibrarIoh.Unity.DevelopmentScreenshotter.Editor
{
    [CustomEditor(typeof(DevelopmentScreenshotter))]
    public class DevelopmentScreenshotterEditor : UnityEditor.Editor
    {
        #region Fields

        private DevelopmentScreenshotter _editorTarget;

        #endregion Fields

        #region Methods

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            AppendTakeScreenshotButton();
        }

        private void AppendTakeScreenshotButton()
        {
            if (GUILayout.Button(DevelopmentScreenshotterEditorStrings.LabelButtonTakeScreenshot))
            {
                _editorTarget.TakeScreenshot();
            }
        }

        private void OnEnable()
        {
            _editorTarget = (DevelopmentScreenshotter)target;
        }

        #endregion Methods
    }
}
