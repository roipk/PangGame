using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float speed = 6;
    [SerializeField] private List<string> _tagDestroy;
    private void OnCollisionEnter2D(Collision2D col)
    {
        foreach (var tag in _tagDestroy)
        {
            if (col.transform.tag == tag)
                Destroy(gameObject);
        }
    }



    private void Update()
    {
        transform.position += Vector3.up * Time.deltaTime * speed;
    }
}
