using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    public GameObject missileExplosion;

    private GameObject gameControllerObject;
    private GameController gameController;
    private PowerUpDropController powerUpDropController;

    public int scoreValue;

    private void Start()
    {
        gameControllerObject = GameObject.FindGameObjectWithTag("GameController");

        if (gameControllerObject)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }

        if (!gameControllerObject)
        {
            Debug.Log("Cannot find 'GameController' script");
        }

        powerUpDropController = this.gameObject.GetComponent<PowerUpDropController>();
    }

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (
            other.CompareTag("Boundary") ||
            other.CompareTag("Enemy") ||
            other.CompareTag("EnemyBolt") ||
            other.CompareTag("PowerUp") ||
            (this.CompareTag("EnemyBolt") && other.CompareTag("Enemy")) ||
            (this.CompareTag("EnemyBolt") && other.CompareTag("Bolt")) ||
            (this.CompareTag("MissilePowerUp") && other.CompareTag("Player")) ||
            (this.CompareTag("MissilePowerUp") && other.CompareTag("Bolt")) ||
            (this.CompareTag("MissilePowerUp") && other.CompareTag("Missile")) ||
            (this.CompareTag("Missile") && other.CompareTag("Player")) ||
            (this.CompareTag("Missile") && other.CompareTag("Bolt"))
           )
        {
            return;
        }

        if (explosion)
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }

        if (missileExplosion && this.CompareTag("EnemyBolt") && other.CompareTag("Missile"))
        {
            Instantiate(missileExplosion, other.transform.position, other.transform.rotation);
        }

        if (playerExplosion && other.CompareTag("Player"))
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
        }

        gameController.AddScore(scoreValue);

        if (other.gameObject.transform.parent)
        {
            Destroy(other.gameObject.transform.parent.gameObject);
        }
        else
        {
            Destroy(other.gameObject);
        }

        if (powerUpDropController)
        {
            powerUpDropController.DropPowerUp();
        }

        if (gameObject.transform.parent)
        {
            Destroy(gameObject.transform.parent.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
