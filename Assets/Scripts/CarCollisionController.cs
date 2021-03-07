using UnityEngine;

public class CarCollisionController : MonoBehaviour
{
    [SerializeField] private ParkingManager m_ParkingManager;

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.isTrigger)
            m_ParkingManager.AddCollision();
    }
}
