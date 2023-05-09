using UnityEngine ;
using EasyUI.Popup ;

public class Demo_1 : MonoBehaviour {

   [TextArea (5, 20)]
    public string longText ;

   public void Button3 () {
      Popup.Show ("Error", "Invalid email or password!", "OK", PopupColor.Red) ;
   }

   public void Button4 () {
      Popup.Show ("Success", "Your account updated successfully.", "OK", PopupColor.Green) ;
   }
  
}
