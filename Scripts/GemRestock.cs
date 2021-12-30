using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemRestock : MonoBehaviour
{
    public GemCounter counter;
    public GameObject gemstock;
    private bool isTouchingPlayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !isTouchingPlayer)
        {
            isTouchingPlayer = true;
            Destroy(gemstock);
            counter.gemsleft += 5f;
        }
    }
}
