    
using UnityEngine;

public static class CameraExtension
{
	public static void camera_scale_bigger(this Camera cam, float new_size, float speed)
	{
		cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, new_size, Time.deltaTime * speed);
	}

	public static void camera_follow(this Camera cam, Transform follow_target, float speed)
    {

    }
}