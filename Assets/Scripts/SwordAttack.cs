using Photon.Pun;
using UnityEngine;

public class SwordAttack : PlayerControls
{
    [SerializeField]
    private float LivingTime;
    [SerializeField]
    private int Damage;
    private void Update()
    {
        Destroy(gameObject, LivingTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        else if (NickPlayer != collision.gameObject.GetComponent<PhotonView>().Owner.NickName.ToString())
        {
            collision.gameObject.GetComponent<PlayerControls>().hpPlayer -= Damage;
            Destroy(gameObject);
        }
    }
}
