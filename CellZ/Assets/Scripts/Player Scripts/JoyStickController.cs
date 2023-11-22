using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class JoyStickController : MonoBehaviour
{
    [SerializeField] Joystick joystick;
    private PlayerStats playerStats;

    private Rigidbody2D rb;

    public float xPos { get; private set; }
    public float yPos { get; private set; }
 

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerStats = GetComponent<PlayerStats>();
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
            rb.velocity = new Vector2(xPos * playerStats.currentMoveSpeed, yPos * playerStats.currentMoveSpeed);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }//moveplayer

}//class
