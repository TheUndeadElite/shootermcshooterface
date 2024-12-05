using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletspeed;
    GameObject bullet;
    Transform bullethole;
    void Start()
    {
        
    }

    void Update()
    {
        transform.position += -transform.right * Time.deltaTime * bulletspeed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == ("Enemy"))
        {

        }
    }
}
