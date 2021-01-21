using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Drawing.Imaging;
using System.Reflection;

namespace Fortranaly90
{
    public partial class Tree : Form
    {
        int program90num = 0; //程序数，又即程序的序号  
        string mainprogram90 = "";//主程序名
        string program90 = "";//当前程序名，用于统一暂存主程序名和模块名
        int mainprogram90num = 0;//主程序名数
        string module90 = "";//模块名
        string USE90 = "";//存储所有使用的模块名，各文件以####隔开，注意是全部文件的模块,也可以用DataTable
        int module90num = 0;//模块数
        string USE90_Temp; //暂存used module90名
        string program90_Temp;//暂存program90名
        string Graphvizcode_temp = "";//暂存Graphvizcode
        string function90 = "";//存储所有使用的function和subroutine，各文件以####隔开，注意是全部文件的模块,也可以用DataTable
        string variable90 = "";//存储所有使用定义的variable，各文件以####隔开，注意是全部文件的模块,也可以用DataTable
        string funsubroutine90 = "";
        string callfun90 = "";
        string received_address; //用于从Fortranaly传递参数
        List<string> mList = new List<string>();  //List用于存所有程序名
        int f90num = 0;//当前文件夹下程序数
        ////picturebox 
        private Point mouseDownPoint = new Point(); //记录拖拽过程鼠标位置
        private bool isMove = false;    //判断鼠标在picturebox上移动时，是否处于拖拽过程(鼠标左键是否按下)
        ////#
        public Tree()
        {
            InitializeComponent();
        }
        public Tree(string text)
        {
            InitializeComponent();
            this.received_address = text;
        }
        protected void linklabel_click(object sender, EventArgs e)//module的linklabel
        {
            LinkLabel linklbl = (LinkLabel)sender;//获取动态LinkLabel的sender名,这句很有用可以动态的获取动态按钮的入口
            //EventArgs继承自MouseEventArgs,所以可以强转
            MouseEventArgs Mouse_e = (MouseEventArgs)e;
            //点鼠标左键,return
            if (Mouse_e.Button == MouseButtons.Left)
            {
                int beginIndex = USE90.IndexOf(linklbl.Text + "####");
                int endIndex = USE90.IndexOf("####" + linklbl.Text);
                string strCut = USE90.Substring(beginIndex, endIndex - beginIndex - 1).Replace(linklbl.Text + "####", string.Empty);//beginIndex-1是因为会多出一个回车符
                textBox_USE_Modules.Text = strCut.TrimStart('\r').TrimStart('\n');
                textBox_Graphvizcode.Text = Graphvizcode(linklbl.Text, textBox_USE_Modules.Text);//调用Graphvizcode，生成Graphvizcode
                save_Text(received_address, textBox_Graphvizcode.Text.Replace("\r\r", string.Empty), linklbl.Text);//调用save_Text，将Graphvizcode存到linklbl.Text.dot
                CMD(received_address, "C:\\ProgramData\\chocolatey\\bin\\dot -Tpng " + linklbl.Text + ".dot -o " + linklbl.Text + ".png");//调用CMD 使用graphviz生成脑图
                this.pictureBox_Graphviz.Load(received_address + "\\" + linklbl.Text + ".png");//读取图片显示
                USE90_Temp = textBox_USE_Modules.Text; //暂存USE_Modules供全局调用，用于下一步生成总脑图
                program90_Temp = linklbl.Text; //暂存名字供全局调用，用于下一步生成总脑图
                //显示模块调用的函数
                int beginIndex_Func = function90.IndexOf("####" + linklbl.Text);
                int endIndex_Func = function90.Remove(beginIndex_Func, 1).IndexOf("####" + linklbl.Text) + 1;
                string strCut_Func = function90.Substring(beginIndex_Func, endIndex_Func - beginIndex_Func - 1).Replace("####" + linklbl.Text, string.Empty);//beginIndex-1是因为会多出一个回车符
                textBox_Func.Text = strCut_Func.TrimStart('\r').TrimStart('\n');
                //#
                //显示模块定义的变量
                int beginIndex_Var = variable90.IndexOf("####" + linklbl.Text);
                int endIndex_Var = variable90.Remove(beginIndex_Var, 1).IndexOf("####" + linklbl.Text) + 1;
                string strCut_Var = variable90.Substring(beginIndex_Var, endIndex_Var - beginIndex_Var - 1).Replace("####" + linklbl.Text, string.Empty);//beginIndex-1是因为会多出一个回车符
                textBox_Var.Text = strCut_Var.TrimStart('\r').TrimStart('\n');
            }
            //#
            if (Mouse_e.Button == MouseButtons.Right)
            {
                string fileNameFullPath = received_address + "\\" + linklbl.Text + ".f90";
                if (System.IO.File.Exists(fileNameFullPath))//寻找是否有这文件，有，则执行
                {
                    System.Diagnostics.Process.Start(fileNameFullPath);//用默认程序打开
                }
                else
                {
                    MessageBox.Show("The module name does not match the file name !");
                }
            }
        }
        protected void mainprogram90label_click(object sender, EventArgs e)//mainprogram的linklabel，跟上面linklabel_click差不多
        {
            //textBox3.Text = USE90.TrimStart('\r'); 读取所有USE module
            LinkLabel linklbl = (LinkLabel)sender;//获取动态LinkLabel的sender名
            //EventArgs继承自MouseEventArgs,所以可以强转
            MouseEventArgs Mouse_e = (MouseEventArgs)e;
            //点鼠标左键,return
            if (Mouse_e.Button == MouseButtons.Left)
            {
                int beginIndex = USE90.IndexOf(linklbl.Text + "####");
                int endIndex = USE90.IndexOf("####" + linklbl.Text);
                string strCut = USE90.Substring(beginIndex, endIndex - beginIndex - 1).Replace(linklbl.Text + "####", string.Empty);
                textBox_USE_Modules.Text = strCut.TrimStart('\r').TrimStart('\n');
                textBox_Graphvizcode.Text = Graphvizcode(linklbl.Text, textBox_USE_Modules.Text);//调用Graphvizcode，生成Graphvizcode
                save_Text(received_address, textBox_Graphvizcode.Text.Replace("\r\r", string.Empty), linklbl.Text);//调用save_Text，将Graphvizcode存到linklbl.Text.dot
                CMD(received_address, "C:\\ProgramData\\chocolatey\\bin\\dot -Tpng " + linklbl.Text + ".dot -o " + linklbl.Text + ".png");//调用CMD 使用graphviz生成脑图
                this.pictureBox_Graphviz.Load(received_address + "\\" + linklbl.Text + ".png");
                USE90_Temp = textBox_USE_Modules.Text;
                program90_Temp = linklbl.Text;
                //显示模块的函数
                int beginIndex_Func = function90.IndexOf("####" + linklbl.Text);
                int endIndex_Func = function90.Remove(beginIndex_Func, 1).IndexOf("####" + linklbl.Text) + 1;
                string strCut_Func = function90.Substring(beginIndex_Func, endIndex_Func - beginIndex_Func - 1).Replace("####" + linklbl.Text, string.Empty);//beginIndex-1是因为会多出一个回车符
                textBox_Func.Text = strCut_Func.TrimStart('\r').TrimStart('\n');
                //#
                //显示模块定义的变量
                int beginIndex_Var = variable90.IndexOf("####" + linklbl.Text);
                int endIndex_Var = variable90.Remove(beginIndex_Var, 1).IndexOf("####" + linklbl.Text) + 1;
                string strCut_Var = variable90.Substring(beginIndex_Var, endIndex_Var - beginIndex_Var - 1).Replace("####" + linklbl.Text, string.Empty);//beginIndex-1是因为会多出一个回车符
                textBox_Var.Text = strCut_Var.TrimStart('\r').TrimStart('\n');
                //#
            }
            if (Mouse_e.Button == MouseButtons.Right)
            {
                string fileNameFullPath = received_address + "\\" + linklbl.Text + ".f90";
                if (System.IO.File.Exists(fileNameFullPath))//寻找是否有这文件，有，则执行
                {
                    System.Diagnostics.Process.Start(fileNameFullPath);//用默认程序打开
                }
                else
                {
                    MessageBox.Show("The module name does not match the file name !");
                }
            }
        }
        //General Network btn
        private void btn_Network_Click(object sender, EventArgs e)//生成总脑图
        {
            Graphvizcode_temp = Graphvizcode_temp + Graphvizcode_general(program90_Temp, USE90_Temp);//调用Graphvizcode_general，生成分块Graphvizcode
            string[] use_NameList = USE90_Temp.Split('\n');//将USE90_Temp中的模块分成一个个，后面foreach将对每个模块名再次提取他本身所调用的模块名
            int beginIndex = 0;
            int endIndex = 0;
            foreach (var item in use_NameList)
            {
                string item_name = item.TrimEnd('\n').TrimEnd('\r');
                beginIndex = USE90.IndexOf(item_name + "####");
                endIndex = USE90.IndexOf("####" + item_name);
                if (beginIndex < 0) { continue; }//对于调用有些系统模块USE90中是找不到的，故为“-1”，需要跳出循环
                string strCut = USE90.Substring(beginIndex, endIndex - beginIndex - 1).Replace(item_name + "####", string.Empty);
                strCut = strCut.TrimStart('\r').TrimStart('\n');
                Graphvizcode_temp = Graphvizcode_temp + Graphvizcode_general(item, strCut);//调用Graphvizcode_general，生成并合并分块Graphvizcode
            }
            textBox_Graphvizcode.Text = Graphvizcode_merge(Graphvizcode_temp); //添加前后语句，生成Graphvizcode
            save_Text(received_address, textBox_Graphvizcode.Text.Replace("\r\r", string.Empty), "General_" + program90_Temp);//调用save_Text，将Graphvizcode存到General_linklbl.Text.dot
            CMD(received_address, "C:\\ProgramData\\chocolatey\\bin\\dot -Tpng " + "General_" + program90_Temp + ".dot -o " + "General_" + program90_Temp + ".png");//调用CMD 使用graphviz生成脑图General_program90_Temp.png
            this.pictureBox_Graphviz.Load(received_address + "\\" + "General_" + program90_Temp + ".png");
        }
        //#
        private void GraphvizLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(this.GraphvizLink.Text);      //打开网页
        }
        //生成Graphviz code
        public string Graphvizcode(string str1, string str2)//用于第一级脑图
        {
            string output_Array = "digraph G {";
            string[] nameList = str2.Split('\n');
            foreach (var item in nameList)
            {
                output_Array = output_Array + "\r\n" + "\"" + str1 + "\"->\"" + item + "\"";
            }
            output_Array = output_Array + "\r\n" + "}";
            return output_Array;
        }
        public string Graphvizcode_general(string str1, string str2)//用于总（general network）脑图循环调用，跟Graphvizcode也差不多
        {
            string output_Array = "";
            string[] nameList = str2.Split('\n');
            foreach (var item in nameList)
            {
                output_Array = output_Array + "\r\n" + "\"" + str1 + "\"->\"" + item + "\"";
            }
            return output_Array;
        }
        public string Graphvizcode_merge(string str1)//用于总（general network）脑图循环调用,加剩余语句
        {
            string output_Array = "digraph G {" + "\r\n" + str1 + "\r\n" + "}";
            return output_Array;
        }
        //#
        //调用CMD （已经封装好）str1是dot文件路径,str2是命令
        private string CMD(string str1, string str2)
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;    //是否使用操作系统shell启动
            p.StartInfo.RedirectStandardInput = true;//接受来自调用程序的输入信息
            p.StartInfo.RedirectStandardOutput = true;//由调用程序获取输出信息
            p.StartInfo.RedirectStandardError = true;//重定向标准错误输出
            p.StartInfo.CreateNoWindow = true;//不显示程序窗口

