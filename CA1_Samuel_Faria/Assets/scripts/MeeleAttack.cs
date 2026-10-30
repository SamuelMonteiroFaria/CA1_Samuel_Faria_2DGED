using UnityEngine;

public class MeeleAttack : MonoBehaviour
{

public Animator animator;


  public Transform attackPoint;
  public float attackRange = 0.5f;
  public LayerMask enemyLayer;
  public int attackDamage = 1;
  public float attackRate = 2f;
  float nextAttackTime = 0f;

 // code taken from this video https://www.youtube.com/watch?v=sPiVz1k-fEs

    // Update is called once per frame
    void Update()
    {
        // this makes so we can only attack after a certain amount of time
        if(Time.time >= nextAttackTime)
        {
              
        if(Input.GetKeyDown(KeyCode.J))
        {
            attack();
            // can only attack after 0.5 if you already attacked
            nextAttackTime = Time.time +1f / attackRate;
        }

        }
    }

    void attack()
    {
 
     // Play animation
     animator.SetTrigger("attack");

     //detect enemies in range of attack
     Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

   // Damage them
    foreach(Collider2D enemy in hitEnemies)
    {
        enemy.GetComponent<enemy>().TakeDamage(1);
    }

   

    }

     void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
          return;

          Gizmos.DrawWireSphere(attackPoint.position, attackRange);

    }
}
