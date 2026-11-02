using UnityEngine;
using UnityEngine.UI;

public class life : MonoBehaviour
{
    public GameObject[] hearts;
  //code taken from this video https://www.youtube.com/watch?v=Ay159WsGDJQ

   
    void Update()
    {
        if(Player.lives < 1)
        {
            Destroy(hearts[0].gameObject);
        }
        else if(Player.lives < 2)
        {
            Destroy(hearts[1].gameObject);
        }
        else if(Player.lives < 3)
        {
            Destroy(hearts[2].gameObject);
        }
    }

}