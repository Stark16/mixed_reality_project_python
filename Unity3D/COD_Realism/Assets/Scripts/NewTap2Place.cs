using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;



[RequireComponent(typeof(ARRaycastManager))]
public class NewTap2Place : MonoBehaviour
{

    private ARRaycastManager raycastManager;

    private static Vector2 touchPosition;

    [SerializeField]
    private GameObject placementIndicatorPrefab;


    [SerializeField]
    private GameObject Soldier;

    private GameObject spawnedObject = null;

    public static bool playMode;
    public static bool objectinScene;

    private List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();
 
    void Awake()
    {
        raycastManager = GetComponent<ARRaycastManager>();
        playMode = false;
        //ManipulateButton.SetActive(false);
        //manipulationMode_Active = false;
        placementIndicatorPrefab.SetActive(false);
        objectinScene = false;
    }

    void FixedUpdate()
    {

        if (playMode == true)
                updatePose();
        else
            return;

    }

    // In this function, we are checking if the user has just started the game, and if yes, then user can spawn the model
    // based on where the placement indicator tells it to
    private void updatePose()
    {

        Debug.Log("In-Game Mode");
        if (spawnedObject == null)
        {
            Debug.Log("Object not spawned");
            var spawnPoint = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
            Debug.Log(spawnPoint);
            if (raycastManager.Raycast(spawnPoint, s_Hits, TrackableType.PlaneWithinPolygon))
            {
                var placementPose = s_Hits[0].pose;
                placementIndicatorPrefab.SetActive(true);
                placementIndicatorPrefab.transform.position = placementPose.position;
                placementIndicatorPrefab.transform.rotation = placementPose.rotation;

                if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    spawnedObject = Instantiate(Soldier, placementPose.position + new Vector3(0, 0.1f, 0), placementPose.rotation);
                    //Instantiate(Cube, placementPose.position + new Vector3(0.1f, 0.1f, 0), placementPose.rotation);
                    objectinScene = true;
                }

            }

            else
            {
                placementIndicatorPrefab.SetActive(false);
            }
        }
         if(spawnedObject != null)
        {
            placementIndicatorPrefab.SetActive(false);
        }

    }
}
