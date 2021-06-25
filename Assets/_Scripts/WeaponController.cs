using System.Collections;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject projectile;
    public Transform projectileSpawn;
    public float fireRate;
    public float delay;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        InvokeRepeating(nameof(Fire), delay, fireRate);
    }

    // Update is called once per frame
    private void Fire()
    {
        Instantiate(projectile, projectileSpawn.position, projectileSpawn.rotation);
        audioSource.Play();
    }
}
