using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    Rigidbody rb;

    AudioSource ab;

    public Joystick joystick;

    [SerializeField] float HorizontalMove;

    [SerializeField] float VerticalMove;

    [SerializeField] AudioClip Explosion;

    [Tooltip("In ms^-1")] [SerializeField] float XSpeed = 5.0f;
    [Tooltip("In ms^-1")] [SerializeField] float XRange = 3.2f;

    [Tooltip("In ms^-1")] [SerializeField] float ZSpeed = 1.0f;

    Score count;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ab = GetComponent<AudioSource>();
        count = FindObjectOfType<Score>();
    }

    // Update is called once per frame
    void Update()
    {
        SideMov();
        SideMovUI();
        VertMov();
        VertMovUI();

        count.scorecount();
    }

    private void SideMovUI()
    {
        HorizontalMove = joystick.Horizontal * Time.fixedDeltaTime * XSpeed;
        Vector3 NewPos = rb.position + Vector3.right * HorizontalMove;

        NewPos.x = Mathf.Clamp(NewPos.x, -XRange, XRange);

        rb.MovePosition(NewPos);
    }

    private void SideMov()
    {
        float XThrow = Input.GetAxis("Horizontal") * Time.fixedDeltaTime * XSpeed;

        Vector3 NewPos = rb.position + Vector3.right * XThrow;

        NewPos.x = Mathf.Clamp(NewPos.x, -XRange, XRange);

        rb.MovePosition(NewPos);
    }

    private void VertMov()
    {
        float ZThrow = Input.GetAxis("Vertical") * Time.fixedDeltaTime * ZSpeed;

        Vector3 NewPos = rb.position + Vector3.forward * ZThrow;

        NewPos.z = Mathf.Clamp(NewPos.z, -13, -11);

        rb.MovePosition(NewPos);
    }

    private void VertMovUI()
    {
        float ZThrow = joystick.Vertical * Time.fixedDeltaTime * ZSpeed;

        Vector3 NewPos = rb.position + Vector3.forward * ZThrow;

        NewPos.z = Mathf.Clamp(NewPos.z, -13, -11);

        rb.MovePosition(NewPos);
    }

    private void DeathSequence()
    {
        ab.PlayOneShot(Explosion);
        FindObjectOfType<GameHandler>().EndGame();
        FindObjectOfType<MusicHandler>().stopper();
    }

    private void OnCollisionEnter(Collision other)
    {
        DeathSequence();
    }
}
