using UnityEngine;

public class Pistol : MonoBehaviour
{

    // variabili per caratteristiche della pistola
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 4f;
    public int magazine = 12;
    public int currentBullets = 12;
    public int maxAmmo = 240;
    public int currentAmmo = 120;

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

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update(){

        time += Time.deltaTime;

        float nextTimeToShoot = 1 / fireRate;

        // azione di sparo
        if(time >= nextTimeToShoot && Input.GetButtonDown("Fire1") && currentBullets > 0){
            Shoot();
            time = 0.0f;
        }

        //azione di ricarica
        if(Input.GetKeyDown(KeyCode.R) && currentBullets < magazine && currentAmmo > 0){
            Reload();

            // dopo che si preme il tasto "ricarica", bisogna aspettare che sia finita la ricarica prima di sparare ancora
            time = -2.0f;
        }
    }

    void Shoot(){

        // contatore proiettili sparati
        if(currentBullets != 0){
            currentBullets --;
        }
        animator.SetTrigger("isShooting");

        muzzleFlash.Play();
        shootingSound.Play();

        // memorizza l'informazione su cosa ho colpito
        RaycastHit hitInfo;

        // si spara dalla posizione della camera, nella direzione della camera, vengono prese le informazioni necessarie, definito il range
        // il metodo ritorna un booleano, se si è colpito qualcosa o meno
        if(Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hitInfo, range)){
            
            Debug.Log(hitInfo.transform.name);

            var hitBox = hitInfo.transform.GetComponent<ZWHitBox>();
            if(hitBox){
                hitBox.OnRaycastHitP(this);
            }

            // effetto di impatto del proiettile
            if(hitInfo.transform.tag == "ZombieHitbox"){
                
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
}
