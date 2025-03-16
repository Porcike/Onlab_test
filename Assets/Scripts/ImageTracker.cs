using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;

public class ImageTracker : MonoBehaviour
{
    private ARTrackedImageManager manager;
    private MutableRuntimeReferenceImageLibrary referenceLibrary;
    private List<Texture2D> textures;
    private int index;
    private bool arEnabled;

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
        manager.referenceLibrary = referenceLibrary;
        textures = GameObject.Find("ImageLoader").GetComponent<ImageLoader>().Textures;
        index = 0;
        arEnabled = false;

        Debug.Log("The size of the Reference Image Library: " + referenceLibrary.count);
    }

    void OnARSessionStateChanged(ARSessionStateChangedEventArgs args)
    {
        if((args.state == ARSessionState.Ready || args.state == ARSessionState.SessionTracking))
        {
            arEnabled = true;
        }
        else
        {
            arEnabled = false;;
        }
    }

    public void AddImage()
    {
        if(index != textures.Count && arEnabled)
        {
            var name = "image" + index.ToString();
            referenceLibrary.ScheduleAddImageWithValidationJob(textures[index], name, 0.5f);

            Debug.Log("The size of the Reference Image Library: " + referenceLibrary.count);
            Debug.Log("The size of the ARManager Reference Image Library: " + manager.referenceLibrary.count);

            index++;
        }
    }
}
