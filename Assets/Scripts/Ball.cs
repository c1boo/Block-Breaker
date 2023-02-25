using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    //Config parameters
    [SerializeField] PaddleController paddle;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;
    [SerializeField] float collisionOffset = 0.1f;
    [SerializeField] AudioClip[] ballSounds;

    //State
    private Vector2 paddleToBallOffset;
    private bool hasStarted = false;

    //Cached component reference
    private AudioSource myAudioSource;
    private Rigidbody2D myRigidBody2D;

    // Start is called before the first frame update
    void Start() {
        paddleToBallOffset = transform.position - paddle.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigidBody2D = GetComponent<Rigidbody2D>();
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
            myRigidBody2D.velocity = new Vector2(xPush, yPush);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        Vector2 velocityTweak = new Vector2(UnityEngine.Random.Range(0f, collisionOffset),
                                            UnityEngine.Random.Range(0f, collisionOffset));
        myRigidBody2D.velocity += velocityTweak;
        PlayCollisionSound();
    }

    private void PlayCollisionSound() {
        AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
        if (hasStarted)
            myAudioSource.PlayOneShot(clip);
    }
}
