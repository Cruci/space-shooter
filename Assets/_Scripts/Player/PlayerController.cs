using System.Collections.Generic;
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
    public GameObject weapon;
    public List<GameObject> activePowerUps;

    public float speed;
    public float tilt;
    public float fireRate;

    private GameObject[] projectilesSpawns;
    private AudioSource playerProjectileAudio;
    
    private float nextFire;

    // Start is called before the first frame update
    private void Start()
    {
        activePowerUps = new List<GameObject>();
        rb = GetComponent<Rigidbody>();
        playerProjectileAudio = gameObject.GetComponent<AudioSource>();
    }

    private void Update()
    {
        ShootWeapon();
    }

    private void FixedUpdate()
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

    private void ShootWeapon()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            InstantiateWeaponGameObjects("Projectile");
        }
    }

    private void InstantiateWeaponGameObjects(string weaponType)
    {
        projectilesSpawns = GameObject.FindGameObjectsWithTag(weaponType);

        foreach (GameObject spawn in projectilesSpawns)
        {
            Instantiate(weapon, spawn.transform.position, spawn.transform.rotation);
        }

        if (playerProjectileAudio != null)
        {
            playerProjectileAudio.Play();
        }
    }

    public bool IfObtainedPowerUp(string tag)
    {
        return !!this.activePowerUps.Find(powerUp => powerUp.CompareTag(tag));
    }

    public void ActivatePowerUp(GameObject powerUp)
    {
        activePowerUps.Add(powerUp);
        Instantiate(powerUp, this.transform, false);
        Debug.Log("Power up activated");
    }
}
