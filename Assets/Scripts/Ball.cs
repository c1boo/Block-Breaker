using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    //Config parameters
    [SerializeField] PaddleController paddle;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;
    [SerializeField] AudioClip[] ballSounds;

    //State
    private Vector2 paddleToBallOffset;
    private bool hasStarted = false;

    //Cache component reference
    private AudioSource myAudioSource;

    // Start is called before the first frame update
    void Start() {
        paddleToBallOffset = transform.position - paddle.transform.position;
        myAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {
        if (!hasStarted) {
            LockToPaddle();
            LaunchOnMouseClick();
        }
    }

    private void LockToPaddle() {
        Vector2 paddlePos = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddlePos + paddleToBallOffset;
    }

    private void LaunchOnMouseClick() {
        if (Input.GetMouseButtonDown(0)) {
            hasStarted = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(xPush, yPush);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
        if (hasStarted)
            myAudioSource.PlayOneShot(clip);
    }

}
