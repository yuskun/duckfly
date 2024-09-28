using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Camera MainCamera;
    public AudioClip DuckSFX;
    public AudioClip WingSFZ;
    private String pointTag = "point";
    private bool jump = false;
    private float launchVelocity = 10f;
    public float moveSpeed = 1f;
    public float slowDownDistance = 5f; // 减速距离
    public GameObject Grass;
    public CreatePoint create;
    public Collider2D DetectLine;
    public Collider2D GameLoseLine;
    public Collider2D RightEdge;
    public Collider2D LeftEdge;
    private AudioManager audioManager;
    Rigidbody2D rb;

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }
    void Start()
    {

         audioManager = FindObjectOfType<AudioManager>();


    }

    void Update()
    {
        DuckMovement();
        CameraMovement();


    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(pointTag))
        {
            rb.velocity = new Vector2(rb.velocity.x, launchVelocity);

            create.createpoint();
            Destroy(other.gameObject);
            audioManager.PlaySound(WingSFZ);;


        }
        else if (other == GameLoseLine)
        {
            rb.AddForce(Vector2.up * launchVelocity, ForceMode2D.Impulse);
            audioManager.PlaySound(DuckSFX);



        }
        else if (other == LeftEdge)
        {
            this.transform.position = new Vector2(3.14f, this.transform.position.y);

        }
        else if (other == RightEdge)
        {
            this.transform.position = new Vector2(-3.14f, this.transform.position.y);

        }

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject == Grass)
        {
            Debug.Log("landing");
            jump = true;

        }
    }

    void CameraMovement()
    {
        float distance = this.transform.position.y - DetectLine.gameObject.transform.position.y;

        if (distance > 0)
        {
            float currentSpeed = Mathf.Lerp(moveSpeed, 0.1f, 1f - (distance / slowDownDistance));
            MainCamera.transform.position += currentSpeed * Time.deltaTime * Vector3.up;
        };

    }
    void DuckMovement()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);


        Vector2 objectPosition = transform.position;

        float distanceMouse = Mathf.Abs(mousePosition.x - objectPosition.x);


        float adjustedSpeed = moveSpeed * (distanceMouse / 10f);

        if (mousePosition.x + 1f < objectPosition.x)
        {

            rb.velocity = new Vector2(-adjustedSpeed, rb.velocity.y);
            this.gameObject.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else if (mousePosition.x - 1f > objectPosition.x)
        {

            rb.velocity = new Vector2(adjustedSpeed, rb.velocity.y);
            this.gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else
        {

            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        if (Input.GetKeyDown(KeyCode.Space) && jump == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, launchVelocity);
        }


    }
}
