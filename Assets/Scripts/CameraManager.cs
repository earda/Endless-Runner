using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : Singleton<CameraManager>
{
    //shakeBegin
    public float power = 0.7f;
    public float duration = 1.0f;
    private new Transform camera;
    public float smoothing = 1.0f;
    public bool isShake = false; 
    Vector3 startPosition;
    float firstDuration; 
    //shakeEnd
    
    [SerializeField] Transform player;
    public Vector3 offset;
    private void Start()
    {
        offset = transform.position - player.position;

        camera = Camera.main.transform;
        startPosition = camera.localPosition;
        firstDuration = duration;
    } 
    private void Update()
    {
        CameraFollower();
        CameraShake(); 
    }
    private void CameraFollower()
    {
        Vector3 targetPos = player.position + offset;
        targetPos.x = 0;
        transform.position = targetPos;
    }
    private void CameraShake()
    {
        if (isShake)
        {
          if (duration > 0)
            {
                camera.localPosition = camera.localPosition + Random.insideUnitSphere * power;
                duration -= (Time.deltaTime * smoothing);
            }
            else
            {
                isShake = false;
                duration = firstDuration;
                camera.localPosition = startPosition;
            }
        } 
    }
    public void FinalCameraScene()
    {
        offset = new Vector3(camera.localRotation.x, camera.localRotation.y, camera.localRotation.z+10f*Time.deltaTime);
      //  offset = new Vector3(camera.localRotation.x,camera.localRotation.y+180f*Time.deltaTime,camera.localRotation.z);
        
    }
}
