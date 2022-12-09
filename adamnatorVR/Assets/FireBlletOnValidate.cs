using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FireBlletOnValidate : MonoBehaviour
{
    public GameObject bullet;
    public Transform SpawnPoint;
    public float fireSpeed = 20;
    // Start is called before the first frame update
    void Start()
    {
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(FireBullet);
    }

    public void FireBullet(ActivateEventArgs arg)
    {
        GameObject spawnedBullet = Instantiate(bullet);
        spawnedBullet.transform.position = SpawnPoint.position;
        spawnedBullet.GetComponent<Rigidbody>().velocity = SpawnPoint.forward * fireSpeed;
        Destroy(spawnedBullet, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
