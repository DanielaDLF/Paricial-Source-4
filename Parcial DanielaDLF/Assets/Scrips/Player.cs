using JetBrains.Annotations;
using System.Collections;
using System.Linq.Expressions;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Component")]
    public CharacterController controller;

    [Header("Jump")]
    public KeyCode jumpKey = KeyCode.Space;
    public float jumpForce = 8f;
    public float gravity = -20f;

    [Header("Crouch")]
    public KeyCode crouchKey = KeyCode.LeftControl;
    public float standHeight = 2f;
    public float crouchHeight = 1f;
    public float crouchTransitionSpeed = 10f;

    float verticalVelocity = 0f;

    void Reset()
    {
        controller = GetComponent<CharacterController>();
    }

    void Start()
    {
        if (controller == null)
            controller = GetComponent<CharacterController>();

        
        if (controller != null)
            controller.height = standHeight;
    }

    void Update()
    {
        if (controller == null)
            return;

        
        if (controller.isGrounded)
        {
           
            if (verticalVelocity < 0f) verticalVelocity = -1f;

            if (Input.GetKeyDown(jumpKey))
            {
                verticalVelocity = jumpForce;
            }
        }

       
        verticalVelocity += gravity * Time.deltaTime;

       
        Vector3 move = Vector3.up * verticalVelocity;
        controller.Move(move * Time.deltaTime);

       
        bool wantCrouch = Input.GetKey(crouchKey);
        float targetHeight = wantCrouch ? crouchHeight : standHeight;

        
        controller.height = Mathf.Lerp(controller.height, targetHeight, Time.deltaTime * crouchTransitionSpeed);

        
        Vector3 c = controller.center;
        c.y = controller.height / 2f;
        controller.center = c;
    }
}
