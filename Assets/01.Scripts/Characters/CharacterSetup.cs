using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;

namespace _01.Scripts.Characters
{
    public class CharacterSetup : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer Back;
        [SerializeField] private SpriteRenderer ClothBody;
        [SerializeField] private SpriteRenderer BodyArmor;
        [SerializeField] private SpriteRenderer Head;
        [SerializeField] private SpriteRenderer FaceHair;
        [SerializeField] private SpriteRenderer LeftArm;
        [SerializeField] private SpriteRenderer LeftShoulder;
        [SerializeField] private SpriteRenderer LeftWeapon;
        [SerializeField] private SpriteRenderer LeftShield;
        [SerializeField] private SpriteRenderer RightArm;
        [SerializeField] private SpriteRenderer RightShoulder;
        [SerializeField] private SpriteRenderer RightWeapon;
        [SerializeField] private SpriteRenderer RightShield;
        [SerializeField] private SpriteRenderer LeftPants;
        [SerializeField] private SpriteRenderer RightPants; 

        public CharacterSetup(
            [CanBeNull] SpriteRenderer back, 
            [CanBeNull] SpriteRenderer clothBody, 
            [CanBeNull] SpriteRenderer bodyArmor, 
            [CanBeNull] SpriteRenderer head, 
            [CanBeNull] SpriteRenderer faceHair, 
            [CanBeNull] SpriteRenderer leftArm, 
            [CanBeNull] SpriteRenderer leftShoulder, 
            [CanBeNull] SpriteRenderer leftWeapon, 
            [CanBeNull] SpriteRenderer leftShield, 
            [CanBeNull] SpriteRenderer rightArm, 
            [CanBeNull] SpriteRenderer rightShoulder, 
            [CanBeNull] SpriteRenderer rightWeapon, 
            [CanBeNull] SpriteRenderer rightShield, 
            [CanBeNull] SpriteRenderer leftPants, 
            [CanBeNull] SpriteRenderer rightPants)
        {
            Back = back;
            ClothBody = clothBody;
            BodyArmor = bodyArmor;
            Head = head;
            FaceHair = faceHair;
            LeftArm = leftArm;
            LeftShoulder = leftShoulder;
            LeftWeapon = leftWeapon;
            LeftShield = leftShield;
            RightArm = rightArm;
            RightShoulder = rightShoulder;
            RightWeapon = rightWeapon;
            RightShield = rightShield;
            LeftPants = leftPants;
            RightPants = rightPants;
        }
    }
}