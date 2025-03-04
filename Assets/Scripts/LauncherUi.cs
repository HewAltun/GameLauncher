using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class LauncherUi : MonoBehaviour
{
    [SerializeField]
    private string gamePath = "C:/Users/AIW/Unity/3D First Person Rig/Build/3D First Person Rig.exe";

    private void Awake()
    {
        Button button = transform.Find("FirstThirdPersonButton").GetComponent<Button>();
        button.onClick.AddListener(LaunchGame);
    }

    private void LaunchGame()
    {
        gamePath = Application.dataPath + "/../../../3D First Person Rig/Build/3D First Person Rig.exe";
        if (File.Exists(gamePath))
        {
            try
            {
                Process.Start(gamePath);
            }
            catch (System.Exception e)
            {
                UnityEngine.Debug.LogError($"Failed to start game: {e.Message}");
            }
        }
        else
        {
            UnityEngine.Debug.LogError($"Game executable not found at path: {gamePath}");
        }
    }
}
