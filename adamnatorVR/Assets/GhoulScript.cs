using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GhoulScript : MonoBehaviour
{
    private Animation animations;
    private BoxCollider boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        animations = gameObject.GetComponent<Animation>();
        boxCollider = gameObject.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector3 mousePosition = Mouse.current.position.ReadValue();
            Ray ray = Camera.main.ScreenPointToRay(mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.transform.name);
                animations.Play("Death");
                Destroy(gameObject, 1f);
            }
        }
        if (Keyboard.current.wKey.IsPressed())
        {
            animations.Play("Walk");
            transform.Translate(Vector3.forward * Time.deltaTime * 5);
        }
        else if (Keyboard.current.sKey.IsPressed())
        {
            animations.Play("Walk");
            transform.Translate(Vector3.back * Time.deltaTime * 5);
        }
        else if (Keyboard.current.aKey.IsPressed())
        {
            animations.Play("Walk");
            transform.Translate(Vector3.left * Time.deltaTime * 5);
        }
        else if (Keyboard.current.dKey.IsPressed())
        {
            animations.Play("Walk");
            transform.Translate(Vector3.right * Time.deltaTime * 5);
        }
        else if (Keyboard.current.spaceKey.IsPressed())
        {
            animations.Play("Death");
            Destroy(gameObject, 1f);
        }
        else if (Keyboard.current.pKey.IsPressed())
        {
            animations.Play("Attack1");
        }
        else
        {
            animations.Play("Idle");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered");
    }
}
