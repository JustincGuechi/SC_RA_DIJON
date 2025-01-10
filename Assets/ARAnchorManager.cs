using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class AnchorManager : MonoBehaviour
{
    [SerializeField]
    public GameObject anchorPrefab;

    private ARRaycastManager raycastManager;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private void Awake()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Ended)
            {
                Vector2 touchPosition = touch.position;

                if (raycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
                {
                    Pose hitPose = hits[0].pose;

                    // Créer une ancre à l'emplacement touché
                    var anchor = new GameObject("ARAnchor");
                    anchor.transform.position = hitPose.position;
                    anchor.transform.rotation = hitPose.rotation;

                    // Instancier le prefab à l'emplacement de l'ancre
                    var instantiatedPrefab = Instantiate(anchorPrefab, anchor.transform);

                    // Ajouter un bloc sur l'ancre
                    var block = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    block.transform.position = anchor.transform.position;
                    block.transform.rotation = anchor.transform.rotation;
                    block.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                    block.transform.parent = anchor.transform;
                }
            }
        }
    }
}
