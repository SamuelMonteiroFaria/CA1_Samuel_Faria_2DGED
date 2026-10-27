using UnityEngine;


public class Player : MonoBehaviour
{

  public int direction = 0;
  public int speed;
  private Rigidbody2D rb;
  public float jumpHeight = 3.4f;
  public bool isJumping = false;
  public Collectable ct;
 
  
  

  
  Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
       animator = GetComponent<Animator>();
       rb = GetComponent<Rigidbody2D>();
 
    }

    // Update is called once per frame
    void Update()
    {
      Vector2 position = transform.position;
     float move = Input.GetAxis("Horizontal");
     position.x = position.x + speed * Time.deltaTime * move;
     transform.position = position;

// code to change the player direction 
// took from this video https://www.youtube.com/watch?v=Gf8LOFNnils
    if(move > 0.01f)
     transform.localScale = Vector3.one;
     else if(move < -0.01f)
    transform.localScale = new Vector3(-1,1,1);


    animator.SetBool("run",move !=0);
  

    if(!isJumping && Input.GetKeyDown(KeyCode.Space))
     {
        isJumping = true;
        rb.linearVelocity = Vector3.zero;
        rb.AddForce(new Vector2(0, Mathf.Sqrt( -2 * Physics2D.gravity.y * jumpHeight)), ForceMode2D.Impulse);

     }


    }

    void OnCollisionEnter2D(Collision2D collision)
    {

      
     if(isJumping)
      isJumping = false;
      
  
    }

//part of the code taken from https://www.youtube.com/watch?v=5GWRPwuWtsQ&t=457s
     void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Collectable")
        { 
            Destroy(other.gameObject);
            ct.gemsCount++;
            
            
        }


    }

   


      
    
}
