using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace Upan
{
    public partial class Form1 : Form
    {


        DriveInfo Tdriver = null;
        public Form1()
        {
            InitializeComponent();
        }

        Thread thread = null;
        public const int WM_DEVICECHANGE = 0x219;
        public const int DBT_DEVICEARRIVAL = 0x8000;
        public const int DBT_DEVICEREMOVECOMPLETE = 0x8004;
        string drivestr; //驱动器名称
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_DEVICECHANGE)
            {
                switch (m.WParam.ToInt32())
                {
                    case WM_DEVICECHANGE:
                        break;
                    case DBT_DEVICEARRIVAL:
                        {
                            thread = null;
                            MessageBox.Show("U盘插入....","信息",MessageBoxButtons.OK,MessageBoxIcon.Information);
                            DriveInfo[] s = DriveInfo.GetDrives();
                            foreach (DriveInfo drive in s)
                            {
                                if (drive.DriveType == DriveType.Removable)
                                {
                                    drivestr = drive.Name;
                                    thread = new Thread(new ThreadStart(Copy));//线程实例化
                                    thread.Start();//启动线程
                                }
                            }
                            break;
                        }
                    case DBT_DEVICEREMOVECOMPLETE:
                        {
                            MessageBox.Show("U盘拔出....","信息",MessageBoxButtons.OK,MessageBoxIcon.Information);
                            thread = null;
                            break;
                        }
                }
            }
            base.WndProc(ref m);

        }

        string des = "";      //拷贝来的文件的存放位置
        private void button_Search_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog1.ShowDialog();
            textBox_Des.Text = folderBrowserDialog1.SelectedPath;
            des = textBox_Des.Text;
        }

        private void button_Hide_Click(object sender, EventArgs e)
        {
            if (des != "")
                this.Hide();  //后台运行程序
            else
                MessageBox.Show("请选择文件存放位置....", "信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        public void Copy()  //线程函数
        {
            CopyFile(drivestr, (int)numericUpDown_FileSize.Value);
        }
        public void CopyFile(string path, int filesize)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            foreach (FileInfo FI in dir.GetFiles())
            {
                if (FI.Length <= filesize * 1024 * 1024)
                    try { File.Copy(FI.FullName, des + @"\" + FI.Name); }
                    catch (IOException) { continue; }
            }

            foreach (DirectoryInfo DI in dir.GetDirectories())
            {
                CopyFile(DI.FullName, filesize);
            }

        }

    


    ////protected override void WndProc(ref Message m)
    //{
    //    if (m.Msg == 0x0219)//WM_DEVICECHANGE
    //    {
    //        switch (m.WParam.ToInt32())
    //        {
    //            case 0x8000://DBT_DEVICEARRIVAL
    //                {
    //                    MessageBox.Show("设备插入");
    //                    string[] dirs = Environment.GetLogicalDrives(); //取得所有的盘符 
    //                    foreach (string dir in dirs)
    //                    {
    //                        Tdriver = new DriveInfo(dir);
    //                        if (Tdriver.DriveType == DriveType.Removable)
    //                        {
    //                            {
    //                                while (Tdriver.IsReady == false)
    //                                {
    //                                    Thread.Sleep(500);
    //                                }
    //                                try
    //                                {
    //                                    string PSTR = "";
    //                                    PSTR += "磁盘名称：" + Tdriver.Name + "\r\n";
    //                                    PSTR += "磁盘卷标：" + Tdriver.VolumeLabel + "\r\n";
    //                                    PSTR += "文件系统：" + Tdriver.DriveFormat + "\r\n";
    //                                    PSTR += "剩余大小：" + Tdriver.AvailableFreeSpace.ToString() + "\r\n";
    //                                    PSTR += "总体容量：" + Tdriver.TotalSize.ToString() + "\r\n";
    //                                    PSTR += "总体容量：" + Tdriver.RootDirectory.ToString() + "\r\n";
    //                                    MessageBox.Show(PSTR);
    //                                }
    //                                catch
    //                                {
    //                                    MessageBox.Show("error");
    //                                }
    //                            }
    //                        }
    //                    }
    //                    break;
    //                }
    //            case 0x8004://DBT_DEVICEREMOVECOMPLETE
    //                {
    //                    MessageBox.Show("设备拔出");
    //                    break;
    //                }
    //        }
    //    }
    //    base.WndProc(ref m);
    //}
    //private void AddToTreeView(TreeNode node)
    //{
    //    treeView1.Nodes.Add(node);
    //    treeView1.Refresh();
    //}
    //internal void LoadFolderFileList(string path, TreeNode nodes)
    //{
    //    string[] dirs = Directory.GetDirectories(path);
    //    string[] files = Directory.GetFiles(path);
    //    for (int i = 0; i < dirs.Length; i++)
    //    {
    //        string[] info = new string[4];
    //        DirectoryInfo di = new DirectoryInfo(dirs[i]);
    //        TreeNode node = new TreeNode(di.Name);
    //        node.Tag = di.FullName;
    //        try
    //        {
    //            if (di.GetDirectories().Length > 0 || di.GetFiles().Length > 0)
    //            {
    //                LoadFolderFileList(di.FullName, node);
    //            }
    //            else
    //            {
    //                continue;
    //            }
    //        }
    //        catch
    //        {
    //            continue;
    //        }
    //        nodes.Nodes.Add(node);
    //    }
    //    for (int i = 0; i < files.Length; i++)
    //    {
    //        FileInfo fi = new FileInfo(files[i]);
    //        TreeNode node = new TreeNode(fi.Name);
    //        node.Tag = fi.FullName;
    //        nodes.Nodes.Add(node);
    //    }
    //}
    private void button1_Click(object sender, EventArgs e)
        {
            //if (Tdriver != null)
            //{
            //    TreeNode node = new TreeNode();
            //    LoadFolderFileList(Tdriver.RootDirectory.ToString(), node);
            //    treeView1.Nodes.Add(node);
            //    treeView1.ExpandAll();
            //}
        }
    }
}

