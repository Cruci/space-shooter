using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    public GameObject[] powerUps;

    private GameObject playerGameObject;
    private PlayerController playerController;
    private GameObject destroyGameObject;
    private DestroyGameObject destroyGameObjectController;

    private void Start()
    {
        GetPlayer();
        GetCleanUp();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Pickup(other);
        }
    }

    private void GetPlayer()
    {
        playerGameObject = FindGameObject("Player");

        if (playerGameObject)
        {
            playerController = playerGameObject.GetComponent<PlayerController>();
        }

        if (!playerGameObject)
        {
            Debug.Log("Cannot find 'DestroyGameObject' script");
        }
    }

    private void GetCleanUp()
    {
        destroyGameObject = FindGameObject("CleanUp");

        if (destroyGameObject)
        {
            destroyGameObjectController = destroyGameObject.GetComponent<DestroyGameObject>();
        }

        if (!destroyGameObject)
        {
            Debug.Log("Cannot find 'DestroyGameObject' script");
        }
    }

    private GameObject FindGameObject(string gameObjectTag)
    {
        return GameObject.FindGameObjectWithTag(gameObjectTag);
    }

    private void Pickup(Collider player)
    {
        GameObject powerUp = powerUps[Random.Range(0, powerUps.Length)];

        if (!playerController.IfObtainedPowerUp(powerUp.tag))
        {
            playerController.ActivatePowerUp(powerUp);
        }

        destroyGameObjectController.DestroyGameObjectOnContact(this.gameObject);
    }
}
