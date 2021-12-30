using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator animator;
    [SerializeField] Animator springy;
    public CharacterMovement movement;
    [SerializeField] float HealthB;
    
    [SerializeField]
    private Rigidbody2D rg;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            StartCoroutine(AnimationJumping());
        }
        if (Input.GetButtonDown("Horizontal"))
        {
            animator.SetBool("Walking", true);
        }
        if (Input.GetButtonUp("Horizontal"))
        {
            animator.SetBool("Walking", false);
        }
        Run();
        NotRunning();

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartCoroutine(PlayerThrown());
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            animator.SetBool("Throw", false);
        }

        HealthB = movement.health;

        if(HealthB <= 0f)
        {
            StartCoroutine(SetDeath());
        }
    }

    IEnumerator SetDeath()
    {
        animator.SetBool("Death", true);
        Destroy(rg);

        yield return new WaitForSeconds(1);

        animator.SetBool("Death", false);

        Time.timeScale = 0f;
        yield return new WaitForSeconds(999999);
    }

    /// <summary>
    /// So Basically this part wont make sense
    /// Why? Because the void is referenced in a different
    /// Script, PlayerMovement
    /// Anti, i dont think you need to change it
    /// </summary>
    public void Run()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            animator.SetBool("Walking", true);
        }
    }

    IEnumerator PlayerThrown()
    {
        animator.SetBool("Throw", true);

        yield return new WaitForSeconds(0.5f);

        animator.SetBool("Throw", false);

        yield return new WaitForSeconds(999999);
    }

    /// <summary>
    /// Basically the void Run() thing
    /// Yeah....thats it....
    /// </summary>
    public void NotRunning()
    {
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            animator.SetBool("Walking", true);
        }
    }

    IEnumerator AnimationJumping()
    {
        animator.SetBool("Flight", true);

        yield return new WaitForSeconds(1);

        animator.SetBool("Flight", false);

        yield return new WaitForSeconds(900000);
    }
    //Ref OnCollisionEnter2D
    IEnumerator AnimationSpring()
    {
        animator.SetBool("Spring", true);
        springy.SetBool("Play", true);

        yield return new WaitForSeconds(1);

        animator.SetBool("Spring", false);
        springy.SetBool("Play", false);

        yield return new WaitForSeconds(900000);
    }

    //The setup for the String animation
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Spring"))
        {
            StartCoroutine(AnimationSpring());
        }
    }
}
