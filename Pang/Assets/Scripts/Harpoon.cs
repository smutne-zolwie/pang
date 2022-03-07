using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harpoon : MonoBehaviour
{
    public GameObject harpoonSection;
    public GameObject arrowhead;
    public Rigidbody2D rb;
    public Transform shootpoint;
    public Transform selection;
    public SpriteRenderer spRenderer;

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1.0f);
    }

    void Start()
    {
        rb.velocity = transform.up * 0.1f;
        Shoot();
    }

    public void Shoot()
    { 
        Instantiate(gameObject, gameObject.transform.position, gameObject.transform.rotation);
        Wait();
        //spRenderer.size += new Vector2(0.001f, 0);
    }

    private void Update()
    {
        spRenderer.size += new Vector2(0, 0.0025f);
        //gameObject.transform.position += new Vector3(0, 0.001f, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Wait();
        Destroy(gameObject);
    }
}