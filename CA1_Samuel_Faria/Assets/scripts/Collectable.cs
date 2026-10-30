
using UnityEngine;
using UnityEngine.UI;

public class Collectable : MonoBehaviour
{
    public int gemsCount = 0;
    public Text gemText;


    void Start()
    {
        UpdateCounter();
    }

    public void AddGem()
    {
        gemsCount++;
        UpdateCounter();
      
    }

    void UpdateCounter()
    {
        
            gemText.text = gemsCount + "/9";
       
    }
}
