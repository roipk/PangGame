using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum BallType{
    Small = 5,
    Medume = 7,
    Large = 10
};

public class Ball : MonoBehaviour
{
      
    [SerializeField] private BallType _ballType;
    [SerializeField] private List<GameObject> childs;
    private Rigidbody2D rb;
    private int _ballsize;
    private Vector2 m_forceMovement = Vector2.right*3;
    public Vector2 movement
    {
        get { return m_forceMovement; }
        set { m_forceMovement = value; }
    }
    
    private void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = m_forceMovement;
        _ballsize = (int)_ballType;
        GameObject[] ignore = GameObject.FindGameObjectsWithTag("Ball");
        foreach (var collision in ignore)
        {
            Physics2D.IgnoreCollision( collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>()); 
        }
        ManagerLevel.instance.AddBall();
    }

  
    
    private void OnDisable()
    {
         ManagerLevel.instance.RemoveBall();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.transform.CompareTag("Ground"))
            rb.velocity = new Vector2(rb.velocity.x, _ballsize);
        
        
        else if (collision.transform.CompareTag("Player"))
        {
            ManagerLevel.instance.gameOver = true;
            collision.gameObject.SetActive(false);
        }
        
        else if (collision.transform.CompareTag("Shoot"))
            CreateChilds();
        
        else if (collision.transform.CompareTag("Rwall"))
            rb.velocity = new Vector2(-m_forceMovement.x, rb.velocity.y);
        else if (collision.transform.CompareTag("Lwall"))
            rb.velocity = new Vector2(m_forceMovement.x, rb.velocity.y);
            
    }
    
   void CreateChilds()
   {
       bool direction = true;
       foreach (var child in childs)
       {   
           StartCoroutine(CreateChild(child, direction,transform));
           direction = !direction;
       }
       transform.localScale = Vector3.zero;
       Invoke("RemoveObject",0.1f);
   }

   void RemoveObject()
   {
       Destroy(gameObject);
   }
   
   
   
    IEnumerator CreateChild(GameObject child,bool direction,Transform t)
    {
        yield return new WaitForSeconds(0.01f);
        GameObject c = Instantiate(child,t.position,t.rotation,transform.parent);
        Rigidbody2D newBall = c.GetComponent<Rigidbody2D>();
        if (newBall)
        {
            if (direction)
                newBall.velocity = new Vector2(rb.velocity.x, rb.velocity.y+1);
            else    
                newBall.velocity = new Vector2(-rb.velocity.x, rb.velocity.y+1);
        }
    }
}
