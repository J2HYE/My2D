using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace My2D
{
    //플레이어 이동 따른 시차효과 거리 구하기
    public class ParallaxEffect : MonoBehaviour
    {
        #region Variables
        public Camera camera;           //카메라
        public Transform followTarget;  //플레이어

        //시작 위치
        private Vector2 startingPosition;   //시작 위치(배경, 카메라)
        private float startingZ;            //시작할 때 배경의 z축 위치값

        //시작지점으로부터 카메라 위치까지의 거리
        private Vector2 CamMoveSinceStart => startingPosition - (Vector2)camera.transform.position;

        //
        private float zDistanceFromTarget => transform.position.z - followTarget.position.z;
        //
        private float CllipingPlane => camera.transform.position.z + (zDistanceFromTarget > 0 ? camera.farClipPlane : camera.nearClipPlane);

        private float ParallaxFactor => Mathf.Abs(zDistanceFromTarget) / CllipingPlane;
        #endregion

        private void Start()
        {
            //초기화
            startingPosition = transform.position;
            startingZ = transform.localPosition.z;
        }

        private void Update()
        {
            Vector2 newPosition = startingPosition + CamMoveSinceStart * ParallaxFactor; //+ B;
            transform.position = new Vector3(newPosition.x, newPosition.y, startingZ);
        }
    }
}
