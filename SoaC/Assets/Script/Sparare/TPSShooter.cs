using UnityEngine;
using System.Collections;

///<summary>
///
///</summary>

public class TPSShooter : MonoBehaviour
{

    [SerializeField]
    GameObject projectile;

    [SerializeField]
    Transform camTransform;

    [SerializeField]
    LineRenderer lineRenderer;

    [SerializeField]
    float distance = 100;

    [SerializeField]
    float projectileForce = 10;
    public float danno = 20;

    LayerMask hittableMask;
    LayerMask mapMask;
    private RaycastHit hit;

    public GameObject Player;
    public PickUpController equipaggiato;
    public bool equiped;
    public GameObject marco;
    AudioSource sparo;

    void Start()
    {
        // Player = Player;
        hittableMask = (1 << LayerMask.NameToLayer("Enemy"));
        mapMask = (1 << LayerMask.NameToLayer("Map")) | hittableMask;

        equiped = equipaggiato.equipped;

        sparo = GetComponent<AudioSource>();
        
    }
    void Update()
    {
        equiped = equipaggiato.equipped;
        if (equiped)
        {
            RaycastHit hit;
            if (Physics.Raycast(camTransform.position, camTransform.forward, out hit, distance, mapMask, QueryTriggerInteraction.Ignore))
                if (Physics.Raycast(camTransform.position, camTransform.forward, out hit, distance, mapMask, QueryTriggerInteraction.Ignore))
                {
                    lineRenderer.SetPosition(1, lineRenderer.transform.InverseTransformPoint(hit.point));
                }
            // if (Input.GetButtonDown(Sparo))
            if (marco.GetComponent<FixedTouchField>().Pressed)
            {
                GameObject projectileInstance = Instantiate(projectile, lineRenderer.transform.position, Quaternion.identity);
                sparo.Play();
                projectileInstance.GetComponent<AutoDestroy>().enabled = true;


                if (Physics.Raycast(camTransform.position, camTransform.forward, out hit, distance, hittableMask, QueryTriggerInteraction.Ignore))
                {
                    projectileInstance.transform.LookAt(hit.point);

                    Rigidbody colRigidbody = hit.collider.gameObject.GetComponent<Rigidbody>();
                    if (!colRigidbody) { return; }
                    colRigidbody.isKinematic = false;
                    colRigidbody.AddForceAtPosition(camTransform.forward * projectileForce, hit.point, ForceMode.Impulse);
                    //Debug.LogError("Hai colpito: " + hit.collider.gameObject);
                    if (hit.collider.tag == "Enemy")
                    {
                        hit.collider.GetComponent<DannoNemico>().getDanno(danno);   // mi dice che quando il collide tocca il tag nemico toglie 20 danni
                    }
                }

                else
                {
                    Vector3 lineRendererWorldEndPoint = lineRenderer.transform.TransformPoint(lineRenderer.GetPosition(1));
                    projectileInstance.transform.LookAt(lineRendererWorldEndPoint);
                }

                Rigidbody projectileBody = projectileInstance.GetComponent<Rigidbody>();
                projectileBody.AddForce(camTransform.forward * projectileForce, ForceMode.Impulse);
            }

        }
    }
}
