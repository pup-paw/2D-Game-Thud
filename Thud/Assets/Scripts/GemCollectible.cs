using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemCollectible : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController controller = other.GetComponent<PlayerController>();
        if(controller != null)
        {
            GameControl.instance.myGem++;
            Destroy(gameObject);
            Debug.Log(GameControl.instance.myGem + "/" + GameControl.instance.maxGem);
            UIGemBar.instance.setValue(GameControl.instance.myGem / (float)GameControl.instance.maxGem);
        }
    }
}
