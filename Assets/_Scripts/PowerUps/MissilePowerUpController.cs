using System.Collections.Generic;
using UnityEngine;


public class MissilePowerUpController : MonoBehaviour
{
    public GameObject projectile;
    public Transform[] projectileSpawns;
    public float fireRate;
    public float delay;

    private AudioSource audioSource;
    private GameObject enemyObject;

    // Start is called before the first frame update
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        InvokeRepeating(nameof(Fire), delay, fireRate);
    }

    // Update is called once per frame
    private void Fire()
    {
        enemyObject = GameObject.FindGameObjectWithTag("Enemy");
        if (!enemyObject)
        {
            return;
        }

        Transform projectileSpawn = projectileSpawns[Random.Range(0, projectileSpawns.Length)];

        if (projectileSpawn)
        {
            Instantiate(projectile, projectileSpawn.position, projectileSpawn.rotation);
            audioSource.Play();
        }

    }
}
