using UnityEngine;
using System.Collections;

public class Gyroscope2 : MonoBehaviour {
     private float initialYAngle = 0f;
     private float appliedGyroYAngle = 0f;
     private float calibrationYAngle = 0f;
 
     private Camera myCamera;
 
     [SerializeField]
     internal GameObject[] allCubes;
 
     private void Start()
     {
         #if UNITY_ANDROID
         Input.gyro.enabled = true;
         #endif
 
         Application.targetFrameRate = 60;
         initialYAngle = transform.eulerAngles.y;
         CalibrateYAngle ();
     }
 
     private void OnEnable()
     {
         if(myCamera == null)
         {    myCamera = this.GetComponent<Camera> ();}    
     }
 
 
     private void OnDisable()
     {}
 
     void Update()
     {
         ApplyGyroRotation();
         ApplyCalibration();
     }
 
     bool cubeHit = false;
     private void FixedUpdate()
     {
         
         RaycastHit _raycastHit = new RaycastHit(); // create new raycast hit info object
 
         // "vrdetection" layer = 8
         if(Physics.Raycast (this.transform.position, transform.forward, out _raycastHit, Mathf.Infinity, 1 << 8))
         { 
             _raycastHit.transform.GetComponent<Renderer> ().material.color = Color.red;    
             cubeHit = true;
         } 
         else
         {
             if(cubeHit == true)
             {
                 foreach (GameObject _go in allCubes)
                 {
                     _go.GetComponent<Renderer> ().material.color = Color.white;
                 }
                 cubeHit = false;
             }
         }
 
     }
 
     public void CalibrateYAngle()
     {
         calibrationYAngle = appliedGyroYAngle - initialYAngle; // Offsets the y angle in case it wasn't 0 at edit time.
     }
 
     void ApplyGyroRotation()
     {
         this.transform.rotation = Input.gyro.attitude;
         appliedGyroYAngle = this.transform.eulerAngles.y; // Save the angle around y axis for use in calibration.
 
         #if UNITY_ANDROID
 
         this.transform.Rotate( 0f, 0f, 180f, Space.Self ); //Swap "handedness" ofquaternionfromgyro.
         this.transform.Rotate( 270f, 180f, 180f, Space.World ); //Rotatetomakesenseasacamerapointingoutthebackofyourdevice.
 
         #else
 
         this.transform.Rotate ( 0f, 0f, 180f, Space.Self ); //Swap "handedness" ofquaternionfromgyro.
         this.transform.Rotate ( 90f, 180f, 0f, Space.World ); //Rotatetomakesenseasacamerapointingoutthebackofyourdevice.
 
         #endif
     }
 
     void ApplyCalibration()
     {
         transform.Rotate( 0f, -calibrationYAngle, 0f, Space.World ); // Rotates y angle back however much it deviated when calibrationYAngle was saved.
     }
 }