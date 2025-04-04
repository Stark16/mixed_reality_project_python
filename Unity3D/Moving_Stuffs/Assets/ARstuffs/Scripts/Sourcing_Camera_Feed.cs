using System;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

namespace UnityEngine.XR.ARExtensions
{

    public class Sourcing_Camera_Feed : MonoBehaviour
    {
        static WebCamTexture Cam;
        private Texture2D _texture;
        private TextureFormat _format = TextureFormat.RGBA32;
        private ARSessionOrigin arOrigin;
        public ARCameraManager CameraManager;

        //bool TryGetLatestImage(out XRCameraImage cameraImage)
        //{
            
        //}


        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

            //if (!TryGetLatestImage(out XRCameraImage cameraImage))
            //{

            //}

            if (Cam == null)
                Cam = new WebCamTexture();
            GetComponent<Renderer>().material.mainTexture = Cam;

            if (!Cam.isPlaying)
                Cam.Play();
        }
    }
}