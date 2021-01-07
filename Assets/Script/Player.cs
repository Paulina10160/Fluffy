using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool grounded;
    public float moveSpeed;
    public float jumpHeight;
    private bool isPressedW = false;
    private bool isMoving = false;
    private bool isPressedQ = false;
    private bool isPressedSpace = false;

    public GroundCheck groundCheck;

    private FluffyAdventure.Collision collision;

    public float ladderSpeed;

    private bool isOnLadder = false;

    public GameObject[] bulletPrefab;

    public float shotSpeed;

    public int lastDirction = 1;

    public int jumpCount;

    public int currentAmmoIndex = 0;

    public Transform gunPoint;

    private void Start()
    {
        //PlayerPrefs.DeleteAll();
        collision = GetComponent<FluffyAdventure.Collision>();
        groundCheck.onGrounded += GroundCheck_onGrounded;
        jumpCount = 2;
        currentAmmoIndex = PlayerPrefs.GetInt("Ammo", 0);
    }

    private void GroundCheck_onGrounded()
    {
        if (!grounded)
        {
            Debug.Log("Stop");
            if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Jump"))
            {
                GetComponent<Animator>().SetTrigger("Grounded");
            }
            grounded = true;
            jumpCount = 2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale == 0)
        {
            return;
        }

        if (!isOnLadder)
        {
            if (Input.GetKeyDown(KeyCode.W)) //Kiedy przycisk jest wcisniety to tak się dzieje
            {
                if (!isPressedW)
                {
                    isPressedW = true;
                    if (grounded || jumpCount == 1)
                    {
                        GetComponent<Rigidbody2D>().velocity = new Vector2(0, jumpHeight);
                        grounded = false;
                        GetComponent<Animator>().SetTrigger("StartJump");
                        SoundManager.Instance.PlayJumpSound();
                        jumpCount--;
                    }
                }
            }
            else
            {
                isPressedW = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space)) //Kiedy przycisk jest wcisniety to tak się dzieje
        {
            if (!isPressedSpace)
            {
                isPressedSpace = true;
                //if (grounded)
                //{
                //if(Time.frameCount % 10 == 0)
                //{
                SoundManager.Instance.PlayGunSound();
                GetComponent<Animator>().SetTrigger("OnShot");
                GetComponent<Animator>().SetBool("hasGun", true);
                GameObject carrot = Instantiate(bulletPrefab[currentAmmoIndex]);
                carrot.GetComponent<FlyObject>().speed = lastDirction * shotSpeed;
                carrot.transform.position = gunPoint.position;
                carrot.transform.localScale = new Vector3(lastDirction, 1, 1);
                 transform.localScale = new Vector3(lastDirction, 1, 1);
                //}

                //}
            }
        }
        else
        {
            isPressedSpace = false;
            //GetComponent<Animator>().SetBool("hasGun", false);
        }
        

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (!isPressedQ)
            {
                isPressedQ = true;
                if (collision.ladder != null)
                {
                    if (isOnLadder)
                    {
                        //jesli jest na drabinie to wchodzi
                        float distance = transform.position.y - collision.ladder.transform.position.y;
                        Debug.Log(distance);
                        if(distance > 0.8)
                        {
                            Vector3 v = transform.position;
                            v.y += 0.2f;
                            transform.position = v;
                        }
                        isOnLadder = false;
                        GetComponent<Animator>().SetBool("OnLadder", false);
                        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                        
                    }
                    else
                    {
                        isOnLadder = true;
                        //jesli nie jest na drabinie to wchodzi
                        GetComponent<Animator>().SetBool("OnLadder", true);
                        transform.position = new Vector3(collision.ladder.transform.position.x, transform.position.y, transform.position.z);
                        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;

                    }
                }
            }
        }
        else
        {
            isPressedQ = false;
        }

        if (!isOnLadder)
        {
            float move = Input.GetAxis("Horizontal");
            if (move > 0.2 || move < -0.2)
            {
                if (move < 0)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                }
                else
                {
                    transform.localScale = new Vector3(1, 1, 1);
                }

                GetComponent<Rigidbody2D>().velocity = new Vector2(move * moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
                GetComponent<Animator>().SetBool("Walking", true);
            }
            else if(GetComponent<Animator>().GetBool("Walking"))
            {
                transform.localScale = new Vector3(1, 1, 1);
                GetComponent<Animator>().SetBool("Walking", false);
                GetComponent<Animator>().SetBool("hasGun", false);
            }
        }
        else if (collision.ladder != null)
        {
            Vector3 pos = transform.position;

            Transform posUp = collision.ladder.transform.GetChild(0);
            Transform posDown = collision.ladder.transform.GetChild(1);

            if (Input.GetKey(KeyCode.S) && pos.y >= posDown.position.y)
            {
                pos.y -= ladderSpeed * Time.deltaTime;
                GetComponent<Animator>().SetBool("OnLadderRun", true);
            }
            else if (Input.GetKey(KeyCode.W) && pos.y <= posUp.position.y)
            {
                pos.y += ladderSpeed * Time.deltaTime;
                GetComponent<Animator>().SetBool("OnLadderRun", true);
            }
            else
            {
                GetComponent<Animator>().SetBool("OnLadderRun", false);
            }
            transform.position = pos;
        }
        else
        {
            isOnLadder = false;
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            GetComponent<Animator>().SetBool("OnLadder", false);
        }

        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            lastDirction = -1;
        }
        else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            lastDirction = 1;
        }


        /*if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y); //idziemy w prawo po y
        }
        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y); //idziemy w lewo po y ( bo - przed moveSpeed)
        }*/
    }

    public void SetToNormalScale()
    {
        transform.localScale = new Vector3(1, 1, 1);
    }

    private void LateUpdate()
    {
        //transform.localRotation = new Quaternion(0, 0, 0, 0);
    }
}
