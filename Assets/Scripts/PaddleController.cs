using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour {
    //Configuration parameters
    [SerializeField] float screenWidthUnits = 16f;
    [SerializeField] float minX;
    [SerializeField] float maxX;

    //Cached reference
    GameState myGameState;
    Ball myBall;

    private void Start() {
        myGameState = FindObjectOfType<GameState>();
        myBall = FindObjectOfType<Ball>();
    }
    // Update is called once per frame
    void Update() {
        Vector2 paddlePos = transform.position;
        paddlePos.x = Mathf.Clamp(getXPos(), minX, maxX);
        transform.position = paddlePos;
    }

    private float getXPos() {
        //If autoplay is enabled get ball position else get mouse position
        if (myGameState.isAutoPlayEnabled()) {
            return myBall.transform.position.x;
        } else {
            return Input.mousePosition.x / Screen.width * screenWidthUnits - screenWidthUnits / 2;
        }
    }
}
