using UnityEngine;
using System;
using System.Collections;

public class EndSequence : MonoBehaviour
{
    public GameObject choicesUI;
    public float waitForChoices = 0.2f;

    private bool madeChoice = false;

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
    }

    public void Revenge()
    {
        madeChoice = true;
        FindFirstObjectByType<BunnyController>().UnpauseBunnyControls();
    }

    IEnumerator ForgiveSequence()
    {
        yield return new WaitForSeconds(waitForChoices);
    }
}
