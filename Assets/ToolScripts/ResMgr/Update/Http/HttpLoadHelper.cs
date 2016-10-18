using UnityEngine;
using System.Collections;
using System;
namespace Update
{
    public class HttpLoadHelper : ILoadHelper
    {
        public UpdateEventHandler completeLoadHandler
        {
            get;
            set;
        }
        public DownFileVO FileVO
        {
            get;
            set;
        }
        public WWW WWWObj
        {
            get;
            set;
        }
        /// <summary>
        /// �Ƿ���Ҫ���غ�ֱ�ӱ���;
        /// </summary>
        public bool NeedSave
        {
            get;
            set;
        }
        private float _timeOut = 5;
        /// <summary>
        /// ��ʱ��λ��  Ĭ��Ϊ5��;
        /// </summary>
        public float TimeOut
        {
            get {
                return _timeOut;
            }
            set {
                _timeOut = value;
            }
        }
        public bool IsLocal
        {
            get;
            set;
        }
        /// <summary>
        /// ����ʧ�ܺ���ೢ�Դ�����
        /// </summary>
        public int MaxTryTimes = 3;
        protected int tryTimes = 0;
        protected float startTime;//��ʼ����ʱ��;
        public bool isStartDown = false;
        public HttpLoadHelper()
        {

        }
        public void StartLoad()
        {
            tryTimes++;
            isStartDown = true;
            startTime = Time.time;
            Headers headers = new Headers();
            headers.Add("Cache-control", "no-cache");
            headers.Add("Content-Type", "text/html; charset=utf-8");
           
            string path = string.Empty;
            if (IsLocal)
            {
                path = "file://" + FileVO.DownFilePath;
            }
            else
            {
                path = "http://" + FileVO.DownFilePath;
            }
            if (ResUpdateManager.Instance.updateModel.RunPlaformType != RunPlaformType.MAC)
            {
                path += "?" + RandomNum();
            }
            //WWWObj = new WWW(path, null, headers.GetHashtable());
        }
        public bool IsTimeOut() {
            bool result = false;
            float nowTime = Time.time;
            if ((nowTime - startTime > this._timeOut && isStartDown && this.WWWObj.progress <= 0))
            {
                result = true;
            }
            return result;
        }
        public bool NeedLoadAgain()
        {
            return tryTimes < MaxTryTimes;
        }
        #region ˽�з���;
        private string RandomNum() {
            System.Random random = new System.Random((int)DateTime.Now.Ticks);
            return  random.NextDouble().ToString();
        }
        #endregion
    }
}