using UnityEngine;

public class Pistol : MonoBehaviour
{

    // variabili per caratteristiche della pistola
    [SerializeField] private float damage = 25f;
    [SerializeField] private float range = 100f;
    [SerializeField] private float fireRate = 4f;
    [SerializeField] public int magazine = 12;
    [SerializeField] public int currentBullets = 12;
    [SerializeField] public int maxAmmo = 240;
    [SerializeField] public int currentAmmo = 120;
    [SerializeField] private float spread = 0.01f;

    // punto dal quale escono i proiettili
    public Transform muzzle;
    public Camera fpsCamera;

    private AudioSource[] pistolSounds;
    private AudioSource reloadSound;
    private AudioSource shootingSound;
    private Animator animator;
    private float time;
    

    public ParticleSystem muzzleFlash;
    public GameObject impactEffectNoZombies, impactEffectZombies;

    void Start(){

        pistolSounds = GetComponents<AudioSource>();
        shootingSound = pistolSounds[0];
        reloadSound = pistolSounds[1];

        // quando starta il gioco disattivo i suoni delle armi, altrimenti si attiverebbero
        shootingSound.enabled = false;
        reloadSound.enabled = false;

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update(){

        if(!PauseMenu.isGamePaused){

            time += Time.deltaTime;

            float nextTimeToShoot = 1 / fireRate;

            // azione di sparo
            if(time >= nextTimeToShoot && (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.JoystickButton5)) && currentBullets > 0){
                Shoot();
                time = 0.0f;
            }

            //azione di ricarica
            if((Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.JoystickButton4)) && currentBullets < magazine && currentAmmo > 0){
                Reload();

                // dopo che si preme il tasto "ricarica", bisogna aspettare che sia finita la ricarica prima di sparare ancora
                time = -2.0f;
            }
        }
    }

    void Shoot(){

        // contatore proiettili sparati
        if(currentBullets != 0){
            currentBullets --;
        }
        animator.SetTrigger("isShooting");

        muzzleFlash.Play();

        shootingSound.enabled = true;
        shootingSound.Play();

        // memorizza l'informazione su cosa ho colpito
        RaycastHit hitInfo;

        Vector3 shootDirection = fpsCamera.transform.forward;
        shootDirection.x += Random.Range(-spread, spread);
        shootDirection.y += Random.Range(-spread, spread);
        shootDirection.z += Random.Range(-spread, spread);

        // si spara dalla posizione della camera, nella direzione della camera, vengono prese le informazioni necessarie, definito il range
        // il metodo ritorna un booleano, se si è colpito qualcosa o meno
        if(Physics.Raycast(fpsCamera.transform.position, shootDirection, out hitInfo, range)){

            var hitBoxZW = hitInfo.transform.GetComponent<ZWHitBox>();
            var hitBoxZR = hitInfo.transform.GetComponent<ZRHitBox>();
            var hitBoxZT = hitInfo.transform.GetComponent<ZTHitBox>();
            var hitBoxBoss = hitInfo.transform.GetComponent<BossHitBox>();


            if (hitBoxZW){
                hitBoxZW.OnRaycastHitP(this);
            }

            if(hitBoxZR){
                hitBoxZR.OnRaycastHitP(this);
            }

            if(hitBoxZT){
                hitBoxZT.OnRaycastHitP(this);
            }

            if (hitBoxBoss)
            {
                hitBoxBoss.OnRaycastHitP(this);
            }


            // effetto di impatto del proiettile
            if (hitInfo.transform.tag == "ZombieHitbox"){
                
                GameObject impactedBullet = Instantiate(impactEffectZombies, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
                // distruggo i proiettili impattati
                Destroy(impactedBullet, 0.1f);

            }else{
                
                GameObject impactedBullet = Instantiate(impactEffectNoZombies, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
                // distruggo i proiettili impattati
                Destroy(impactedBullet, 0.1f);
                
            }
        }
    }

    void Reload(){

        // suono della ricarica
        reloadSound.enabled = true;
        reloadSound.Play();

        // triggera animazione
        animator.SetTrigger("RPressed");

        if(currentAmmo < magazine){

            currentAmmo = currentAmmo - (magazine - currentBullets);
            currentBullets = currentBullets + (magazine - currentBullets);
        }
        else{

            currentAmmo = currentAmmo - ( magazine - currentBullets);
            currentBullets = currentBullets + (magazine - currentBullets);
        }
    }

    public float GetDamageValue(){ return damage;}
}
