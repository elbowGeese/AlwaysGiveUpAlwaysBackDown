using UnityEngine;
using System;
using System.Collections;

public class EndSequence : MonoBehaviour
{
    public GameObject choicesUI;
    public float waitForChoices = 0.2f;

    private bool madeChoice = false;

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
        yield return new WaitForSeconds(waitForChoices);
    }
}
