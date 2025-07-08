using UnityEditor;
using UnityEngine;
using System;

[InitializeOnLoad]
public static class AutoSave
{
    private static double saveInterval = 300; // 300 saniye = 5 dakika
    private static DateTime lastSaveTime = DateTime.Now;

    static AutoSave()
    {
        EditorApplication.update += OnEditorUpdate;
    }

    private static void OnEditorUpdate()
    {
        if ((DateTime.Now - lastSaveTime).TotalSeconds > saveInterval)
        {
            SaveScene();
            lastSaveTime = DateTime.Now;
        }
    }

    private static void SaveScene()
    {
        if (!EditorApplication.isPlaying)
        {
            Debug.Log("Auto-Saving Scene: " + UnityEditor.SceneManagement.EditorSceneManager.GetActiveScene().name);
            UnityEditor.SceneManagement.EditorSceneManager.SaveOpenScenes();
            AssetDatabase.SaveAssets();
        }
    }
}
