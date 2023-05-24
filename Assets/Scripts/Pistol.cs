using UnityEngine;

public class Pistol : MonoBehaviour
{

    // variabili per caratteristiche della pistola
    public float damage = 10f;
    public float range = 100f;

    // punto dal quale escono i proiettili
    public Transform muzzle;
    public Camera fpsCamera;
    private AudioSource pistolAudio;

    public ParticleSystem muzzleFlash;
    public GameObject impactEffectNoZombies, impactEffectZombies;

    void Start(){

        pistolAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update(){

        // azione di sparo
        if(Input.GetButtonDown("Fire1")){
            Shoot();
        }
    }

    void Shoot(){

        muzzleFlash.Play();
        pistolAudio.Play();

        // memorizza l'informazione su cosa ho colpito
        RaycastHit hitInfo;

        // si spara dalla posizione della camera, nella direzione della camera, vengono prese le informazioni necessarie, definito il range
        // il metodo ritorna un booleano, se si è colpito qualcosa o meno
        if(Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hitInfo, range)){
            
            Debug.Log(hitInfo.transform.name);

            var hitBox = hitInfo.transform.GetComponent<ZWHitBox>();
            if(hitBox){
                hitBox.OnRaycastHit(this);
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
}
