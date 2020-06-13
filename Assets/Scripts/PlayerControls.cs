using Photon.Pun;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    protected PhotonView photonView;
    private UIManager UIMenu;
    public static int PlayerCharacter;
    protected static Vector2 direction;
    protected float cooldown;
    private float waitSec = 0;
    public int hpPlayer;
    protected static string NickPlayer;
    private GameManager GameManagerScript;
    public void Start()
    {
        GameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
        photonView = PhotonView.Get(this);
        UIMenu = GameObject.Find("GameManager").GetComponent<UIManager>();
    }
    void Update()
    {
        if (!photonView.IsMine) return;
        if (Input.GetKey(KeyCode.A)) transform.Translate(new Vector2(-Time.deltaTime * 5, 0));
        if (Input.GetKey(KeyCode.D)) transform.Translate(new Vector2(Time.deltaTime * 5, 0));
        if (Input.GetKey(KeyCode.W)) transform.Translate(new Vector2(0, Time.deltaTime * 5));
        if (Input.GetKey(KeyCode.S)) transform.Translate(new Vector2(0, -Time.deltaTime * 5));
        if (waitSec < 5) waitSec += Time.deltaTime; ;
        if (Input.GetKey(KeyCode.Escape) && waitSec > 0.5f)//InGame Menu
        {
            waitSec = 0f;
            UIMenu.MenuReveal();
        }
        if (cooldown > 0.0f) cooldown -= Time.deltaTime;
        if (Input.GetKey(KeyCode.Mouse0) && cooldown <= 0.0f)
        {
            AttackPrimary();
        }
        if (hpPlayer <= 0) Destroy(gameObject);
    }
    public void AttackPrimary()//LeftMouse
    {
        Vector2 currentpos = transform.position;
        switch (PlayerCharacter)
        {
            case 0://Mage
                direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
                float sR = Mathf.Atan2(direction.x, direction.y);
                float sD = 360 * sR / (2 * Mathf.PI);
                PhotonNetwork.Instantiate(GameManagerScript.FireBlast.name, new Vector2
                    (currentpos.x + Mathf.Clamp(direction.x, -1, 1),
                        currentpos.y + Mathf.Clamp(direction.y, -1, 1)),
                    Quaternion.Euler(0, 0, sD));
                cooldown = 7.0f;
                break;
            case 1://Paladin
                direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
                PhotonNetwork.Instantiate(GameManagerScript.PaladinSword.name, new Vector2
                    (currentpos.x + Mathf.Clamp(direction.x, -1, 1),
                        currentpos.y + Mathf.Clamp(direction.y, -1, 1)), Quaternion.identity);
                cooldown = 0.90f;
                break;
            case 2://Rogue
                direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
                PhotonNetwork.Instantiate(GameManagerScript.RogueKnife.name, new Vector2
                    (currentpos.x + Mathf.Clamp(direction.x, -1, 1),
                        currentpos.y + Mathf.Clamp(direction.y, -1, 1)), Quaternion.identity);
                cooldown = 0.40f;
                break;
            case 3://Warrior
                direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
                PhotonNetwork.Instantiate(GameManagerScript.WarriorSword.name, new Vector2
                    (currentpos.x + Mathf.Clamp(direction.x, -1, 1),
                        currentpos.y + Mathf.Clamp(direction.y, -1, 1)), Quaternion.identity);
                cooldown = 0.90f;
                break;
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hpPlayer <= 0) Destroy(gameObject);
    }
}