            p.Start();//启动程序

            //向cmd窗口发送输入信息
            p.StandardInput.WriteLine(str1.Substring(0, 2));//先到相应盘符
            p.StandardInput.WriteLine("cd " + str1);
            p.StandardInput.WriteLine(str2);
            p.StandardInput.AutoFlush = true;
            p.StandardInput.WriteLine("exit");
            //向标准输入写入要执行的命令。这里使用&是批处理命令的符号，表示前面一个命令不管是否执行成功都执行后面(exit)命令，如果不执行exit命令，后面调用ReadToEnd()方法会假死
            //同类的符号还有&&和||前者表示必须前一个命令执行成功才会执行后面的命令，后者表示必须前一个命令执行失败才会执行后面的命令

            //获取cmd窗口的输出信息
            string output = p.StandardOutput.ReadToEnd();

            //StreamReader reader = p.StandardOutput;
            //string line=reader.ReadLine();
            //while (!reader.EndOfStream)
            //{
            //    str += line + "  ";
            //    line = reader.ReadLine();
            //}

            p.WaitForExit();//等待程序执行完退出进程
            p.Close();
            return output;
        }
        //#
        //保存文本文件
        private void save_Text(string adress_Output, string str, string file_Name)
        {
            string adress_Merged = adress_Output + "\\" + file_Name + ".dot";
            StreamWriter sw = File.AppendText(@adress_Merged); //保存到指定路径
            sw.Write(str);
            sw.Flush();
            sw.Close();
        }
        //#
        //pictureBox平移放大缩小（封装好，使用方法：1，加入panel1,2 写入上面的pictureBox变量 3. copy下面的函数，4.panel和pictureBox_Graphviz添加相应的事件，pictureBox1_MouseWheel事件在Form1.Designer.cs的“Windows 窗体设计器生成的代码”里加入 ）https://www.jb51.net/article/147868.htm
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseDownPoint.X = Cursor.Position.X; //记录鼠标左键按下时位置
                mouseDownPoint.Y = Cursor.Position.Y;
                isMove = true;
                pictureBox_Graphviz.Focus(); //鼠标滚轮事件(缩放时)需要picturebox有焦点
            }
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMove = false;
            }
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox_Graphviz.Focus(); //鼠标在picturebox上时才有焦点，此时可以缩放
            if (isMove)
            {
                int x, y;   //新的pictureBox1.Location(x,y)
                int moveX, moveY; //X方向，Y方向移动大小。
                moveX = Cursor.Position.X - mouseDownPoint.X;
                moveY = Cursor.Position.Y - mouseDownPoint.Y;
                x = pictureBox_Graphviz.Location.X + moveX;
                y = pictureBox_Graphviz.Location.Y + moveY;
                pictureBox_Graphviz.Location = new Point(x, y);
                mouseDownPoint.X = Cursor.Position.X;
                mouseDownPoint.Y = Cursor.Position.Y;
            }
        }
        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseDownPoint.X = Cursor.Position.X; //记录鼠标左键按下时位置
                mouseDownPoint.Y = Cursor.Position.Y;
                isMove = true;
            }
        }
        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMove = false;
            }
        }
        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            panel1.Focus(); //鼠标不在picturebox上时焦点给别的控件，此时无法缩放   
            if (isMove)
            {
                int x, y;   //新的pictureBox1.Location(x,y)
                int moveX, moveY; //X方向，Y方向移动大小。
                moveX = Cursor.Position.X - mouseDownPoint.X;
                moveY = Cursor.Position.Y - mouseDownPoint.Y;
                x = pictureBox_Graphviz.Location.X + moveX;
                y = pictureBox_Graphviz.Location.Y + moveY;
                pictureBox_Graphviz.Location = new Point(x, y);
                mouseDownPoint.X = Cursor.Position.X;
                mouseDownPoint.Y = Cursor.Position.Y;
            }
        }
        //实现锚点缩放(以鼠标所指位置为中心缩放)；
        //步骤：
        //①先改picturebox长宽，长宽改变量一样；
        //②获取缩放后picturebox中实际显示图像的长宽，这里长宽是不一样的；
        //③将picturebox的长宽设置为显示图像的长宽；
        //④补偿picturebox因缩放产生的位移，实现锚点缩放。
        // 注释：为啥要②③步？由于zoom模式的机制，把picturebox背景设为黑就知道为啥了。
        //这里需要获取zoom模式下picturebox所显示图像的大小信息，添加 using System.Reflection；
        //pictureBox1_MouseWheel事件没找到。。。手动添加，别忘在Form1.Designer.cs的“Windows 窗体设计器生成的代码”里加入：  
        //this.pictureBox1.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseWheel)。
        private void pictureBox1_MouseWheel(object sender, MouseEventArgs e)
        {
            int x = e.Location.X;
            int y = e.Location.Y;
            int ow = pictureBox_Graphviz.Width;
            int oh = pictureBox_Graphviz.Height;
            int VX, VY;  //因缩放产生的位移矢量
            if (e.Delta > 0) //放大
            {
                //第①步
                pictureBox_Graphviz.Width += 50;
                pictureBox_Graphviz.Height += 50;
                //第②步
                PropertyInfo pInfo = pictureBox_Graphviz.GetType().GetProperty("ImageRectangle", BindingFlags.Instance |
                 BindingFlags.NonPublic);
                Rectangle rect = (Rectangle)pInfo.GetValue(pictureBox_Graphviz, null);
                //第③步
                pictureBox_Graphviz.Width = rect.Width;
                pictureBox_Graphviz.Height = rect.Height;
            }
            if (e.Delta < 0) //缩小
            {
                //防止一直缩成负值
                if (pictureBox_Graphviz.Width < 500)
                    return;

                pictureBox_Graphviz.Width -= 20;
                pictureBox_Graphviz.Height -= 20;
                PropertyInfo pInfo = pictureBox_Graphviz.GetType().GetProperty("ImageRectangle", BindingFlags.Instance |
                 BindingFlags.NonPublic);
                Rectangle rect = (Rectangle)pInfo.GetValue(pictureBox_Graphviz, null);
                pictureBox_Graphviz.Width = rect.Width;
                pictureBox_Graphviz.Height = rect.Height;
            }
            //第④步，求因缩放产生的位移，进行补偿，实现锚点缩放的效果
            VX = (int)((double)x * (ow - pictureBox_Graphviz.Width) / ow);
            VY = (int)((double)y * (oh - pictureBox_Graphviz.Height) / oh);
            pictureBox_Graphviz.Location = new Point(pictureBox_Graphviz.Location.X + VX, pictureBox_Graphviz.Location.Y + VY);
        }
        //# pictureBox平移放大缩小（封装好)
        private void btn_Copy_Click(object sender, EventArgs e)
        {
            string copy_Text = textBox_Graphvizcode.Text.Replace("\r\r", string.Empty);//"\r\r"按\n分割时残留的
            Clipboard.SetDataObject(copy_Text);//复制
        }
        private void btn_find_function_query_Click(object sender, EventArgs e)
        {
            if (textBox_findfunc.Text != string.Empty)
            {
                if (function90.IndexOf("\n" + textBox_findfunc.Text + "\r") >= 0)
                {
                    int beginIndex = function90.IndexOf(textBox_findfunc.Text);
                    string function90_temp1 = function90.Remove(0, beginIndex);
                    int startIndex_temp = function90_temp1.IndexOf("####");
                    string function90_temp2 = function90_temp1.Remove(0, startIndex_temp);
                    int endIndex_temp = function90_temp2.IndexOf("\r\n####");
                    MessageBox.Show("Result: in " + function90_temp2.Substring(0, endIndex_temp).Replace("####", ""));
                }
                else { MessageBox.Show("Selected path doesn't contain this function"); }
            }
        }
        private void btn_findvar_Click(object sender, EventArgs e)
        {
            if (textBox_findvar.Text != string.Empty)
            {
                string findvar_temp = "";
                string variable90_temp = variable90;//variable90_temp用来暂放variable90，并每次执行while前重置
                while (variable90_temp.IndexOf("\n" + textBox_findvar.Text + "\r") >= 0)//写"\n" +...+ "\r"主要为了防止比如说字母是被包含在变量名内的，所以也会被找到
                {
                    int beginIndex = variable90_temp.IndexOf("\n" + textBox_findvar.Text + "\r");
                    string variable90_temp1 = variable90_temp.Remove(0, beginIndex);
                    int startIndex_temp = variable90_temp1.IndexOf("####");
                    string variable90_temp2 = variable90_temp1.Remove(0, startIndex_temp);
                    int endIndex_temp = variable90_temp2.IndexOf("\r\n####");
                    findvar_temp = findvar_temp + "\r\n" + "Result: in " + variable90_temp2.Substring(0, endIndex_temp).Replace("####", "");
                    variable90_temp = variable90_temp.Remove(0, beginIndex + textBox_findvar.Text.Length+1);
                    //textBox1.Text = variable90;
                }
                if (findvar_temp != "")
                {
                    Form f = new Form_result(string.Join("\r\n", (findvar_temp + "\r\n").Split('\n').Distinct()));//实体化一个Form类
                    f.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Selected path doesn't contain this var");
                }
            }
        }
        private void Tree_Load(object sender, EventArgs e)
        {
            int L_Height = 0;//放Labellink的位置
            int L_Width = 0;//放Labellink的位置
            //算法，检索该文件夹下所有f90文件，按一句一句reader.ReadLine()导入，开头是不是关键字（如“mmodule”）(这是为了防止读到其他地方，比如注释里面！。。。)
            DirectoryInfo dir = new DirectoryInfo(this.received_address);//下面几个为文件导入语句
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo info in files)
            {
                if (info.Extension.ToLower() == ".f90")
                {
                    string code_Name = "";
                    f90num = f90num + 1;
                    StreamReader reader = new StreamReader(info.FullName, Encoding.Default);
                    string fileContent = String.Empty;
                    string fileContent_temp = String.Empty;
                    while ((fileContent = reader.ReadLine()) != null)
                    {
                        fileContent = fileContent.Replace(" ", string.Empty);//去掉空格
                        fileContent = fileContent.Split('!')[0];
                        if (fileContent.Contains("&"))
                        {
                            fileContent_temp = fileContent_temp + fileContent.Replace("&", string.Empty);
                        }
                        else
                        {
                            fileContent = fileContent_temp + fileContent;
                            fileContent_temp = String.Empty;
                            if (fileContent.StartsWith("program"))
                            {
                                mainprogram90 = fileContent.Replace("program", string.Empty);
                                program90 = mainprogram90; //暂存程序名
                                mainprogram90num = mainprogram90num + 1;
                                LinkLabel mainprogram90label = new LinkLabel(); //生成LinkLabel
                                mainprogram90label.Text = mainprogram90;//mainprogram数加1
                                mainprogram90label.Click += new EventHandler(mainprogram90label_click);
                                panel_main.Controls.Add(mainprogram90label);//LinkLabel放到panel中
                                code_Name = info.Name;//info.Name是f90文件名
                                USE90 = USE90 + "\r\n" + fileContent.Replace("program", string.Empty) + "####";  //USE90中用来分割，program####;
                                function90 = function90 + "\r\n" + "####" + fileContent.Replace("program", string.Empty);//类似上面
                                variable90 = variable90 + "\r\n" + "####" + fileContent.Replace("program", string.Empty);//类似上面
                                program90num = program90num + 1;
                                mList.Add(module90);//List用于存所有程序名
                            }
                            else if (fileContent.StartsWith("module"))
                            {
                                module90 = fileContent.Replace("module", string.Empty);
                                program90 = module90;//暂存程序名
                                module90num = module90num + 1;//module数加1
                                LinkLabel module90label = new LinkLabel();//生成LinkLabel
                                module90label.Text = module90;
                                code_Name = info.Name;
                                USE90 = USE90 + "\r\n" + fileContent.Replace("module", string.Empty) + "####";
                                function90 = function90 + "\r\n" + "####" + fileContent.Replace("module", string.Empty);
                                variable90 = variable90 + "\r\n" + "####" + fileContent.Replace("module", string.Empty);
                                module90label.AutoSize = true;
                                //动态添加linklabel，以下为排列语句location位置确定语句，按module90label.Height依次向下排，超过panel的Height后,(L_Height < panel_module.Height),  L_Width += 200; L_Height = 0;
                                if (L_Height < panel_module.Height) //注意不严谨的地方是，没写L_Width< mainprogram90label.Width,panel_module较宽的话没问题
                                {
                                    module90label.Location = new Point(L_Width, L_Height);
                                    L_Height += module90label.Height;
                                }
                                else
                                {
                                    L_Width += 200;
                                    L_Height = 0;
                                    module90label.Location = new Point(L_Width, L_Height);
                                    L_Height += module90label.Height;
                                }
                                //#
                                module90label.Click += new EventHandler(linklabel_click);
                                panel_module.Controls.Add(module90label);
                                program90num = program90num + 1;
                                mList.Add(module90);
                            }
                            else if (fileContent.StartsWith("use"))
                            {
                                int cut_index = fileContent.IndexOf("only:");//去掉only:后的内容，只取模块名
                                if (cut_index > 0)
                                {
                                    USE90 = USE90 + "\r\n" + fileContent.Remove(cut_index).Replace("use", string.Empty);
                                }
                                else { USE90 = USE90 + "\r\n" + fileContent.Replace("use", string.Empty); }
                                //存储所有使用的模块名
                            }
                            else if (fileContent.StartsWith("endfunction"))
                            {
                                function90 = function90 + "\r\n" + fileContent.Replace("endfunction", string.Empty);//储存所有function
                            }
                            else if (fileContent.StartsWith("endsubroutine"))
                            {
                                function90 = function90 + "\r\n" + fileContent.Replace("endsubroutine", string.Empty);
                                
                            }

                            else if (fileContent.Contains("::"))
                            {
                                int signIndex=fileContent.IndexOf("::");
                                variable90 = variable90 + "\r\n" + fileContent.Remove(0, signIndex).Replace("::", string.Empty).Split('=')[0].Split('(')[0];
                            }
                           
                        }
                    }
                }
                USE90 = USE90 + "\r\n" + "####" + program90;
                function90 = function90 + "\r\n" + "####" + program90;
                variable90 = variable90 + "\r\n" + "####" + program90;
                variable90 = variable90.Replace(",", "\r\n");
                USE90 = string.Join("\r\n", USE90.Split('\n').Distinct());//去除重复的module
                USE90 = USE90.Replace(",", string.Empty);
            }
            function90 = function90 + "\r\n" + "####";//最后一个程序后面再多加一行####，后面检索时用到，由于USE90是存放模块的，而模块不用检索在哪个文件出（本身就是一个文件），故不用
            variable90 = variable90 + "\r\n" + "####";
            label_main.Text = "Mainprogram" + " (" + mainprogram90num.ToString() + ")";
            label_module.Text = "Module" + " (" + module90num.ToString() + ")";
            //textBox1.Text = variable90;
        }
    }
    //#
}

