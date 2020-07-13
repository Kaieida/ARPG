using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    
    Rigidbody rb;
    [SerializeField] GameObject player;
    Vector3 playerCord;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        //CoordinateTranslation();
    }
    void Update()
    {
        rb.AddForce(playerCord,ForceMode.Impulse);
    }
    public void ArrowCollision(Collision collider)
    {
        //if(collider.gameObject)
    }
    public void CoordinateTranslation(Vector3 dir)
    {
        playerCord = dir;
        Debug.Log(playerCord);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().DamageTaken(1);
            Destroy(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject, 1.5f);
        }
    }
}
