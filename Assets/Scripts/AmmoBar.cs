using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBar : MonoBehaviour
{
    public Texture2D ammoBackground;
	public Texture2D ammoForeground;
	public Texture2D ammoDamage;
	public GUIStyle HUDSkin;

    private float previousAmmo;
    private float ammoBarWidth;
	private float myFloat;
	public static float curAmmo;
	public static float maxAmmo; 

    void Start()
    {
        curAmmo = 30;
		maxAmmo = 30;
		ammoBarWidth = 100f;
		myFloat = (maxAmmo / 100) * 10;
    }

    public void setAmmo( float ammo ){
        curAmmo = ammo;
    }

    // Update is called once per frame
    void Update()
    {
        adjustCurrentAmmo();
    }

    public void adjustCurrentAmmo(){
							
		
		if(previousAmmo > curAmmo){
			previousAmmo -= ((maxAmmo / curAmmo) * (myFloat)) * Time.deltaTime; // deducts health damage
		} else {
			previousAmmo = curAmmo;	
		}
		
		if(previousAmmo < 0){
			previousAmmo = 0;	
		}
		
		if(curAmmo > maxAmmo){
			curAmmo = maxAmmo;
			previousAmmo = maxAmmo;
		}
		
		if(curAmmo< 0){
			curAmmo = 0;
		}
	}

    void OnGUI () {
		int posX = Screen.width - 260;
		float posY = Screen.height - 25;
		int height = 15;
				
		float previousAdjustValue = (previousAmmo * ammoBarWidth) / maxAmmo;
		float percentage = ammoBarWidth * (curAmmo/maxAmmo);
				
		GUI.DrawTexture (new Rect (posX, posY, (ammoBarWidth * 2), height), ammoBackground);		
		
		GUI.DrawTexture (new Rect (posX, posY, (previousAdjustValue * 2), height), ammoDamage);
		
		GUI.DrawTexture (new Rect (posX, posY, (percentage * 2), height), ammoForeground);
		
		HUDSkin = new GUIStyle();
		
		if(curAmmo == maxAmmo){
			HUDSkin.normal.textColor = Color.green;
			HUDSkin.fontStyle = FontStyle.BoldAndItalic;
			HUDSkin.fontSize = 16;
			GUI.Label(new Rect(posX + 210, posY, 100, 50), (int)(previousAmmo) + "/" + maxAmmo.ToString(), HUDSkin);
			
		} else if(curAmmo < maxAmmo){
			
			if(percentage <= 50 && percentage >= 25){
				HUDSkin.normal.textColor = Color.yellow;
				HUDSkin.fontStyle = FontStyle.BoldAndItalic;
				HUDSkin.fontSize = 16;
				GUI.Label( new Rect(posX + 210, posY, 100, 50), (int)(previousAmmo) + "/" + maxAmmo.ToString(), HUDSkin);

			} else if (percentage < 25){
				HUDSkin.normal.textColor = Color.red;
				HUDSkin.fontStyle = FontStyle.BoldAndItalic;
				HUDSkin.fontSize = 16;
				GUI.Label(new Rect(posX + 210, posY, 100, 50), (int)(previousAmmo) + "/" + maxAmmo.ToString(), HUDSkin);
			
			} else {
				HUDSkin.normal.textColor = Color.green;
				HUDSkin.fontStyle = FontStyle.BoldAndItalic;
				HUDSkin.fontSize = 16;
				GUI.Label(new Rect(posX + 210, posY, 100, 50), (int)(previousAmmo) + "/" + maxAmmo.ToString(), HUDSkin);
			} 	
		}
	}
}
