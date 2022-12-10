using GJ4.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace GJ4.Battle
{
    public class PointerRenderer 
    {
        private Image _pointerImage;

        public void Enable() => _pointerImage.enabled = true;

        public void Disable() => _pointerImage.enabled = false;

        public void Load() => _pointerImage = Resources.Load<Image>($"{Constants.UI_PREFABS}/{nameof(PointerRenderer)}");

        public void UpdatePosition(Vector3 worldPosition) => _pointerImage.rectTransform.position = worldPosition;
    }
}
