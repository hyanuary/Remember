using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour {

    public Camera mainCamera;
    public GameObject carriedObject;
    public bool isCarrying;
    public bool isOpened;
	public bool haveKey;
    public float distance = 5;
    public float smooth;
    public float timer = 5;

    public UIManager ui;
   
    // Use this for initialization
    void Start () {

       
    }
	
	// Update is called once per frame
	void Update () {
      if(isCarrying)
        {
            carry(carriedObject);
            checkDrop();
        }
      else
        {
            PickUp();
        }
        openDoor();

        

    }

    void carry(GameObject objects)
    {
        objects.transform.position = Vector3.Lerp(objects.transform.position, mainCamera.transform.position + mainCamera.transform.forward * distance, Time.deltaTime * smooth);
    }

    void PickUp()
    {
		if (Input.GetButtonDown("Pick Up"))
        {
            int x = Screen.width / 2;
            int y = Screen.height / 2;

            Ray ray = mainCamera.ScreenPointToRay(new Vector3(x, y));
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                Debug.DrawLine(ray.origin, hit.point);
                PickUpable p = hit.collider.GetComponent<PickUpable>();
                if(p != null)
                {
                    isCarrying = true;
                    carriedObject = p.gameObject;
                    p.rb.isKinematic = true;
                }
            }
        }
    }

    void checkDrop()
    {
		if(Input.GetButtonDown("Pick Up"))
        {
            dropObject();
            ui.temper();
        }
    }

    void dropObject()
    {
        isCarrying = false;
        carriedObject.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        carriedObject = null;
       
    }

    void openDoor()
    {
		if (Input.GetButtonDown("Pick Up"))
        {
            int x = Screen.width / 2;
            int y = Screen.height / 2;

            Ray ray = mainCamera.ScreenPointToRay(new Vector3(x, y));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Door d = hit.collider.GetComponent<Door>();
                
                if (d != null)
                {
                    d.timerOn = true;
                    d.turn = true;
                    isOpened = true;
                   
                }
            }
        }
    }


}
