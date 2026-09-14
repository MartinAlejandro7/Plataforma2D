using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rd;
    public float speed = 5f;
    public float jumpForce = 7f;
    private Animator animator;
    private bool isGrouded; 
    private bool facinRight = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rd = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {
        float move =Input.GetAxis("Horizontal");

        float speedAnimation = Mathf.Abs(move);

        animator.SetFloat("Speed",speedAnimation);

        rd.linearVelocity = new Vector2(move * speed, rd.linearVelocity.y);

        if(move > 0 && !facinRight){
            Flip();
        }else if(move < 0 && facinRight){
            Flip();
        }

        //salto

        if(Input.GetKeyDown(KeyCode.Space) && isGrouded){

            rd.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

            isGrouded = false;

            animator.SetBool("isJump", true);
        }
    }

    void OnCollisionEnter2D(Collision2D collision){

    if(collision.gameObject.CompareTag("Ground")){
        isGrouded = true;
        animator.SetBool("isJump", false);
    }
    }

    void OnCollisionExit2D(Collision2D collision){

        if(collision.gameObject.CompareTag("Ground")){
        isGrouded = false;
        }
    }

    void Flip(){
        facinRight = !facinRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
