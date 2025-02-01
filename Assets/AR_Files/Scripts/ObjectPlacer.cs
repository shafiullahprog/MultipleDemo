using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ObjectPlacer : MonoBehaviour
{
    [SerializeField] private GameObject placementIndicator;
    [SerializeField] GameObject placedPrefab;
    GameObject spawnedObject;
    ARRaycastManager aRRaycastManager;
    List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private void Awake()
    {
        aRRaycastManager = GetComponent<ARRaycastManager>();
        placementIndicator.SetActive(false);
    }
    public InputAction touchInput;

    private void Start()
    {
        touchInput.performed += _ => PlaceObject();
    }

    private void OnEnable()
    {
        touchInput.Enable();
    }

    private void OnDisable()
    {
        touchInput.Disable();
    }
    private void Update()
    {
        PlacementIndicatorController();
    }

    private void PlacementIndicatorController()
    {
        if (aRRaycastManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.PlaneWithinPolygon))
        {
            var hitPose = hits[0].pose;
            placementIndicator.transform.SetPositionAndRotation(hitPose.position, hitPose.rotation);
            if (!placementIndicator.activeInHierarchy)
                placementIndicator.SetActive(true);
        }
        else
        {
            placementIndicator.SetActive(false);
        }
    }

    void PlaceObject()
    {
        if (!placementIndicator.activeInHierarchy)
            return;

        if (spawnedObject == null)
        {
            spawnedObject = Instantiate(placedPrefab, placementIndicator.transform.position, placementIndicator.transform.rotation);
        }
        else
        {
            spawnedObject.transform.SetPositionAndRotation(placementIndicator.transform.position, placementIndicator.transform.rotation);
        }
    }
}
    