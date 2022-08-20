using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Citizen : MonoBehaviour
{
    private enum citizenState
    {
        Normal,
        mNormal,
        Vac,
        Sus,
        mSus,
        Infected
        
    }
    
    public Material normalSprite;
    public Material mNormalSprite;
    public Material vacSprite;
    public Material susSprite;
    public Material mSusSprite;
    public Material infectedSprite;
    
    public static int normalTotal=0;
    public static int mNormalTotal = 0;
    public static int vacTotal = 0;
    public static int susTotal = 0;
    public static int mSusTotal = 0;
    public static int infectedTotal = 0;
    public static float speedMultipler=1f;

  

    public SkinnedMeshRenderer mesh;
    public SkinnedMeshRenderer mapMesh;


    public int selectedSprite;
    private SpriteRenderer currentSprite;
    private Rigidbody body;

    public bool isGrabbed;
    private GameObject playerGrab;
    public GameObject virus;

    private AudioSource fx;
    public AudioClip destroyMask;
    public AudioClip sick;

    public Animator animation;
    private float horizontal;
    private float vertical;
    float cameraSpeedFollow = 0.1f;
    float cameraVelocity;
    public CharacterController control;

    public bool originallyInfected;

    // Start is called before the first frame update
    void Start()
    {
       // currentSprite = this.GetComponent<SpriteRenderer>();
       // currentSprite.enabled = false;
        fx = this.GetComponent<AudioSource>();
        playerGrab = GameObject.Find("GrabPoint");
        isGrabbed = false;
        ArrayList list = new ArrayList();
       
        if (normalTotal < SliderText.nNormal)
        {
            list.Add(0);
        }
        if (mNormalTotal < SliderText.nNormalM)
        {
            list.Add(1);
        }
        if (vacTotal < SliderText.nVac)
        {
            list.Add(2);
        }
        if (susTotal < SliderText.nSus)
        {
            list.Add(3);
        }
        if (mSusTotal < SliderText.nSusM)
        {
            list.Add(4);
        }
        if (infectedTotal < SliderText.nInfected)
        {
            list.Add(5);
        }
       
        if (list.Count == 0)
        {
           Destroy(this.gameObject);
           return;
        }

        body = this.GetComponent<Rigidbody>();
        
        
       // currentSprite.enabled = true;
        int index = Random.Range(0, list.Count);
        //Debug.Log(selectionList.Count);
       
        selectedSprite = (int)list[index];
        
        if (selectedSprite == 5)
        {
            originallyInfected = true;
        }
        else
        {
            originallyInfected = false;
        }
        //for (int i=0;i< selectionList.Count; i++)
        // {
        //  Debug.Log(selectionList[i]);
        // }
        InvokeRepeating("MoveAround", 0.5f, 2f);
        InvokeRepeating("RemoveMask", 5f, 5f);
        InvokeRepeating("SpreadDisease", 2f, 3f);
        ChangeSprite();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.transform.position.y < -10.95&&!isGrabbed)
        {
            if (selectedSprite == 5)
            {
                GiveMasks.score += 5;
            }
            Destroy(this.gameObject);
        }
        if (isGrabbed)
        {
            this.transform.position = playerGrab.transform.position;
        }

        if (horizontal == 0 && vertical == 0)
        {
            animation.SetBool("running", false);
        }
        else
        {
            animation.SetBool("running", true);
        }
       
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        Vector3 movDir = new Vector3(0, 0, 0);
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref cameraVelocity, cameraSpeedFollow);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            movDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
        }
        
            movDir += new Vector3(0, -9.81f, 0);
        
        if (!isGrabbed)
        {
            control.Move(movDir.normalized * 5 * 9.81f*speedMultipler* Time.deltaTime);
        }
        else
        {
            control.Move(movDir.normalized * 0);
        }
        


    }
    
       public void editSprite(int sprite)
        {
        Material[] listMat = mesh.materials;
            switch (sprite)
            {
                case 0:
                    selectedSprite = 0;
                listMat[0] = normalSprite;
                mesh.materials = listMat;
                mapMesh.materials = listMat;
                break;
                case 1:
                    selectedSprite = 1;
                listMat[0] = mNormalSprite;
                mesh.materials = listMat;
                mapMesh.materials = listMat;
                break;
                case 2:
                    selectedSprite = 2;
                  listMat[0] = vacSprite;
                mesh.materials = listMat;
                mapMesh.materials = listMat;
                break;
                case 3:
                    selectedSprite = 3;
                listMat[0] = susSprite;
                mesh.materials = listMat;
                mapMesh.materials = listMat;
                break;
                case 4:
                    selectedSprite = 4;
                listMat[0] = mSusSprite;
                mesh.materials = listMat;
                mapMesh.materials = listMat;

                break;
                case 5:
                    selectedSprite = 5;
                listMat[0] = infectedSprite;
                mesh.materials = listMat;
                mapMesh.materials = listMat;
                break;
            }
        }



        void ChangeSprite()
        {
        Material[] listMat = mesh.materials;
        switch (selectedSprite)
            {
                case 0:
                    normalTotal++;
                listMat[0] = normalSprite;
                mesh.materials = listMat;
                mapMesh.materials = listMat;

                break;
                case 1:
                    mNormalTotal++;
                listMat[0] = mNormalSprite;
                mesh.materials = listMat;
                mapMesh.materials = listMat;

                break;
                case 2:
                    vacTotal++;
                listMat[0] = vacSprite;
                mesh.materials = listMat;
                mapMesh.materials = listMat;

                break;
                case 3:
                    susTotal++;
                listMat[0] = susSprite;
                mesh.materials = listMat;
                mapMesh.materials = listMat;

                break;
                case 4:
                    mSusTotal++;
                listMat[0] = mSusSprite;
                mesh.materials = listMat;
                mapMesh.materials = listMat;

                break;
                case 5:
                    infectedTotal++;
                listMat[0] = infectedSprite;
                mesh.materials = listMat;
                mapMesh.materials = listMat;

                break;
            }
        }
    
    void MoveAround()
    {
        if (!isGrabbed)
        {
            vertical = Random.Range(-1, 2);
            horizontal = Random.Range(-1, 2);

            // float speed = Random.Range(1f, 3f) * speedMultipler;

        }
       
    }


    void RemoveMask()
    {
        int randomizer = Random.Range(0, 4);
        if (randomizer == 0)
        {
            if (selectedSprite == 1 || selectedSprite == 4)
            {
                editSprite(selectedSprite - 1);
            }
        }
        
    }

    public static void IncreaseCitizen()
    {
        
        if (!LoadLevel.special)
        {
            SliderText.nNormal += 1;
            SliderText.nNormalM += 1;
            SliderText.nSus += 1;
            SliderText.nSusM += 1;
            SliderText.nVac += 1;
            SliderText.nInfected += 1;
        }
        else
        {
            SliderText.nNormal += 2;
            SliderText.nNormalM += 2;
            SliderText.nSus += 2;
            SliderText.nSusM += 2;
            SliderText.nVac += 2;
            SliderText.nInfected += 2;
        }

    }

    public static void ResetCitizen()
    {
        normalTotal = 0;
        mNormalTotal = 0;
        vacTotal = 0;
        susTotal = 0;
        mSusTotal = 0;
        infectedTotal = 0;

        SliderText.nNormal -= 2;
        SliderText.nNormalM -= 2;
        SliderText.nSus -= 2;
        SliderText.nSusM -= 2;
        SliderText.nVac -= 2;
        SliderText.nInfected -= 2;
    }

    public int getSprite()
    {
        return selectedSprite;
    }

    public void setGrabbed(bool state)
    {
        isGrabbed = state;
    }

    public int getInfectedTotal()
    {
        return infectedTotal;
    }

    public void setInfectedTotal(int amount)
    {
        infectedTotal = amount;
    }
    public int getNormalTotal()
    {
        return normalTotal;
    }

    public void setNormalTotal(int amount)
    {
        normalTotal = amount;
    }


    public int getNormalMTotal()
    {
        return mNormalTotal;
    }

    public void setNormalMTotal(int amount)
    {
        mNormalTotal = amount;
    }

    public int getSusTotal()
    {
        return susTotal;
    }

    public void setSusTotal(int amount)
    {
        susTotal = amount;
    }

    public int getSusMTotal()
    {
        return mSusTotal;
    }

    public void setSusMTotal(int amount)
    {
        mSusTotal = amount;
    }

    
    public void SpreadDisease()
    {
        if (selectedSprite == 5)
        {
            int randomizer = Random.Range(0, 3);

            if (randomizer == 0)
            {
                GiveMasks.score -= 1;
               GameObject obj= Instantiate(virus, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity) as GameObject;
                obj.GetComponent<InfectPeople>().originallyInfected = this.originallyInfected;
                fx.PlayOneShot(sick);
            }
        }
    }
}
