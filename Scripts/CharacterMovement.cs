using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float Speed = 1;
    [SerializeField] float JumpForce = 1;
    public PlayerAnimation player;
    [SerializeField] float SpringForce = 1;
    public float health = 100f;

    private Rigidbody2D _rigidBody;

    // Start is called before the first frame update
    public void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    public void Update()
    {
        if(health <= 0f)
        {
            health = 0f;
        }

        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * Speed;

        if (!Mathf.Approximately(0, movement))
            transform.rotation = movement < 0 ? Quaternion.Euler(0, -180, 0) : Quaternion.identity;

        if(Input.GetButtonDown("Jump") && Mathf.Abs(_rigidBody.velocity.y) < 0.001f)
        {
            _rigidBody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            player.Run();
            Speed = 5.2f;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            player.NotRunning();
            Speed = 1.9f;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Spring"))
        {
            _rigidBody.AddForce(new Vector2(0, SpringForce), ForceMode2D.Impulse);
        }

        if (other.gameObject.CompareTag("EnemyBase"))
        {
            health -= 1f;
        }
    }

}
