using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{ 
    //referenced https://www.youtube.com/watch?v=zObWVOv1GlE for hiding and creating menu object
    public GameObject menu;
    //referenced https://www.youtube.com/watch?v=zObWVOv1GlE for loading new scenes
    List<AsyncOperation> scenesToLoad = new List<AsyncOperation>();

    void Start()
    {
        Debug.Log(menu);        
        menu.SetActive(true);
    }

    //referenced https://www.youtube.com/watch?v=zObWVOv1GlE for loading new scenes
    public void playGame() {
        hideMenu();
        scenesToLoad.Add(SceneManager.LoadSceneAsync("Level 1"));
    }

    //referenced https://www.youtube.com/watch?v=zObWVOv1GlE for hiding and creating menu object
    private void hideMenu() {
        menu.SetActive(false);
    }
}
