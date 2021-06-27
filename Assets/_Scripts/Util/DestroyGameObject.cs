using UnityEngine;

public class DestroyGameObject : MonoBehaviour
{

    public void DestroyGameObjectOnContact(GameObject gameObject)
    {
        if (gameObject.transform.parent)
        {
            Destroy(gameObject.transform.parent.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void DestroyOtherGameObjectOnContact(Collider other)
    {
        if (other && other.gameObject.transform.parent)
        {
            Destroy(other.gameObject.transform.parent.gameObject);
        }
        else
        {
            Destroy(other.gameObject);
        }
    }
}
