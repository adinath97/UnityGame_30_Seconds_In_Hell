using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Manager : MonoBehaviour
{
    public static void LoadInstructions()
    {
        SceneManager.LoadScene("INTRO_SCENE");
    }

    public static void LoadGame()
    {
        Move_Player_Tank.playerDead = false;
        SceneManager.LoadScene("Game_Scene");
    }

    public static void LoadStartScene()
    {
        SceneManager.LoadScene("START_MENU");
    }

    public static void QuitGame()
    {
        Application.Quit();
    }
}
