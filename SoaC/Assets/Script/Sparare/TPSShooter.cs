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
    float projectileForce = 100;

    LayerMask hittableMask;
    LayerMask mapMask;

    public GameObject Player;
    public PickUpController equipaggiato;
    public bool equiped;
    public GameObject marco;

    void Start()
    {
        // Player = Player;
        hittableMask = (1 << LayerMask.NameToLayer("Default"));
        mapMask = (1 << LayerMask.NameToLayer("Map")) | hittableMask;

        equiped = equipaggiato.equipped;

       
        
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

                if (Physics.Raycast(camTransform.position, camTransform.forward, out hit, distance, hittableMask, QueryTriggerInteraction.Ignore))
                {
                    projectileInstance.transform.LookAt(hit.point);

                    Rigidbody colRigidbody = hit.collider.gameObject.GetComponent<Rigidbody>();
                    if (!colRigidbody) { return; }
                    colRigidbody.isKinematic = false;
                    colRigidbody.AddForceAtPosition(camTransform.forward * projectileForce, hit.point, ForceMode.Impulse);
                    Debug.LogError("Hai colpito: " + hit.collider.gameObject);
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
