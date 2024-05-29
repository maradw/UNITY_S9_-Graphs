using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOV : MonoBehaviour
{
    [SerializeField] private GameObject playerRef;
    public float angle;
    public float range;
    public Vector2 direction = Vector2.down;
    Vector2 speedReference;
    public bool followPlayer = false;
    /*public bool Inside()
    {
        Vector2 directionTarget = (playerRef.transform.position - transform.position).normalized;
        float angleTarget = Vector2.Angle(transform.position, directionTarget);
        if (angleTarget < angle / 2)
        {
            float distance = Vector2.Distance(playerRef.transform.position, transform.position);
            Debug.Log("Hit");
            return distance < angle;
        }
        Debug.Log("Didn't Hit");
        return false;
        
    }*/
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            followPlayer = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            followPlayer = false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (followPlayer == true)
        {
            transform.position = Vector2.SmoothDamp(transform.position, playerRef.transform.position, ref speedReference, 2f);
        }

    }
}
