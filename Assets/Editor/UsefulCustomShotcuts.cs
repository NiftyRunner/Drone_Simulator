using System;
using System.Reflection;
using UnityEditor;
using UnityEngine;

public class UsefulCustomShotcuts : EditorWindow
{

    /*
     * TASKS:
     * 1. Shortcut to maximize game window when playing and minimize it when leaving play mode
     * 2. Shortcut to minimize game window when pausing the game and maximize it when unpausing
     * 3. Shortcut to clear console
     * 
     * WORKS FOR UNITY 2023.1.1f1
     * 1. Don't attach this to any GameObject
     * 2. This script creates a button under the "Window" drop-down menu called "Maximize Game View and Play"
     * 3. Go to Edit -> Shortcuts, search for "Maximize Game View and Play" and set the shortcut Ctrl + M to it
     * 4. Then in the shortcuts window search for "Minimize Game View and Pause" and set the shortcut Ctrl + Shift + M to it
     * 5. Then in the shortcuts window search for "Clear Console" and set the shortcut Ctrl + Shift + X to it
     * 6. If there is no "Editor" folder in Assets, create one and put this script in there. This prevents the script from being used
     *    in the game build
     */

    [MenuItem("Window/Maximize Game View and Play")]
    private static void MaximizeAndRunGameFn()
    {
        // Start play mode
        //EditorApplication.ExecuteMenuItem("Window/General/Game");

        ToggleMaximizeGameView();
    }

    private static void ToggleMaximizeGameView()
    {
        EditorWindow gameView = EditorWindow.GetWindow(GameViewType);

        if (EditorApplication.isPlaying)
        {
            if (gameView != null)
            {
                gameView.maximized = false;
            }
            EditorApplication.isPlaying = false;
        } else
        {
            if (gameView != null)
            {
                gameView.maximized = true;
            }
            EditorApplication.isPlaying = true;
        }
    }

    [MenuItem("Window/Minimize Game View and Pause")]
    private static void MinimizeAndPauseGame()
    {
        EditorWindow gameView = EditorWindow.GetWindow(GameViewType);

        if (EditorApplication.isPlaying && !EditorApplication.isPaused)
        {
            EditorApplication.isPaused = true;
            if (gameView != null)
            {
                gameView.maximized = false;
            }
        } else if (EditorApplication.isPaused)
        {
            EditorApplication.isPaused = false;
            if (gameView != null && EditorApplication.isPlaying)
            {
                gameView.maximized = true;
            }
        }
    }

    private static System.Type GameViewType
    {
        get
        {
            Assembly assembly = Assembly.GetAssembly(typeof(EditorWindow));
            return assembly.GetType("UnityEditor.GameView");
        }
    }


    // Un-Maximize game window when exiting game the normal way (Using the button or Ctrl + P)
    [InitializeOnLoadMethod]
    private static void Initialize()
    {
        EditorApplication.playModeStateChanged += OnPlayModeStateChanged;
    }

    private static void OnPlayModeStateChanged(PlayModeStateChange state)
    {
        if (state == PlayModeStateChange.ExitingPlayMode)
        {
            ToggleMaximizeGameView();
        }
    }

    // Clear console
    [MenuItem("Window/Clear console")]
    private static void ClearConsole()
    {
        // Try to find the Console window
        Type logEntriesType = Type.GetType("UnityEditor.LogEntries, UnityEditor");
        if (logEntriesType != null)
        {
            MethodInfo clearMethod = logEntriesType.GetMethod("Clear", BindingFlags.Static | BindingFlags.Public);

            if (clearMethod != null)
            {
                clearMethod.Invoke(null, null);
            } else
            {
                Debug.LogWarning("Failed to find the Clear method in LogEntries. Console may not be cleared.");
            }
        } else
        {
            Debug.LogWarning("Failed to find the LogEntries type. Console may not be cleared.");
        }
    }
}
