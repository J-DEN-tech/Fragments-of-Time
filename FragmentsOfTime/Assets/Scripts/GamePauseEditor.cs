#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

[InitializeOnLoadAttribute]
public static class GamePauseEditor
{
    static GamePauseEditor()
    {
        EditorApplication.pauseStateChanged += PauseStateChange;
    }

    private static void PauseStateChange(PauseState obj)
    {
        if (obj == PauseState.Paused)
        {
            Debug.Log("Game Paused in Editor");
        }
        else if (obj == PauseState.Unpaused)
        {
            Debug.Log("Game Unpaused in Editor");
        }
    }

    [MenuItem("Game Controls/Pause Game %p")] // %p means "Ctrl+P"
    public static void ToggleGamePause()
    {
        EditorApplication.isPaused = !EditorApplication.isPaused;
    }
}
#endif
