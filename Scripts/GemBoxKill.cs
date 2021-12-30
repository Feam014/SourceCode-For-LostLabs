using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemBoxKill : MonoBehaviour
{
    [SerializeField] bool isGeming;
    
    [SerializeField]
    private bool isFirst;
    
    [SerializeField] Animator animator;
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] GameObject enemyDeath;
    public EnemyChase chase;
    public EnemyMovement movement;

    [SerializeField]
    private Animator player;

    // Start is called before the first frame update
    void Start()
    {
        isFirst = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGeming)
        {
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
        if (other.gameObject.CompareTag("PlayerGem") && !isFirst)
        {
            isFirst = true;
            isGeming = true;
        }
    }
}
