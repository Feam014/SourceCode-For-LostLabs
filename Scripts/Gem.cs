using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    [SerializeField] float speed = 20f;
    [SerializeField] Rigidbody2D rigidBody;
    [SerializeField] GameObject thisGem;
    public GemCounter gems;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D()
    {
        Destroy(thisGem);
    }
}
