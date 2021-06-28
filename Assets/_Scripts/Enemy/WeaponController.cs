using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject projectile;
    public Transform[] projectileSpawns;
    public float fireRate;
    public float delay;

    private AudioSource audioSource;

    // Start is called before the first frame update
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        InvokeRepeating(nameof(Fire), delay, fireRate);
    }

    // Update is called once per frame
    private void Fire()
    {
        Transform projectileSpawn = projectileSpawns[Random.Range(0, projectileSpawns.Length)];

        if (projectileSpawn)
        {
            Instantiate(projectile, projectileSpawn.position, projectileSpawn.rotation);
            audioSource.Play();
        }

    }
}
