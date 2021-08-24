using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombCollectible : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController controller = other.GetComponent<PlayerController>();
        if (controller != null)
        {
            if (controller.bomb < controller.maxBomb)
            {
                controller.GetBomb(1);
                Destroy(gameObject);
            }
        }
    }
}
