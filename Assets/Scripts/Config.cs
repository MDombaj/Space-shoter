using UnityEngine;


public static class playerConfig{

    public static float startXPosition=0f;
    public static float startYPosition=0f;
    public static float startZPosition=0f;
    public static float speed=6.5f;
}
public static class laseConfig{
    // Variables:
    public static float speed = 10.0f;
    public static float fireRate = 0.2f;
    public static Vector3 offsetSpawn = new Vector3(0f, 0.8f, 0f);
    public static float distanceLimit = 11f;
}
public static class enemyConfig{

    public static float speed= 4.0f;
}