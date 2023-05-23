
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float speed = 6;
    [SerializeField] private List<string> _tagDestroy;
    private void OnCollisionEnter2D(Collision2D col)
    {
        // Checks if the collided object's tag is in the list of tags to destroy
        foreach (var tag in _tagDestroy)
        {
            if (col.transform.tag == tag)
                Destroy(gameObject);
        }
    }



    private void Update()
    {
        // Moves the weapon upwards based on the speed and time
        transform.position += Vector3.up * Time.deltaTime * speed;
    }
}
