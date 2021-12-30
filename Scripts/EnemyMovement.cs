using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 3f;


    Rigidbody2D rigid;
    BoxCollider2D collider;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
    }

    // ok boomer Update is called once per frame
    void Update()
    {
        if (IsFacingRight())
        {
            rigid.velocity = new Vector2(moveSpeed, 0f);
        }
        else
        {
            rigid.velocity = new Vector2(-moveSpeed, 0f);
        }
    }

    [SerializeField]
    private bool IsFacingRight()
    {
        return transform.localScale.x > Mathf.Epsilon;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-(Mathf.Sign(rigid.velocity.x)), transform.localScale.y);
    }
}
