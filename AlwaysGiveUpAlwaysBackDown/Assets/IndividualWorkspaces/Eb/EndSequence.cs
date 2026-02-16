using UnityEngine;
using System;
using System.Collections;
using Unity.VisualScripting;

public class EndSequence : MonoBehaviour
{
    public GameObject choicesUI;
    public float waitForChoices = 0.2f;
    public Rigidbody2D playerRB;
    public Animator spotLightAnimator;
    public Animator canvasAnimator;
    private bool madeChoice = false;

    public float playerForce;
    public int forgivenessTimer;

    public GameObject sb1, sb2, sb3;

    void Start()
    {
        
        choicesUI.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (madeChoice) { return; }

        if (collision.gameObject.CompareTag("Player"))
        {
            // pause controls
            collision.gameObject.GetComponent<BunnyController>().PauseBunnyControls();
            playerRB = collision.gameObject.GetComponent<Rigidbody2D>();
            // open choice buttons
            StartCoroutine(ShowChoices());
        }
    }

    IEnumerator ShowChoices()
    {
        yield return new WaitForSeconds(waitForChoices);
        choicesUI.SetActive(true);
    }

    public void Forgive()
    {
        madeChoice = true;
        choicesUI.SetActive(false);

        sb1.SetActive(false);
        sb2.SetActive(false);
        sb3.SetActive(false);

        StartCoroutine(ForgiveSequence());
    }

    public void Revenge()
    {
        madeChoice = true;
        FindFirstObjectByType<BunnyController>().UnpauseBunnyControls();
        choicesUI.SetActive(false);

        sb1.SetActive(false);
        sb2.SetActive(false);
        sb3.SetActive(false);
    }

    IEnumerator ForgiveSequence()
    {
        float timer = 0f;
        yield return new WaitForSeconds(waitForChoices);
        spotLightAnimator.SetTrigger("Start");
        yield return new WaitForSeconds(3f);
        playerRB.gravityScale = 0f;
        while (timer <forgivenessTimer)
        {
            timer += Time.deltaTime;
            playerRB.AddForce(Vector2.up * playerForce);
            yield return null;

        }
        canvasAnimator.SetTrigger("StartCredit");

    }
}
