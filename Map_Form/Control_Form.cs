﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Map_Form {
    public partial class Control_Form:Form {

        //インスタンス固定
        public static Map_Form map_form = new Map_Form();
        public static Camera_Form camera_form = new Camera_Form();

        public Control_Form() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            //マップフォーム起動
            map_form.Show();
            //カメラフォーム起動
            camera_form.Show();
            //ファイル監視実行
            File_Watcher fw = new File_Watcher(map_form);
            fw.StartWatching();
        }

        private void Form1_Activated(object sender, EventArgs e) {
            //このフォームを非表示
            this.Hide();
        }

        //マップからカメラへ画面遷移する
        public void Camera_Show() {
            map_form.Hide();
            camera_form.Show();
        }

        //カメラからマップへ画面遷移する
        public void Map_Show() {
            camera_form.Hide();
            map_form.Show();
        }
    }
}