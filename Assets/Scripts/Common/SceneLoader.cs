using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    public void LoadGameScene() => LoadScene(SceneNames.Game);
    public void LoadMainMenu() => LoadScene(SceneNames.MainMenu);
    private void LoadScene(string sceneName)=> SceneManager.LoadScene(sceneName);
}
