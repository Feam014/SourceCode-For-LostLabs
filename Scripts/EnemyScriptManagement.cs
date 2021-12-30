using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScriptManagement : MonoBehaviour
{
    public EnemyChase enemy;
    public EnemyMovement movement;
    [SerializeField] GameObject deathBox;

    public float stoppingDistance;

    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        enemy.enabled = false;
        deathBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, target.position) < stoppingDistance)
        {
            enemy.enabled = true;
            movement.enabled = false;
            deathBox.SetActive(true);
        }
        else
        {
            deathBox.SetActive(false);
            movement.enabled = true;
            enemy.enabled = false;
        }
    }
}
