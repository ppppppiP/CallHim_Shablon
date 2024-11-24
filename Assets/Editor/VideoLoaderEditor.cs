using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(VideoLoader))]
public class VideoLoaderEditor : Editor
{
    public override void OnInspectorGUI()
    {
        VideoLoader videoLoader = (VideoLoader)target;

        string[] videoFiles = System.IO.Directory.GetFiles(Application.streamingAssetsPath, "*.mp4");

        string[] fileNames = new string[videoFiles.Length];
        for (int i = 0; i < videoFiles.Length; i++)
        {
            fileNames[i] = System.IO.Path.GetFileName(videoFiles[i]);
        }

        int selectedIndex = EditorGUILayout.Popup("Select Video File", videoLoader.selectedFileIndex, fileNames);
        if (selectedIndex != videoLoader.selectedFileIndex)
        {
            videoLoader.selectedFileIndex = selectedIndex;
            videoLoader.videoFileName = fileNames[selectedIndex];

            EditorUtility.SetDirty(videoLoader);

            AssetDatabase.SaveAssets();
        }

        DrawDefaultInspector();
    }
}