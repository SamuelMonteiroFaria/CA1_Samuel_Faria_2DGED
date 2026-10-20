using UnityEngine;

public class Collectable : MonoBehaviour
{

   [SerializeField]
   PlayerController player;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player" && this.tag == "gem")
        {
            Destroy(this.gameObject);
            player.AddGem();
        }
    }
}
