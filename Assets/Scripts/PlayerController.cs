using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rd;
    public float speed = 5f;
    public float jumpForce = 7f;

    private bool isGrouded;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float move =Input.GetAxis("Horizontal");

        rd.linearVelocity = new Vector2(move * speed, rd.linearVelocity.y);

        //

        if(Input.GetKeyDown(KeyCode.Space) && isGrouded){
            rd.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

            isGrouded = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision){

    if(collision.gameObject.CompareTag("Ground")){
        isGrouded = true;
    }
    }
}
