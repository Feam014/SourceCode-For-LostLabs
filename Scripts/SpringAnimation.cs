using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringAnimation : MonoBehaviour
{
    private bool isFirst;
    
    [SerializeField] Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") && !isFirst)
        {
            isFirst = true;
            StartCoroutine(SetSpring());
        }
    }

    IEnumerator SetSpring()
    {
        animator.SetBool("Play", true);

        yield return new WaitForSeconds(1);

        animator.SetBool("Play", false);

        yield return new WaitForSeconds(999999999999999);
    }
}
