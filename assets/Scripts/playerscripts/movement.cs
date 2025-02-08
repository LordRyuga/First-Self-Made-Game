using DialogueEditor;
using Unity.Cinemachine;
using UnityEngine;

public class movement : MonoBehaviour
{
    public CharacterController Controller;
    public CinemachineImpulseSource source;
    public gameManager manager;
    public Animator playerAnimator;
    public Transform eyes;
    public Transform gun;

    // Basic Movement variables
    [HideInInspector] public bool ShouldMove;
    float xmove;
    float ymove;
    public float walk = 5;
    public float jump = 5f;
    public float gravity = -9.8f;
    Vector3 velocity;
    public float speed;
    public bool isMoving;

    // Dashing variables
    public float Dashspeed;
    bool dashing;
    float dashTime = 1.5f;
    float cooldown = 2.5f;
    Vector3 Dash;

    // Groundchecking
    bool onGround = false;
    public Transform groundcheck;
    public float groundDist = 0.5f;
    public LayerMask ground;

    public float slopeCheck = 0.5f;
    RaycastHit checkNormal;
    public float maxAngle = 45;
    public float slopeAngle;
    bool slopeExceed;
    Vector3 normal;

    //variables to apply rotation of eyes on gun
    public float rotationOfEyesX;

    // Start is called before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speed = walk;
        Dashspeed = speed * 3;
        slopeExceed = false;
    }

    // Update is called once per frame
    void Update()
    {
        rotationOfEyesX = eyes.eulerAngles.x;
        gun.rotation = Quaternion.Euler(rotationOfEyesX, gun.eulerAngles.y, gun.eulerAngles.z);
        // Using a sphere check to check if object is on the ground
        onGround = Physics.CheckSphere(groundcheck.position, groundDist, ground);

        // Using SphereCast to find the slope's normal
        if (Physics.SphereCast(groundcheck.position, slopeCheck, Vector3.down, out checkNormal, groundDist, ground))
        {
            normal = checkNormal.normal;
            slopeAngle = Vector3.Angle(Vector3.up, normal);

            // Determine if the slope angle exceeds the limit
            slopeExceed = slopeAngle > maxAngle;
        }
        else
        {
            // Reset values if not on a slope
            slopeAngle = 0f;
            slopeExceed = false;
        }

        // Adding gravity if the object is not on the ground
        if (!onGround)
        {
            velocity.y += gravity * Time.deltaTime;
        }

        // Adding a small downward velocity if it is on the ground to ensure it stays grounded
        if (velocity.y < 0f && onGround)
        {
            velocity.y = -2f;
        }

        // Implement jumping if the character is on the ground and not on an excessive slope
        if (onGround && !slopeExceed && Input.GetKey(KeyCode.Space))
        {
            velocity.y = jump;
        }

        // Handle dashing
        if (!dashing)
        {
            if (Input.GetKey(KeyCode.Alpha1) && cooldown == 2.5f)
            {
                speed = Dashspeed;
                dashing = true;
                source.GenerateImpulse();
            }
            cooldown += Time.deltaTime;
            if (cooldown > 2.5f)
            {
                cooldown = 2.5f;
            }
        }

        if (dashing)
        {
            dashTime -= Time.deltaTime;
        }

        if (dashTime < 0)
        {
            if (!manager.isFast)
            {
                speed = walk;
            }
            dashing = false;
            dashTime = 1.5f;
            cooldown = 0;
        }

        // Movement calculations
        xmove = Input.GetAxis("Horizontal");
        ymove = Input.GetAxis("Vertical");

        Vector3 move = transform.right * xmove + transform.forward * ymove;

        if (!dashing)
        {
            Dash = transform.forward;
        }

            if (ConversationManager.Instance.IsConversationActive == false && ShouldMove)
            {
                if (dashing)
                {
                    Controller.Move(Dash * speed * Time.deltaTime);
                }
                else
                {
                    if (slopeExceed)
                    {
                        // If the slope is too steep, slide down along the slope
                        Vector3 slopeDirection = Vector3.ProjectOnPlane(Vector3.down, normal);
                        Controller.Move(slopeDirection * Mathf.Abs(gravity) * Time.deltaTime);
                    }
                    else
                    {
                        // Standard movement
                        Controller.Move(move * speed * Time.deltaTime);
                        if (move.magnitude != 0)
                        {
                            isMoving = true;
                        }
                        else
                        {
                            isMoving = false;
                        }
                    }
                }
            }
        

        // Apply gravity
        Controller.Move(velocity * Time.deltaTime);

        if (isMoving)
        {
            playerAnimator.SetFloat("Speed", move.magnitude);
        }
    }

    // Visualize the ground normal in the Scene view for debugging
    private void OnDrawGizmos()
    {
        if (normal != Vector3.zero)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(groundcheck.position, normal);
        }
    }
}
