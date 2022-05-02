using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMechController : MonoBehaviour
{
    public enum MyMechState { 
        Walk,
        Idle,
        Die
    }


    public HealthController m_health;

    public MyMechState myMechState = MyMechState.Idle;

    private Animator anim;

    public AudioSource playerMechAS;
    public List<AudioClip> playerMechMoveClips; //0.walk



    [SerializeField]
    private GameObject UpperTorso;
    public float torsoRotationX;
    public float torsoRotationMinX = -90f;
    public float torsoRotationMaxX = 90f;


    [SerializeField]
    private GameObject leftArm;
    [SerializeField]
    private GameObject rightArm;
    public float armRotationY;
    public float armRotationMinY = -135f;
    public float armRotationMaxY = -45f;



    [SerializeField]
    private float hInput, vInput, xMouse, yMouse;
    public float MovementSpeed;
    public float RotateSpeed;

    [SerializeField]
    private Camera FirstViewCam;
    [SerializeField]
    private Camera ThirdViewCam;

    [SerializeField]
    private EndGameFlade EndGameFlade;
    private bool isCallEndGame = false;

    [SerializeField]
    private GameObject miniMap;

    [SerializeField]
    private GameObject crossHair;

    [SerializeField]
    private GameObject firstViewDirectionObj;
    [SerializeField]
    private GameObject die_explo_ps;
    [SerializeField]
    private Transform die_position;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        playerMechAS.volume = 0.6f;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_health.IsDie())
        {
            //TODO: Game Over - jump to GameOverSence
            //Debug.Log("The player mech Die");
            myMechState = MyMechState.Die;
            if (!isCallEndGame)
            {
                isCallEndGame = true;
                EndGameFlade.SetEndGameType(2);
                ParticleSystem explosionPs = Instantiate(die_explo_ps, die_position.position, Quaternion.identity).GetComponent<ParticleSystem>();

                if (FirstViewCam.gameObject.activeInHierarchy)
                {
                    ThirdViewCam.gameObject.SetActive(true);
                    FirstViewCam.gameObject.SetActive(false);
                }
                ThirdViewCam.transform.SetParent(null);
                gameObject.SetActive(false);
            }
        }
        else {
            CameraControl();
            Movement();
        }
        SwitchAnim();
        SwitchAudio();

    }

    private void CameraControl()
    {
        if (Input.GetKeyUp(KeyCode.Space)) {
            if (FirstViewCam.gameObject.activeInHierarchy && !ThirdViewCam.gameObject.activeInHierarchy)
            {
                FirstViewCam.gameObject.SetActive(false);
                ThirdViewCam.gameObject.SetActive(true);
                if (miniMap.activeInHierarchy) {
                    miniMap.SetActive(false);
                }
                if (crossHair.activeInHierarchy)
                {
                    crossHair.SetActive(false);
                }

            }
            else if (ThirdViewCam.gameObject.activeInHierarchy && !FirstViewCam.gameObject.activeInHierarchy) {
                FirstViewCam.gameObject.SetActive(true);
                ThirdViewCam.gameObject.SetActive(false);
                if (!miniMap.activeInHierarchy)
                {
                    miniMap.SetActive(true);
                }
                if (!crossHair.activeInHierarchy)
                {
                    crossHair.SetActive(true);
                }
                //if (CrossHairController.instance)
                //    CrossHairController.instance.SyncActiveWeaponCrossHair();
            }
        }
    }

    private void SwitchAudio()
    {
        switch (myMechState)
        {
            case MyMechState.Walk:
                playerMechAS.pitch = 1.5f;
                playerMechAS.clip = playerMechMoveClips[0];
                if (!playerMechAS.isPlaying) {
                    playerMechAS.Play();
                }
                break;
            case MyMechState.Idle:
                playerMechAS.pitch = 1f;
                if (playerMechAS.isPlaying) {
                    playerMechAS.Pause();
                }
                break;
            case MyMechState.Die:
                if (playerMechAS.isPlaying)
                {
                    playerMechAS.Pause();
                }
                break;
            default:
                break;
        }
    }

    private void SwitchAnim()
    {
        switch (myMechState)
        {
            case MyMechState.Walk:
                anim.SetBool("Walk", true);
                anim.SetFloat("WalkBT", vInput);
                break;
            case MyMechState.Idle:
                anim.SetBool("Walk", false);
                anim.SetFloat("WalkBT", vInput);
                break;
            case MyMechState.Die:
                //anim.SetBool("Die", true);
                anim.SetBool("Walk", false);
                break;
            default:
                break;
        }
    }

    private void Movement() {
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");
        xMouse = Input.GetAxis("Mouse X");
        yMouse = Input.GetAxis("Mouse Y");

        transform.Translate(new Vector3(0, 0, vInput) * Time.deltaTime * MovementSpeed);
        transform.Rotate(Vector3.up * hInput * Time.deltaTime * RotateSpeed);

        torsoRotationX += xMouse * RotateSpeed * Time.deltaTime;
        torsoRotationX = Mathf.Clamp(torsoRotationX, torsoRotationMinX, torsoRotationMaxX);
        UpperTorso.transform.localEulerAngles = new Vector3(-torsoRotationX, 0, 0);
        firstViewDirectionObj.transform.localEulerAngles = new Vector3(0, 0, 70 - torsoRotationX);

        armRotationY += -yMouse * RotateSpeed * Time.deltaTime;
        armRotationY = Mathf.Clamp(armRotationY, armRotationMinY, armRotationMaxY);
        leftArm.transform.localEulerAngles = new Vector3(0, armRotationY, 0);
        rightArm.transform.localEulerAngles = new Vector3(0, armRotationY, 0);

        if (vInput != 0 || hInput !=0)
        {
            myMechState = MyMechState.Walk;
        }
        else {
            myMechState = MyMechState.Idle;
        }
    }
}
