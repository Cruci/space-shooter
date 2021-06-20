using UnityEngine;

public class RandomRotator : MonoBehaviour
{
    public Rigidbody rb;

    public float tumble;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.angularVelocity = Random.insideUnitSphere * tumble;
    }
}
