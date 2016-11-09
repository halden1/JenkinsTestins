using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
using System.Collections.Generic;

public class BuildEditor : MonoBehaviour {

    static string[] sceneNames = FindEnabledEditorScene();
    [MenuItem("Build/Windows(x86)")]
    static void PerformWindowsx86Build()
    {
        string targetDir = "Build/Windows(x86)"+PlayerSettings.productName+".exe";
        GenericBuild(targetDir,BuildTarget.StandaloneWindows,BuildOptions.None);
    }
    static void GenericBuild(string targetDir, BuildTarget buildTarget, BuildOptions buildOptions)
    {
        EditorUserBuildSettings.SwitchActiveBuildTarget(buildTarget);
        string resu = BuildPipeline.BuildPlayer(sceneNames,targetDir,buildTarget, buildOptions);
        if (resu.Length > 0)
        {
            Debug.Log("Oi Mate there was a fuckn errer in the build "+resu);
            System.Console.WriteLine("Oi Mate there was a fuckn errer in the build " + resu);
        }
    }
    static string[] FindEnabledEditorScene()
    {
        List<string> editorScenes = new List<string>();
        foreach (EditorBuildSettingsScene scene in EditorBuildSettings.scenes)
        {
            editorScenes.Add(scene.path);
        }


        return editorScenes.ToArray();
    }
}
#endif

