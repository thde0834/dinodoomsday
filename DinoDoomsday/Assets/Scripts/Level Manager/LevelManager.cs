using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int level = 1;
    //referenced https://www.youtube.com/watch?v=zObWVOv1GlE for loading new scenes
    private List<AsyncOperation> scenesToLoad = new List<AsyncOperation>();
    public List<Platform> platforms = new List<Platform>();
    public Transform playerObj;

    // Update is called once per frame
    void Update()
    {
        Platform activePlatform = getCurrentPlatform();
        Debug.Log("activePlatform:" + activePlatform);
        if (activePlatform != null && activePlatform.endPlatform) {
            levelComplete();
        }
        if (playerObj == null) {
            scenesToLoad.Add(SceneManager.LoadSceneAsync("Game Over"));
        }
    }


    private Platform getCurrentPlatform() {
        for (int i = 0; i < platforms.Count; i++) {
            Platform platform = platforms[i];
            if (platform.getActive()) {
                return platform;
            }
        }
        return null;
    }
    
    public void levelComplete() {
        if (level != 5) {
            scenesToLoad.Add(SceneManager.LoadSceneAsync("Level " + (level + 1)));
        }
    }
}
