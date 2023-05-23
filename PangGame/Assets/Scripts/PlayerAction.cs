using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _shoot;
    [SerializeField] private Transform _shootPatent;
    private bool _move;
    [SerializeField] private Vector3 _direction;
  
    void Update()
    {
        if (_move)
        {
            transform.position += _direction * Time.deltaTime * _speed;
        }
        
    }
    
    public void setDirection(Vector3 direction = default)
    {
        _direction = direction;
        _move = direction != Vector3.zero;
    }

    public void Shoot()
    {
        GameObject shoot =Instantiate(_shoot,transform.position,Quaternion.Euler(0,0,90),_shootPatent);
        Physics2D.IgnoreCollision(shoot.GetComponent<Collider2D>(),GetComponent<Collider2D>());
    }
    
    public Vector3 Me()
    {
        return transform.position;
    }
}
