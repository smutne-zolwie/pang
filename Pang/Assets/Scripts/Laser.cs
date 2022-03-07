using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public GameObject laser;
    public Rigidbody2D rb;
    public Transform shootpoint;
    public SpriteRenderer spRenderer;

    void Start()
    {
        
    }

    void Update()
    {
        spRenderer.size += new Vector2(0, 25);
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Destroy(gameObject);
    //}
}
