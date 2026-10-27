using UnityEngine;
using UnityEngine.UI;


public class Collectable : MonoBehaviour
{

// codetaken from https://www.youtube.com/watch?v=5GWRPwuWtsQ&t=457s
 public int gemsCount;
 public Text gemText;
 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        gemText.text = "9/" + gemsCount.ToString();
    }

    
   
}
