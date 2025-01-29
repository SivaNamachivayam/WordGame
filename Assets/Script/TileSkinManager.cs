using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileSkinManager : MonoBehaviour
{
    [System.Serializable]
    public class LetterTileSkin
    {
        //public string skinName;       // Name of the skin (e.g., "Skin1")
        public Sprite skinImage;      // Sprite for the skin
    }

    public List<LetterTileSkin> letterTileSkins; // List of available skins
    public GameObject skinItemPrefab;           // Prefab for a skin item
    public Transform skinItemParent;            // Parent transform for skin items
    public GameObject letterTilePreview;             // Preview image for the selected skin

    private int selectedSkinIndex = 0;          // Currently selected skin index
    private const string SelectedSkinKey = "SelectedLetterTileSkin"; // Key for saving skin data

    private void Start()
    {
        // Load the saved skin index or use the default (0)
        selectedSkinIndex = PlayerPrefs.GetInt(SelectedSkinKey, 0);

        // Apply the saved skin to the preview
        ApplySkin(selectedSkinIndex);

        // Populate the skin shop
        PopulateSkins();
    }

    private void PopulateSkins()
    {
        // Clear existing skin items
        foreach (Transform child in skinItemParent)
        {
            Destroy(child.gameObject);
        }

        // Populate skin items dynamically
        for (int i = 0; i < letterTileSkins.Count; i++)
        {
            GameObject skinItem = Instantiate(skinItemPrefab, skinItemParent);

            // Ensure the prefab is valid
            if (skinItem == null)
            {
                Debug.LogError("Skin item prefab is null!");
                continue;
            }

            // Set the skin image
            Image skinImage = skinItem.transform.GetChild(0).GetComponent<Image>();
            if (skinImage != null)
            {
                skinImage.sprite = letterTileSkins[i].skinImage;
               // OnlyData.Instance._letterTailSpriteData = letterTileSkins[i].skinImage;
            }
            else
            {
                Debug.LogError("Prefab is missing an Image component.");
                continue;
            }

            // Set up the button for selecting the skin
            Button selectButton = skinItem.transform.GetChild(1).GetComponent<Button>();
            if (selectButton != null)
            {
                int index = i; // Capture the index for the button click
                selectButton.onClick.AddListener(() => SelectSkin(index));
            }
            else
            {
                Debug.LogError("Prefab is missing a Button component.");
            }
        }
    }

    private void SelectSkin(int index)
    {
        if (index < 0 || index >= letterTileSkins.Count)
        {
            Debug.LogError("Invalid skin index selected!");
            return;
        }

        // Update the selected skin index
        selectedSkinIndex = index;
        //OnlyData.Instance._letterTailData = selectedSkinIndex;

        // Apply the selected skin
        ApplySkin(selectedSkinIndex);

        // Save the selected skin
        PlayerPrefs.SetInt(SelectedSkinKey, selectedSkinIndex);
        PlayerPrefs.Save();
    }

    private void ApplySkin(int index)
    {
        if (index < 0 || index >= letterTileSkins.Count)
        {
            Debug.LogError("Invalid skin index for application!");
            return;
        }

        if (letterTilePreview != null)
        {
            // Check if letterTilePreview has a SpriteRenderer (used for 2D objects)
            if (letterTilePreview.TryGetComponent<SpriteRenderer>(out SpriteRenderer spriteRenderer))
            {
                spriteRenderer.sprite = letterTileSkins[index].skinImage;
            }
            // Check if letterTilePreview has an Image component (used for UI elements)
            else if (letterTilePreview.TryGetComponent<UnityEngine.UI.Image>(out UnityEngine.UI.Image imageComponent))
            {
                imageComponent.sprite = letterTileSkins[index].skinImage;
            }
            else
            {
                Debug.LogError("letterTilePreview GameObject does not have a SpriteRenderer or Image component!");
            }
        }
        else
        {
            Debug.LogError("letterTilePreview GameObject is not assigned in the Inspector!");
        }

        //Debug.Log($"Applied skin: {letterTileSkins[index].skinName}");
    }
}