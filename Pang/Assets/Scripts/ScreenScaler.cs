using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenScaler : MonoBehaviour
{
    public Camera cam;
    //public Image backgroundImage;


    void Start()
    {
        ScaleBackground();
    }

    public void ScaleBackground()
    {
        Vector2 ScreenSize = new Vector2(Screen.width, Screen.height);

        float ScreenWidth = Screen.width;
        float ScreenHeight = Screen.height;
        float ScreenAspect = ScreenWidth / ScreenHeight;
        cam.aspect = ScreenAspect;

        float CamHeight = 100.0f * cam.orthographicSize * 2.0f;
        float CamWidth = CamHeight * ScreenAspect;

        //SpriteRenderer Image = backgroundImage.GetComponent<SpriteRenderer>();
        //float BcImgW = Image.sprite.rect.width;
        //float BcImgH = Image.sprite.rect.height;

        //float backgroundImageRatioH = CamHeight / BcImgH;
        //float backgroundImageRatioW = CamWidth / BcImgW;

        //backgroundImage.transform.localScale = new Vector3(backgroundImageRatioW, backgroundImageRatioH, 1);
    }
}
