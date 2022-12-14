using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FireBlletOnValidate : MonoBehaviour
{
    public GameObject toIgnore;
    public GameObject bullet;
    public Transform SpawnPoint;
    public float fireSpeed = 20;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(FireBullet);
    }

    public void FireBullet(ActivateEventArgs arg)
    {
        audioSource.Play();
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
