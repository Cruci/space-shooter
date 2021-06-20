using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;

}

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public Boundary boundary;
    public GameObject projectileSpawn;

    public float speed;
    public float tilt;
    public float fireRate;

    private GameObject[] projectilesSpawns;
    private AudioSource playerProjectileAudio;

    private float nextFire;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerProjectileAudio = gameObject.GetComponent(typeof(AudioSource)) as AudioSource;
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            projectilesSpawns = GameObject.FindGameObjectsWithTag("Projectile");

            foreach (GameObject spawn in projectilesSpawns)
            {
                Instantiate(projectileSpawn, spawn.transform.position, spawn.transform.rotation);
            }
            
            if (playerProjectileAudio != null)
            {
                playerProjectileAudio.Play();
            }
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.velocity = movement * speed;

        rb.position = new Vector3
        (
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
        );

        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * (-tilt / 10));
    }
}
