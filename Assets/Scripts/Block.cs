using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {
    //Config params
    [SerializeField] AudioClip breakSound;

    //Chaced params
    LevelController level;

    private void Start() {
        level = FindObjectOfType<LevelController>();
        level.CountBlock();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        DestroyBlock();
    }

    private void DestroyBlock() {
        level.DeleteBlock();
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        Destroy(gameObject);
    }
}
