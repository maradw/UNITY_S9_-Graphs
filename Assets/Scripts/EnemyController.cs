using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public float currentTime = 0f;
    public float timer;
    public GameObject objective;
    public Vector2 speedReference;
    public int energy;
    public bool followPlayer = false;
    public float whileTrue;
    //[SerializeField] private GameObject enemyView;

    [SerializeField] private TextMeshProUGUI energyState;
    [SerializeField] private GameObject player;

    //
   // private CircleCollider2D range;
   // private CustomCollider2D newCustom;
    //

    void Awake()
    {
        //range = enemyView.GetComponent<CircleCollider2D>();
    }
    void Update()
    {
        //newCustom.
        //range.shapeCount
        if (energy<= 0)
        {
            followPlayer = false;
            transform.position = Vector2.zero;
            currentTime = currentTime + Time.deltaTime;
            if (currentTime >= timer)
            {
                energy = 30;
                currentTime = 0;
            }
        }
        if (followPlayer == true)
        {
            transform.position = Vector2.SmoothDamp(transform.position, player.transform.position, ref speedReference, 2f);

                whileTrue = whileTrue + Time.deltaTime;
                if (whileTrue >= 1)
                {
                    energy= energy -1;
                    whileTrue = 0;
                }  
        }
        else if (energy > 0)
        {
            followPlayer = false;
            transform.position = Vector2.SmoothDamp(transform.position, objective.transform.position, ref speedReference, 0.5f);
        }
        SetLifeText();
    }
    public void SetLifeText()
    {
        energyState.text = " Energy: " + energy;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Node") 
        {
            followPlayer = false;
            objective = collision.gameObject.GetComponent<NodeController>().SelecRandomAdjancent().gameObject;
            int weight = objective.GetComponent<NodeController>().GetNodeWeight();
            RestLife(weight);
        }  
    }
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
    public void RestLife(int weight)
    {
        energy = energy - weight;

    }
    public void SetRotation()
    {
        //for field view
        //transform.rotation.SetLookRotation(objective.transform.position);
    }
}