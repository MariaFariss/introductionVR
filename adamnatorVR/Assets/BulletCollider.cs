using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollider : MonoBehaviour


    
{
    // Start is called before the first frame update
    private int pv = 100;
    public GameObject parent;
    public Animation animations;
    void Start()
    {
        parent = transform.parent.gameObject;
        animations = parent.GetComponent<Animation>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Destroy(other);
            Debug.Log("Hit");
            pv -= 20;
            if (pv <= 0)
            {
                animations.Play("Death");
                Destroy(parent, 0.5f);
            }

        }
    }
}
