using _01.Scripts.Managers;
using _01.Scripts.UI.Base;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace _01.Scripts.UI.SubItem
{
    public class StoreItem : UIBase
    {
        private enum Texts
        {
            ItemName,
            ItemDesc,
            StatusText,
            PriceText
        }

        private enum Images
        {
            ItemImage,
            StatusIcon,
            PriceIcon
        }

        private enum Buttons
        {
            BuyBtn
        }

        private void Start()
        {
            Initialized();
        }

        protected override bool Initialized()
        {
            if (!base.Initialized()) return false;

            BindButton(typeof(Buttons));
            BindImage(typeof(Images));
            BindText(typeof(Texts));

            GetButton((int)Buttons.BuyBtn).gameObject.BindEvent(BuyItem);
            return true;
        }

        private void BuyItem(PointerEventData obj)
        {
            // 인벤토리로 보내기
        }
    }
}