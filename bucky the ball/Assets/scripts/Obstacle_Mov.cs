using UnityEngine;

public class Obstacle_Mov : MonoBehaviour
{
    Rigidbody rb;

    private int ZSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ZSpeed = Random.Range(900, 1600);
        Incoming();
    }

    private void Incoming()
    {
        rb.velocity = Vector3.back * Time.fixedDeltaTime * ZSpeed;
    }
}
