using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class JoyStickController : MonoBehaviour
{
    [SerializeField] Joystick joystick;
    [SerializeField] float playerSpeed;
    private Rigidbody2D rb;
    private float xPos;
    private float yPos;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        xPos = joystick.Direction.x;
        yPos = joystick.Direction.y;

    }//update

    private void FixedUpdate()
    {
        MovePlayer();
    }//fixedupdate

    private void MovePlayer()
    {
        if (joystick.Direction.y != 0)
        {
            rb.velocity = new Vector2(xPos * playerSpeed, yPos * playerSpeed);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }//moveplayer

}//class
