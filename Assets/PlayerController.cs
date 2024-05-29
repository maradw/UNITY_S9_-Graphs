using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private float _horizontal;
    private float _vertical;
    [SerializeField] private Rigidbody2D myRBD;
    public float velocityModifier;
    public void OnMovement(InputAction.CallbackContext move)
    {
        _horizontal = move.ReadValue<Vector2>().x;
        _vertical = move.ReadValue<Vector2>().y;

    }
    public void FixedUpdate()
    {
        myRBD.velocity = new Vector2(_horizontal * velocityModifier, _vertical * velocityModifier);
    }

}
