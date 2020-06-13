using Photon.Pun;
using UnityEngine;

public class shell : PlayerControls
{
    [SerializeField]
    private float LivingTime;
    [SerializeField]
    private int Damage;
    void Update()
    {
        transform.Translate(direction.normalized/8);//Magic number
        Destroy(gameObject, LivingTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("dsgs");
        if (!collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        else if (gameObject.transform.parent != collision.gameObject.transform.parent)
        {
            collision.gameObject.GetComponent<PlayerControls>().hpPlayer -= Damage;
            Destroy(gameObject);
        }
    }
}
