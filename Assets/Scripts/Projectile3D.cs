using UnityEngine;

public class Projectile3D : MonoBehaviour
{
    [SerializeField] private Rigidbody myRB;
    private GameManager gameManager;

    private void Start()
    {
        myRB = GetComponent<Rigidbody>();
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        float angle = Mathf.Atan2(myRB.velocity.y, myRB.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Diana")
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
            gameManager.count = gameManager.count + 1;
        }
    }

}
