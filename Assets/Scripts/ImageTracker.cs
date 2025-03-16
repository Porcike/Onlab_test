using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ImageTracker : MonoBehaviour
{
    private ARTrackedImageManager manager;
    private MutableRuntimeReferenceImageLibrary referenceLibrary;

    void OnEnable()
    {
        ARSession.stateChanged += OnARSessionStateChanged;
    }

    void OnDisable()
    {
        ARSession.stateChanged -= OnARSessionStateChanged;
    } 

    void Start()
    {
        manager = GetComponent<ARTrackedImageManager>();

        referenceLibrary = manager
            .CreateRuntimeLibrary(manager.referenceLibrary as XRReferenceImageLibrary) 
                as MutableRuntimeReferenceImageLibrary;

        //Debug.Log("The size of the Reference Image Library: " + referenceLibrary.count);
    }

    void OnARSessionStateChanged(ARSessionStateChangedEventArgs args)
    {
        if(referenceLibrary.count == 0 && (args.state == ARSessionState.Ready || args.state == ARSessionState.SessionTracking))
        {
            Debug.Log("The size of the Reference Image Library: " + referenceLibrary.count);
            referenceLibrary.ScheduleAddImageWithValidationJob(manager.referenceLibrary[0].texture , "image", 0.5f);
            Debug.Log("The size of the Reference Image Library: " + referenceLibrary.count);
            manager.referenceLibrary = referenceLibrary;
            Debug.Log("The size of the Reference Image Library: " + manager.referenceLibrary.count);
        }
    }

    public void AddImage(Texture2D texture)
    {
        referenceLibrary.ScheduleAddImageWithValidationJob(texture, "image", 0.5f);
    }
}
