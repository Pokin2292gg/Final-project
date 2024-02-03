using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public DoorController door;
    public float eyeDistance = 5.0f;
    private Ray ray;
    private RaycastHit hitData;
    public Text msg;
    public int itemCount = 0;
    public GameObject itemToDrop;
    public GameObject itemToDropPrefab;
    
   

    void Start()
    {
        msg.gameObject.SetActive(false);
        
    }

    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(ray.origin, ray.direction * eyeDistance, Color.red);

        if (Physics.Raycast(ray, out hitData, eyeDistance))
        {
            switch (hitData.transform.gameObject.tag)
            {
                case "doors":
                    msg.text = "Press F to Open/Close";
                    msg.gameObject.SetActive(true);
                    Debug.DrawRay(ray.origin, ray.direction * eyeDistance, Color.green);

                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        door.control();
                    }
                    break;

                case "Monster":
                    msg.text = "Kill him Left mouse";
                    msg.gameObject.SetActive(true);
                    Debug.DrawRay(ray.origin, ray.direction * eyeDistance, Color.yellow);

                    if (Input.GetMouseButtonDown(0))
                    {
                        Destroy(hitData.transform.gameObject);
                        DropItem(hitData.transform.position);
                    }
                    break;

                case "Monster2":
                    msg.text = "Kill him Left mouse";
                    msg.gameObject.SetActive(true);
                    Debug.DrawRay(ray.origin, ray.direction * eyeDistance, Color.yellow);

                    if (Input.GetMouseButtonDown(0))
                    {
                        Destroy(hitData.transform.gameObject);
                    }
                    break;

                case "Silde":
                    msg.text = "Press F to Open/Close";
                    msg.gameObject.SetActive(true);
                    Debug.DrawRay(ray.origin, ray.direction * eyeDistance, Color.green);

                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        door.control();
                    }
                    break;

                case "Item":
                    msg.text = "Press E to Pick Up";
                    msg.gameObject.SetActive(true);
                    Debug.DrawRay(ray.origin, ray.direction * eyeDistance, Color.blue);

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        Destroy(hitData.transform.gameObject);
                        Timer.scoreCount += 100;
                        
                    }
                    break;

                default:
                    msg.gameObject.SetActive(false);
                    break;
            }
        }
        else
        {
            msg.gameObject.SetActive(false);
        }
    }

    void DropItem(Vector3 position)
    {
        if (itemToDropPrefab != null)
        {
            Instantiate(itemToDropPrefab, position, Quaternion.identity);
        }
    }

    
}
