using UnityEngine;

public class Dust : MonoBehaviour
{
    public int ContainsThisMuchDust;
    public Collider2D trigger;
    public GameObject col;
    
    public void ReadyCollect()
    {
        trigger.enabled = false;
        col.SetActive(false);
    }
}
