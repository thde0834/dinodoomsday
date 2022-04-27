using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    //referenced https://www.youtube.com/watch?v=zObWVOv1GlE for loading new scenes
    private List<AsyncOperation> scenesToLoad = new List<AsyncOperation>();
    public List<Platform> platforms = new List<Platform>();
    public Transform playerObj;
    public Player.Player playerRef;

    // Update is called once per frame
    void Update()
    {
        Platform activePlatform = getCurrentPlatform();
        if (activePlatform != null && activePlatform.endPlatform) {
            levelComplete();
        }
        if (playerRef.isDead()) {
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
        scenesToLoad.Add(SceneManager.LoadSceneAsync("You Won!"));
    }
}
