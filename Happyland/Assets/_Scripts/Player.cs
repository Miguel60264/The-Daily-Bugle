using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private CharacterController _controller;

    private float timeToDie = 0.0f;

    public float playerLife = 100;
    [SerializeField]
    private float _speed = 3.5f;
    [SerializeField]
    private float _gravity = 9.81f;
    [SerializeField]
    private GameObject _muzzleFlash;
    [SerializeField]
    private GameObject _hitMarkerPrefab;
    [SerializeField]
    private AudioSource _weaponAudio;

    [SerializeField]
    private int currentAmmo;
    private int maxAmmo = 50;

    private bool _isReLoading = false;

    private IU_Manager _uiManager;

    public bool hasMaster = false;

    public bool hasCat = false;

    public bool hasBear = false;

    [SerializeField]
    private GameObject _weapon;

    [SerializeField]
    private GameObject _knife;

    public bool knifeActive = false;

    public bool weaponActive = true;

    public bool inmunity = false;

    public bool speed = false;

    public float currentCollectables = 0;

    public bool gamepause;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        //Inicia la cantidad de balas
        currentAmmo = maxAmmo;
        _uiManager = GameObject.Find("Canvas").GetComponent<IU_Manager>();
        _uiManager.UpdateAmmo(currentAmmo);
        gamepause = false;

    }

  
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0) && currentAmmo > 0)
        { 
            if(knifeActive==false)
            Shoot();
        }
        else
            { 
                _muzzleFlash.SetActive(false);  
                _weaponAudio.Stop();
            }

        if(Input.GetKeyDown(KeyCode.R) && _isReLoading == false)
        {
            _isReLoading = true;
            StartCoroutine(Reload());
        }
        if (gamepause == false)
        {
            CalculateMovement();
            Debug.Log("Entrando");

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
        }
       
        
        if (hasMaster == true)
        {
            _uiManager.CollectMaestro();
        }

        if (hasCat == true)
        {
            _uiManager.CollectGato();
        }

        if (hasBear == true)
        {
            _uiManager.CollectPeluche();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {    
            if(weaponActive==false)
                 EnableWeapons();
            else
                {
                EnableKnife();

                }
        }

        if (inmunity == true)
        {
            GrenadeActivate();
        }

        if (speed == true)
        {
            SpeedPotionActivate();
        }
    }

    void Shoot()
    {

        _muzzleFlash.SetActive(true);
        currentAmmo = currentAmmo - 1;
        _uiManager.UpdateAmmo(currentAmmo);
        if (_weaponAudio.isPlaying == false)
            {
            _weaponAudio.Play();
            }
        Ray rayOrigin = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hitInfo;
        if (Physics.Raycast(rayOrigin, out hitInfo))
        {
            Debug.Log("Hit: " + hitInfo.transform.name);
            GameObject hitMarker = Instantiate(_hitMarkerPrefab, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
            Destroy(hitMarker, 1F);
            //Check if we hit the create
            //Destroy Create Method
            Destructable create = hitInfo.transform.GetComponent<Destructable>();
            if(create!=null)
            {
                create.DestroyCreate();                
            }

        }
    }

    IEnumerator Reload()
    {
       yield return new WaitForSeconds (1f);
       currentAmmo = maxAmmo;
       _uiManager.UpdateAmmo(currentAmmo);
       _isReLoading = false;
    }

    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticallInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput, 0, verticallInput);
        Vector3 velocity = direction * _speed;
        velocity.y -= _gravity;
        //Convertir el vector velocity en world space. Toma los valores de velocity en local space y pasalos a world space y nuevamente asignalos
        velocity = transform.transform.TransformDirection(velocity);
        _controller.Move(velocity * Time.deltaTime);
        Debug.Log("Calculando");
    }

    public void RestLife(float injury)
    {
        playerLife = playerLife - injury;
        if(playerLife<=0)
        {
         GameManager.Instance.GameOver();
        }
    }



    public void EnableWeapons()
    {
        if(weaponActive == false)
        {
            Debug.Log("Cambia a arma");
            _weapon.SetActive(true);
            _knife.SetActive(false);
            knifeActive = false;
            weaponActive = true;
            
        }
                   
    }

    public void EnableKnife()
    {
        if (knifeActive == false)
        {
            Debug.Log("Cambia a cuchillo");
            _knife.SetActive(true);
            _weapon.SetActive(false);
            knifeActive = true;
            weaponActive = false;
        }

    }

    public void AddHealth(float heal)
    {
        playerLife = playerLife + heal;
        if (playerLife > 100)
        {
            playerLife = 100f;
        }
    }

    public void LessHealth(float heal)
    {
        playerLife = playerLife - heal;
        if (playerLife <= 0)
        {
            SceneManager.LoadScene(2);
            Debug.Log("GAME OVER");
        }
    }

    public void RemoveHealth(float heal)
    {
        //playerLife = playerLife - heal
        //timeToDie = timeToDie + timeToDie * Time.deltaTime;
        timeToDie += Time.deltaTime;
        if (timeToDie >= 5.0f)
        {
            playerLife = playerLife - heal;
            timeToDie = 0.0f;
            Debug.Log("Time to die: " + timeToDie);
        }
        if (playerLife <= 0)
        {
            SceneManager.LoadScene(4);
            Debug.Log("GAME OVER");
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void GrenadeActivate()
    {
        playerLife = 100;
        StartCoroutine(InvincibleTimeUp());
    }

    IEnumerator InvincibleTimeUp()
    {
        yield return new WaitForSeconds(30.0f);
        Debug.Log("Listo Calisto");
        inmunity = false;
        yield return new WaitForSeconds(.1f);
    }

    public void SpeedPotionActivate()
    {
        _speed = 5.5f;
        StartCoroutine(SpeedPotionTimeUp());
    }

    IEnumerator SpeedPotionTimeUp()
    {
        yield return new WaitForSeconds(20.0f);
        Debug.Log("Al tok mi rey");
        speed = false;
        _speed = 3.5f;
        yield return new WaitForSeconds(.1f);
    }

    public void AddCollectable(float collectable)
    {
        currentCollectables = currentCollectables + collectable;
        if (currentCollectables == 12)
        {
            SceneManager.LoadScene(5);
            Debug.Log("Ganaste");
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
