using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public int maxhealth = 10;
    public int health = 10;
    public float speed = 1;
    public int jumpStrength = 1;
    private int playerJumps = 2;
    private bool onGround = false;

    private Vector2 inputMovement;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        health = maxhealth;
    }
    private void OnMove(InputValue value)
    {
        //Debug.Log(value.Get<Vector2>());
        inputMovement = value.Get<Vector2>();
    }
    private void Jump()
    {
        playerJumps -= 1;
        rb.AddForce(Vector3.up * jumpStrength, ForceMode.Impulse);
    }
    private void OnJump()
    {
        if (onGround)
        {
            playerJumps = 2;
            Jump();
        }
        else if (playerJumps > 0)
            Jump();

        else
        {
            Debug.Log("cant jump");
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("damaged");
        if (health == 0)
        {
            Debug.Log("you died");
            Destroy(gameObject);
        }
    }
    public void Heal(int healamount)
    {
        if (health <= 10)
        { 
            health += healamount;
        }
    }

    private void Update()
    {
        onGround = Physics.Raycast(rb.position, Vector3.down, 1);
    }
    private void FixedUpdate()
    {
        Vector3 direction = new Vector3(inputMovement.x, 0, inputMovement.y);
        direction = Vector3.ClampMagnitude(direction, 1);
        rb.AddForce(direction * speed);

    }
}
 