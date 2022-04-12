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
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(menu);        
        menu.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //referenced https://www.youtube.com/watch?v=zObWVOv1GlE for loading new scenes
    public void playGame() {
        Debug.Log("pressed play");
        hideMenu();
        scenesToLoad.Add(SceneManager.LoadSceneAsync("SampleScene"));
    }

    public void createCharacter() {
        Debug.Log("pressed create character");
    }
    //referenced https://www.youtube.com/watch?v=zObWVOv1GlE for hiding and creating menu object
    private void hideMenu() {
        menu.SetActive(false);
    }
}
