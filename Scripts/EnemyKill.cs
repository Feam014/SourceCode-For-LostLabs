using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKill : MonoBehaviour
{
    private bool isFirst;
    public bool isTouching;
    [SerializeField] Animator animator;
    [SerializeField] GameObject enemyDeath;
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] BoxCollider2D collision;
    public EnemyChase chase;
    public EnemyMovement movement;

    [SerializeField]
    private Animator player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isTouching)
        {
            Destroy(collision);
            animator.SetBool("Dead", true);
            Destroy(rigid);
            Destroy(enemyDeath, 5);
            player.SetBool("Hurt", false);
            chase.enabled = false;
            movement.enabled = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("PlayerKill") && !isFirst)
        {
            isFirst = true;
            isTouching = true;
        }
    }
}
