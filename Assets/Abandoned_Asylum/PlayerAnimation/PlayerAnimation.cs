using UnityEngine;

namespace EvolveGames
{
    public class PlayerAnimation : MonoBehaviour
    {
        public Animator animator;
        public PlayerController playerController;

        void Start()
        {
            // ���� animator ��� playerController �� ���� ����������� � ����������,
            // ���������� ����� �� �������������
            if (animator == null)
            {
                animator = GetComponent<Animator>();
            }

            if (playerController == null)
            {
                playerController = GetComponent<PlayerController>();
            }
        }

        void Update()
        {
            UpdateMovementAnimation();
            UpdateStrafeLeftAnimation();
        }

        void UpdateMovementAnimation()
        {
            if (animator == null || playerController == null)
            {
                Debug.LogError("Animator or PlayerController is not assigned!");
                return;
            }

            // ����������� ��������� �������� ��� ��������
            bool isWalking = playerController.Moving && !playerController.isRunning;
            bool isRunning = playerController.Moving && playerController.isRunning;

            // ������������� ��������� ��������� � ����������� �� ��������� ��������
            animator.SetBool("IsWalking", isWalking);
            animator.SetBool("IsRunning", isRunning);
        }

        void UpdateStrafeLeftAnimation()
        {
            if (animator == null || playerController == null)
            {
                Debug.LogError("Animator or PlayerController is not assigned!");
                return;
            }

            // ���������, ������ �� ������� "A" ��� ������������ �����
            bool isStrafeLeft = Input.GetKey(KeyCode.A);
            Debug.Log("IsStrafeLeft: " + isStrafeLeft);

            // ������������� �������� �������� IsStrafeLeft
            animator.SetBool("IsStrafeLeft", isStrafeLeft);
        }
    }
}