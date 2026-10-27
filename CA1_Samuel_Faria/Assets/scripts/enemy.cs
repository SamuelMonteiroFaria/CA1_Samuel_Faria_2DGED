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
    [SerializeField] int strength ;
    bool isAlive = true;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        timeInDirection = distanceTime;
        animator.SetFloat("Move X", direction);
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
            animator.SetFloat("Move X", direction);
        }


     //  changins Sprite direction
     if(direction > 0.01f)
     transform.localScale = Vector3.one;
     else if(direction < -0.01f)
     transform.localScale = new Vector3(-1,1,1);




     RaycastHit2D hit = Physics2D.Raycast(position, new Vector2(direction, 0), 5f, LayerMask.GetMask("Player"));
     if(hit.collider != null)
     {
        if(hit.collider.GetComponent<Player>() != null)
        Fire();
     }
     fireCountdown -= Time.deltaTime;


    }


     public void Fire()
    {
        fireCountdown += Time.deltaTime;
        if (fireCountdown >= fireTimer)
        {
            GameObject go = Instantiate(projectile, rb.transform.position, Quaternion.identity);
            Projectile pro = go.GetComponent<Projectile>();
            pro.Launch(new Vector2(direction, 0), 300);
            fireCountdown = 0;
        }
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.collider.name.Contains("Snowball"))
        {
            hit();
            GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0,0);
        }
    }


    public void hit()
    {
        strength--;
        if(strength <=0)
        {
          Destroy(this.gameObject);
        }
    }

}
