using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

    //cached references
    private SceneController sceneController;

    private int numberOfBlocks;

    private void Start() {
        sceneController = FindObjectOfType<SceneController>();
    }

    public void CountBlock() => numberOfBlocks++;

    public void DeleteBlock() {
        numberOfBlocks--;
        if (numberOfBlocks <= 0) {
            sceneController.LoadNextScene();
        }
    }
}
