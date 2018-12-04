﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Configuration;
using System.Windows.Forms;


namespace Map_Form {
    class SensorAction {
        //インスタンスの固定
        public Map_Form mfObj;

        //コンストラクタ
        public SensorAction(Map_Form mf_obj) {
            mfObj = mf_obj;
        }

        //カメラプリセット情報を読み込み、マップ上のどのカメラアイコンを
        //変更させるかを判断する処理
        public void CameraJudgment(int snNum) {
            //ここにカメラアイコンの色を変化させる処理を追加
            using (FileStream fs = new FileStream(ConfigurationManager.AppSettings["CameraPresetPath"],
                FileMode.Open, FileAccess.Read, FileShare.ReadWrite)) {
                using (StreamReader stream = new StreamReader(fs)) {
                    while (!stream.EndOfStream) {
                        string[] values = stream.ReadLine().Split(',');
                        if (values[0] == snNum.ToString()) {
                            CameraColorChange(values[1]);
                            CameraColorChange(values[2]);
                            CameraColorChange(values[3]);
                        }
                    }
                }
            }
        }
        
        //実際にカメラアイコンの色を変更させる処理
        public void CameraColorChange(string str) {
            mfObj.Invoke((MethodInvoker)delegate {
                switch (str) {
                    case "1":
                        mfObj.Camera_01.Image = Properties.Resources.Camera_Action;
                        break;
                    case "2":
                        mfObj.Camera_02.Image = Properties.Resources.Camera_Action;
                        break;
                    case "3":
                        mfObj.Camera_03.Image = Properties.Resources.Camera_Action;
                        break;
                    case "4":
                        mfObj.Camera_04.Image = Properties.Resources.Camera_Action;
                        break;
                    case "5":
                        mfObj.Camera_05.Image = Properties.Resources.Camera_Action;
                        break;
                    case "6":
                        mfObj.Camera_06.Image = Properties.Resources.Camera_Action;
                        break;
                    case "7":
                        mfObj.Camera_07.Image = Properties.Resources.Camera_Action;
                        break;
                    case "8":
                        mfObj.Camera_08.Image = Properties.Resources.Camera_Action;
                        break;
                }
            });
        }

        //カメラアイコンの色をもとに戻す処理
        public void CameraReturn() {
            mfObj.Invoke((MethodInvoker)delegate {
                mfObj.Camera_01.Image = Properties.Resources.Camera_Normal;
                mfObj.Camera_02.Image = Properties.Resources.Camera_Normal;
                mfObj.Camera_03.Image = Properties.Resources.Camera_Normal;
                mfObj.Camera_04.Image = Properties.Resources.Camera_Normal;
                mfObj.Camera_05.Image = Properties.Resources.Camera_Normal;
                mfObj.Camera_06.Image = Properties.Resources.Camera_Normal;
                mfObj.Camera_07.Image = Properties.Resources.Camera_Normal;
                mfObj.Camera_08.Image = Properties.Resources.Camera_Normal;
            });
        }
    }
}
