using UnityEngine;

public class enemy : MonoBehaviour
{

    private Rigidbody2D rb;
    private Animator animator;
    public float distanceTime;
    public float speed;
    float direction = 1;
    float timeInDirection;
    [SerializeField]  float fireTimer = 0.5f;
    float fireCountdown;
    [SerializeField] GameObject projectile;
     int maxHealth = 3;
    int currentHealth;
    [SerializeField] float sightHeight = -0.5f;
  




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        timeInDirection = distanceTime;
        animator.SetFloat("moving", direction);
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;
        position.x = position.x + speed * Time.deltaTime * direction;
        transform.position = position;
        timeInDirection -= Time.deltaTime;
        if(timeInDirection < 0)
        {
            direction *= -1;
            timeInDirection = distanceTime;
            animator.SetFloat("moving", direction);
        }


     //  changins Sprite direction
     if(direction > 0.01f)
     transform.localScale = Vector3.one;
     else if(direction < -0.01f)
     transform.localScale = new Vector3(-1,1,1);

RaycastHit2D hit = Physics2D.Raycast(
    rb.transform.position,
    new Vector2(direction, 0),
    5f,
    LayerMask.GetMask("Player")

);
        if(hit.collider != null)
        {
            if (hit.collider.GetComponent<Player>() != null)
            {
                Fire();
            }
        }

        fireCountdown += Time.fixedDeltaTime;

      


    }
void OnDrawGizmos()
{
    Gizmos.color = Color.red;

    Vector3 origin = transform.position + new Vector3(0, -0.5f, 0);

    Gizmos.DrawRay(origin, Vector3.right * 5f);
    Gizmos.DrawRay(origin, Vector3.left * 5f);
}


     public void Fire()
    {

        if (fireCountdown > fireTimer)
        {
            

            GameObject prjoj = Instantiate(projectile, rb.transform.position, Quaternion.identity);
            Projectile prj = prjoj.GetComponent<Projectile>();
            prj.Launch(new Vector2(direction, 0), 300);
            fireCountdown = 0;
            
        }
           
         

    }

      private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Projectile>() != null)
        {
          
            rb.linearVelocity = new Vector2(0, 0);
            TakeDamage(1);
            
        }
    }


    public void TakeDamage(int attackDamage)
    {
        currentHealth -= attackDamage;

        if(currentHealth <=0)
        {
          animator.SetTrigger("die");
          Destroy(this.gameObject);
        }
    }



}
