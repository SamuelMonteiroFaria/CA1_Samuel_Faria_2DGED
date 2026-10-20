using UnityEngine;

public class Player : MonoBehaviour
{

   int gems = 8;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
          player = GameObject.Find("Player").GetComponent<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {

    }
      
      public void AddGem()
      {
        gems++;
      }
}
