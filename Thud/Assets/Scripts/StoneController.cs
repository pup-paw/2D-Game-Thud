using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneController : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    Animator animator;
    public GameObject ParticleFXExplosion1;
    public GameObject ParticleFXExplosion2;
    // Start is called before the first frame update
    private void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        BombProjectile bomb = other.gameObject.GetComponent<BombProjectile>();
        GroundController ground = other.gameObject.GetComponent<GroundController>();

        if(bomb != null)
        {
            if(ground != null)
            {
                Destroy(bomb.gameObject);
                Instantiate(ParticleFXExplosion1, this.transform.position, Quaternion.identity); //气惯 捞棋飘 积己
                Destroy(this.gameObject);
            }
            
            else
            {
                Destroy(bomb.gameObject);
                Instantiate(ParticleFXExplosion2, this.transform.position, Quaternion.identity); //气惯 捞棋飘 积己
                Destroy(this.gameObject);
            }
        }
    }
}
