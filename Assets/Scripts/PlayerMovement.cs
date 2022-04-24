using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float vInput;
    public float hInput;
    public float mouseX;
    public float mouseY;
    public float movementSpeed;
    public float rotateSpeed;

    public float fire1;

    public bool changeColor;
    //public float 

    public Camera playerViewCam;

    public Vector3 angles;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        movementSpeed = 5.0f;
        rotateSpeed = 200.0f;
    }

    // Update is called once per frame
    void Update()
    {
        fire1 = Input.GetAxis("Fire1");
        changeColor = Input.GetKeyUp(KeyCode.Alpha1);

        if (changeColor) {

            BroadcastMessage("ChangeBarrelColor");

        }
        if (fire1 == 1)
        {
            BroadcastMessage("FireGrenade", 30);
        }

        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Home))
        {
            Application.Quit();
        }
    }

    private void FixedUpdate()
    {
        vInput = Input.GetAxis("Vertical");
        hInput = Input.GetAxis("Horizontal");
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        transform.Translate(hInput * Time.deltaTime * movementSpeed, 0, vInput * Time.deltaTime * movementSpeed);


        transform.Rotate(Vector3.up, mouseX * Time.deltaTime * rotateSpeed);
        //playerViewCam.transform.Rotate(-mouseY * Time.deltaTime * rotateSpeed, mouseX * Time.deltaTime * rotateSpeed, 0, Space.World);
        playerViewCam.transform.Rotate(Vector3.right * -mouseY * Time.deltaTime * rotateSpeed);
        //playerViewCam.transform.Rotate(0, mouseX * Time.deltaTime * rotateSpeed, 0);

        angles = playerViewCam.transform.localRotation.eulerAngles;

        if (angles.x > 45.0f && angles.x < 180.0f)
        {

            //playerViewCam.transform.localRotation = Quaternion.Euler(45.0f, angles.y, angles.z);
            playerViewCam.transform.localRotation = Quaternion.Euler(45.0f, 0, 0);

        }
        else if (angles.x < 315.0f && angles.x >= 180.0f)
        {

            //playerViewCam.transform.localRotation = Quaternion.Euler(315.0f, angles.y, angles.z);
            playerViewCam.transform.localRotation = Quaternion.Euler(315.0f, 0, 0);

        }

    }
}
