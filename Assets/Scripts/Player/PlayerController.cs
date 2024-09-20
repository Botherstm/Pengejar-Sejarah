using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed;
    public float maxSpeed;
    private int desiredLine = 1;
    public float lineDistance = 2.5f;
    public float jumpForce;
    public float Gravity = -20;
    public Animator animator;
    public Animator animator2;
    private bool isSliding = false;
    // Start is called before the first frame update
    void Start()
    {
        // AmbilKecepatan();
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerManager.isGameStarted)
            return;
        direction.z = forwardSpeed;

        //animasi
        animator.SetBool("isGameStarted", true);
        animator2.SetBool("isGameStarted", true);
        // animator.SetBool("isGrounded", controller.isGrounded);
        animator.SetBool("isGrounded", controller.isGrounded);
        animator2.SetBool("isGrounded", controller.isGrounded);
        if (forwardSpeed < maxSpeed)
        {
            forwardSpeed += 0.1f * Time.deltaTime;
        }
        if (controller.isGrounded)
        {
            direction.y = -1;
            if (SwipeManager.swipeUp || Input.GetKeyDown(KeyCode.UpArrow))
            // if (SwipeManager.swipeUp)
            {
                Jump();
            }
        }
        else
        {
            direction.y += Gravity * Time.deltaTime;
        }
        //pindah kiri atau kanan
        if (SwipeManager.swipeRight || Input.GetKeyDown(KeyCode.RightArrow))
        // if (SwipeManager.swipeRight)
        {
            desiredLine++;

            if (desiredLine == 3)
            {
                desiredLine = 2;
            }
        }

        if (SwipeManager.swipeLeft || Input.GetKeyDown(KeyCode.LeftArrow))
        // if (SwipeManager.swipeLeft)
        {
            desiredLine--;

            if (desiredLine == -1)
            {
                desiredLine = 0;
            }
        }

        if (SwipeManager.swipeDown || Input.GetKeyDown(KeyCode.DownArrow) && !isSliding)
        {
            StartCoroutine(Slide());
        }

        Vector3 targetPosition =
                    transform.position.z * transform.forward + transform.position.y * transform.up;

        if (desiredLine == 0)
        {
            targetPosition += Vector3.left * lineDistance;
        }
        else if (desiredLine == 2)
        {
            targetPosition += Vector3.right * lineDistance;
        }
        // transform.position = Vector3.Lerp(transform.position, targetPosition, 80 * Time.deltaTime);
        // controller.center = controller.center;
        if (transform.position == targetPosition)
            return;
        Vector3 diff = targetPosition - transform.position;
        Vector3 moveDir = diff.normalized * 25 * Time.deltaTime;
        if (moveDir.sqrMagnitude < diff.sqrMagnitude)
            controller.Move(moveDir);
        else
            controller.Move(diff);
    }

    private void FixedUpdate()
    {
        if (!PlayerManager.isGameStarted)
            return;
        controller.Move(direction * Time.fixedDeltaTime);
    }

    private void Jump()
    {
        direction.y = jumpForce;
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.CompareTag("Obstacle"))
        {
            PlayerManager.gameOver = true;

            // FindObjectOfType<AudioManager>().PlaySound("GameOver");
        }
    }

    private IEnumerator Slide()
    {
        isSliding = true;
        animator.SetBool("isSliding", true);
        animator2.SetBool("isSliding", true);
        controller.center = new Vector3(0, -0.5f, 0); // Mengubah center untuk membuat karakter lebih rendah saat slide
        controller.height = 1; // Mengubah ketinggian karakter
        yield return new WaitForSeconds(1.3f);
        controller.center = new Vector3(0, 0, 0); // Mengembalikan center ke posisi semula setelah slide
        controller.height = 2; // Mengembalikan ketinggian karakter
        animator.SetBool("isSliding", false);
        animator2.SetBool("isSliding", false);
        isSliding = false;
    }
    // private void AmbilKecepatan()
    // {
    //     forwardSpeed = PlayerPrefs.GetFloat("Fast", forwardSpeed);
    // }
}
