using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChange : MonoBehaviour
{
    public Material newBuildingMaterial;
    public Material newRoofMaterial;
    public Material newFrameMaterial;
    public Material newHeaderMaterial;
    public Material newExtraMaterial;
    public MeshRenderer appliedBuildingMaterialRenderer;
    public MeshRenderer appliedRoofMaterialRenderer;
    public MeshRenderer appliedExtraMaterialRenderer;
    public List<MeshRenderer> appliedFrameMaterialRenderer;
    public List<MeshRenderer> appliedHeaderRenderer;
    public int numWindowsToBreak;

    public void break_window()
    {
        print("i have been told to break ze window");
        numWindowsToBreak--;
        print(numWindowsToBreak);
        if(numWindowsToBreak == 0){
            prestochango();
        } 
    }

    public void prestochango()
    {
        // Change material
        print("yas bitch");
        appliedBuildingMaterialRenderer.material = newBuildingMaterial;
        appliedRoofMaterialRenderer.material = newRoofMaterial;
        appliedExtraMaterialRenderer.material = newExtraMaterial;
        foreach (MeshRenderer renderer in appliedFrameMaterialRenderer){
            renderer.material = newFrameMaterial;
            //print(newFrameMaterial);
        }
        foreach (MeshRenderer renderer in appliedHeaderRenderer){
            renderer.material = newHeaderMaterial;
            //print(newHeaderMaterial);
        }
    }
}
