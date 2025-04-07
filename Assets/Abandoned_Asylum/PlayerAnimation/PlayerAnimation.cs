using UnityEngine;

namespace EvolveGames
{
    public class PlayerAnimation : MonoBehaviour
    {
        public Animator animator;
        public PlayerController playerController;

        void Start()
        {
            // Если animator или playerController не были установлены в инспекторе,
            // попытаемся найти их автоматически
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

            // Определение состояния анимации для движения
            bool isWalking = playerController.Moving && !playerController.isRunning;
            bool isRunning = playerController.Moving && playerController.isRunning;

            // Устанавливаем параметры аниматора в зависимости от состояния движения
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

            // Проверяем, нажата ли клавиша "A" для передвижения влево
            bool isStrafeLeft = Input.GetKey(KeyCode.A);
            Debug.Log("IsStrafeLeft: " + isStrafeLeft);

            // Устанавливаем параметр анимации IsStrafeLeft
            animator.SetBool("IsStrafeLeft", isStrafeLeft);
        }
    }
}