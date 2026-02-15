using Unity.VisualScripting;
using UnityEngine;
using System.Collections;
using System;

public class DustReceiver : MonoBehaviour
{
    public Action onDustReceived;

    public int DustAmount = 0;
    public Dust dustScript;
    public int DustReceiveLimit;

    public float lerpTime = 1f;
    public GameObject dustBoomParticlePrefab;

    IEnumerator CorrectAmntDustReceived()
    {
        if(dustScript != null) 
        { 
            dustScript.ReadyCollect();

            float timer = lerpTime;
            Vector2 dustStartPos = dustScript.gameObject.transform.position;
            while (timer > 0f)
            {
                float interp = 1f - (timer / lerpTime);
                dustScript.gameObject.transform.position = Vector2.Lerp(dustStartPos, transform.position, interp);
                timer -= Time.deltaTime;

                yield return null;
            }

            DustAmount += dustScript.ContainsThisMuchDust;
            onDustReceived?.Invoke();
            Destroy(dustScript.gameObject);
        }
        else
        {
            Debug.Log("NO DUST B!");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "dust")
        {
            dustScript = collision.GetComponent<Dust>();
            if (DustReceiveLimit >= dustScript.ContainsThisMuchDust)
            {
                StartCoroutine(CorrectAmntDustReceived());
            }
            else
            {
                Debug.Log("dust too damb big");
            }
        }
    }
}
