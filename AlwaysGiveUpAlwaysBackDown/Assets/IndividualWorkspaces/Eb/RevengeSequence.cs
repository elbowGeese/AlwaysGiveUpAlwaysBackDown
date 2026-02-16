using UnityEngine;
using System;
using System.Collections;

public class RevengeSequence : MonoBehaviour
{
    public CameraController camControl;
    public GameObject smokePrefab, firePrefab;
    public AudioSource fireSFX;

    public Animator revengeAnim;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            camControl.SetPriorityCamera(2);
            GameObject fireBoom = Instantiate(smokePrefab);
            fireBoom.transform.position = collision.transform.position;
            fireSFX.Play();

            Destroy(collision.gameObject);

            // play anim
            revengeAnim.SetTrigger("GO");
        }
    }
}
