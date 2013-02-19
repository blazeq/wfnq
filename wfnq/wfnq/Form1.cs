using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;
//using DevComponents.DotNetBar;
using System.Collections;

namespace wfnq
{
    public partial class Form1 : Form//Office2007Form//Form
    {
        Hashtable Ht_idToName = new Hashtable();
        Hashtable Ht_nameToId = new Hashtable();
        public Form1()
        {
            InitializeComponent();
            idToName();
            nameToId();
        }
        /// <summary>
        /// 站点id对应站点名称返回哈希表
        /// </summary>
        private void idToName()
        {
            Ht_idToName.Add("N0001", "三元朱");
            Ht_idToName.Add("N0002", "口埠");
            Ht_idToName.Add("N0003", "黄楼");
            Ht_idToName.Add("N0004", "古城");
            Ht_idToName.Add("N0005", "高柳");
        }
        private void nameToId()
        {
            Ht_nameToId.Add("三元朱", "N0001");
            Ht_nameToId.Add("口埠", "N0002");
            Ht_nameToId.Add("黄楼", "N0003");
            Ht_nameToId.Add("古城", "N0004");
            Ht_nameToId.Add("高柳", "N0005");
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            uu();
            groupPanelSelect1();
            
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            string[] array = { "三元朱", "口埠", "黄楼", "古城", "高柳" };
            comboBoxEx1.DataSource = array;
            
            dateTimeInput1.Value = DateTime.Parse(DateTime.Now.ToShortDateString());
            
            DateTime dt = dateTimeInput1.Value;
            string stationid = Ht_nameToId[comboBoxEx1.SelectedItem.ToString()].ToString();
            dddddd(stationid, dt);
            //textBoxX10.Text = dt.ToString();
            groupPanelSelect2();
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            groupPanelSelect3();
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            groupPanelSelect4();
        }


        private void groupPanelSelect1()
        {
            groupPanel1.Visible = true;
            groupPanel2.Visible = false;
            groupPanel3.Visible = false;
            groupPanel4.Visible = false;
            groupPanel5.Visible = false;
            groupPanel6.Visible = false;
            groupPanel7.Visible = false;
            groupPanel8.Visible = false;
            groupPanel9.Visible = false;
            groupPanel10.Visible = false;
            groupPanel11.Visible = false;
            timer_1_start();
        }
        private void groupPanelSelect2()
        {
            groupPanel2.Visible = true;
            groupPanel1.Visible = false;
            groupPanel3.Visible = false;
            groupPanel4.Visible = false;
            groupPanel5.Visible = false;
            groupPanel6.Visible = false;
            timer_1_stop();
        }
        private void groupPanelSelect3()
        {
            groupPanel3.Visible = true;
            groupPanel1.Visible = false;
            groupPanel2.Visible = false;
            groupPanel4.Visible = false;
            groupPanel5.Visible = false;
            groupPanel6.Visible = false;
            timer_1_stop();
        }
        private void groupPanelSelect4()
        {
            groupPanel4.Visible = true;
            groupPanel1.Visible = false;
            groupPanel2.Visible = false;
            groupPanel3.Visible = false;
            groupPanel5.Visible = false;
            groupPanel6.Visible = false;
            timer_1_stop();
        }
        private void groupPanelSelect5()
        {
            groupPanel5.Visible = true;
            groupPanel1.Visible = false;
            groupPanel2.Visible = false;
            groupPanel3.Visible = false;
            groupPanel4.Visible = false;
            groupPanel6.Visible = false;
            timer_1_stop();
        }
        private void groupPanelSelect6()
        {
            groupPanel6.Visible = true;
            groupPanel1.Visible = false;
            groupPanel2.Visible = false;
            groupPanel3.Visible = false;
            groupPanel4.Visible = false;
            groupPanel5.Visible = false;
            timer_1_stop();
        }


        private void groupPanelSelect11()
        {
            groupPanel11.Visible = true;
            groupPanel1.Visible = false;
            groupPanel2.Visible = false;
            groupPanel3.Visible = false;
            groupPanel4.Visible = false;
            groupPanel5.Visible = false;
            groupPanel6.Visible = false;
            groupPanel7.Visible = false;
            groupPanel8.Visible = false;
            groupPanel9.Visible = false;
            groupPanel10.Visible = false;
            timer_1_stop();
        }

        private void dddddd(string stationid,DateTime dt)
        {
            listView2.Items.Clear();
            //dateTimeInput1.Value = DateTime.Now;
            DateTime be_dt = DateTime.Parse(dt.ToShortDateString().ToString() + " 00:00:00");
            DateTime end_dt = DateTime.Parse(dt.ToShortDateString().ToString() + " 23:59:00"); ;
            //string stationID = stationID;
            string sqlHost = "127.0.0.1";
            //string sqlHost = "172.18.224.30";
            string sqlCatalog = "wfqxj";
            //string sqlCatalog = "GH_TIANJIN";
            string sqlName = "wfqxj";
            string sqlPass = "baoyu";
            textBoxX10.Text = be_dt.ToString();
            //Hashtable station_temp = new Hashtable();

            SqlConnection zdzh_con = new SqlConnection();
            zdzh_con.ConnectionString = "data source = " + sqlHost + "; initial catalog = " + sqlCatalog + "; User ID = " + sqlName + "; Password = " + sqlPass + ";";
            SqlCommand zdzh_command = new SqlCommand();
            //zdzh_command.CommandText = "SELECT top 1 * FROM stasync ORDER BY 日期时间 DESC";
            zdzh_command.CommandText = "SELECT * FROM GH_TIANJIN WHERE id = '" + stationid + "' AND time between '"+ be_dt +"' and '"+ end_dt +"' ORDER BY time DESC";
            //zdzh_command.CommandText = "SELECT top 1 * FROM tabtimedata WHERE id = 'N0001' ORDER BY time DESC";
            zdzh_command.Connection = zdzh_con;
            try
            {
                int num = 1;
                zdzh_command.Connection.Open();
                SqlDataReader zdzh_reader = zdzh_command.ExecuteReader();
                while (zdzh_reader.Read())
                {
                    string id = zdzh_reader["id"].ToString().Trim();
                    string time = zdzh_reader["time"].ToString();
                    string TA_CU = zdzh_reader["TA_CU"].ToString();
                    string TA_CD = zdzh_reader["TA_CD"].ToString();
                    string RH_C = zdzh_reader["RH_C"].ToString();
                    string TS_U = zdzh_reader["TS_U"].ToString();
                    string TS_M = zdzh_reader["TS_M"].ToString();
                    string TS_D = zdzh_reader["TS_D"].ToString();
                    string R_U = zdzh_reader["R_U"].ToString();
                    string PAR_U = zdzh_reader["PAR_U"].ToString();
                    string CO2_U = zdzh_reader["CO2_U"].ToString();

                    string[] staID = new string[13] { num.ToString(), id, Ht_idToName[id].ToString(), time, TA_CU, TA_CD, RH_C, TS_U, TS_M, TS_D, R_U, PAR_U, CO2_U, };
                    ListViewItem lvi = new ListViewItem(staID);
                    listView2.Items.Add(lvi);
                    num++;
                }
                zdzh_con.Close();
            }
            catch (Exception e1)
            {

            }
            finally
            {
                zdzh_con.Close();
            }
        }

        /// <summary>
        /// 返回站点数据，数据名称对应数据，返回哈希表
        /// </summary>
        /// <param name="stationID"></param>
        /// <returns></returns>
        public Hashtable ret_station_data(string stationID)
        {
            //string stationID = stationID;
            string sqlHost = "127.0.0.1";
            //string sqlHost = "172.18.224.30";
            string sqlCatalog = "wfqxj";
            //string sqlCatalog = "GH_TIANJIN";
            string sqlName = "wfqxj";
            string sqlPass = "baoyu";

            Hashtable station_element = new Hashtable();

            SqlConnection zdzh_con = new SqlConnection();
            zdzh_con.ConnectionString = "data source = " + sqlHost + "; initial catalog = " + sqlCatalog + "; User ID = " + sqlName + "; Password = " + sqlPass + ";";
            SqlCommand zdzh_command = new SqlCommand();
            //zdzh_command.CommandText = "SELECT top 1 * FROM stasync ORDER BY 日期时间 DESC";
            zdzh_command.CommandText = "SELECT top 1 * FROM GH_TIANJIN WHERE id = '" + stationID + "' ORDER BY time DESC";
            //zdzh_command.CommandText = "SELECT top 1 * FROM tabtimedata WHERE id = 'N0001' ORDER BY time DESC";
            zdzh_command.Connection = zdzh_con;
            try
            {
                zdzh_command.Connection.Open();
                SqlDataReader zdzh_reader = zdzh_command.ExecuteReader();
                while (zdzh_reader.Read())
                {
                    string id = zdzh_reader["id"].ToString();
                    string time = zdzh_reader["time"].ToString();
                    string TA_CU = zdzh_reader["TA_CU"].ToString();
                    string TA_CD = zdzh_reader["TA_CD"].ToString();
                    string RH_C = zdzh_reader["RH_C"].ToString();
                    string TS_U = zdzh_reader["TS_U"].ToString();
                    string TS_M = zdzh_reader["TS_M"].ToString();
                    string TS_D = zdzh_reader["TS_D"].ToString();
                    string R_U = zdzh_reader["R_U"].ToString();
                    string PAR_U = zdzh_reader["PAR_U"].ToString();
                    string CO2_U = zdzh_reader["CO2_U"].ToString();

                    station_element.Add("id", id);
                    station_element.Add("time", time);
                    station_element.Add("TA_CU", TA_CU);
                    station_element.Add("TA_CD", TA_CD);
                    station_element.Add("RH_C", RH_C);
                    station_element.Add("TS_U", TS_U);
                    station_element.Add("TS_M", TS_U);
                    station_element.Add("TS_D", TS_D);
                    station_element.Add("R_U", R_U);
                    station_element.Add("PAR_U", PAR_U);
                    station_element.Add("CO2_U", CO2_U);
                }
                zdzh_con.Close();
            }
            catch (Exception e)
            {

            }
            finally
            {
                zdzh_con.Close();
            }
            return station_element;
        }

        

        System.Timers.Timer timer_1 = new System.Timers.Timer(18000);

        public void timer_1_start()
        {
            timer_1.Elapsed += new System.Timers.ElapsedEventHandler(theout);
            timer_1.AutoReset = true;
            timer_1.Enabled = true;
            timer_1.Start();
        }
        public void timer_1_stop()
        {
            timer_1.Stop();
        }

        public delegate void timer_1_EventHandle(object sender,EventArgs e);

        public void theout(object source, System.Timers.ElapsedEventArgs e)
        {
            Invoke(new timer_1_EventHandle(Timer_1_Action), source, e);
        }

        public void Timer_1_Action(Object source,EventArgs e)
        {
            uu();
        }
        public void kk()
        {
            #region 获取listView控件中选择项的index  selectedIndex=?
            int selectedIndex = 0;
            if (listView1.FocusedItem != null)//这个if必须的，不然会得到值但会报错
            {
                if (listView1.SelectedItems != null)
                {
                    selectedIndex = Convert.ToInt32(listView1.FocusedItem.SubItems[1].Text) - 1;//获得的listView的值显示在文本框里
                }
                else
                {
                    selectedIndex = 0;
                }
                //textBoxX10.Text = selectedIndex.ToString();
            }
            #endregion

            if (listView1.FocusedItem != null)//这个if必须的，不然会得到值但会报错
            {
                if (listView1.SelectedItems != null)
                {
                    listView1.Focus();
                    listView1.Items[selectedIndex].Focused = true;
                    listView1.Items[selectedIndex].Selected = true;
                }

            }
            //返回被选中的站点名称
            string sta = ret_stationID();
            //返回单站的数据，哈希表
            Hashtable Ht_staData = ret_station_data(sta);
            string id = Ht_staData["id"].ToString();
            string time = Ht_staData["time"].ToString();
            double TA_CU = Convert.ToDouble(Ht_staData["TA_CU"]) / 10;//空气温度1.5m
            double TA_CD = Convert.ToDouble(Ht_staData["TA_CD"]) / 10;//空气温度0.5m
            double RH_C = Convert.ToDouble(Ht_staData["RH_C"]);//空气湿度
            double TS_U = Convert.ToDouble(Ht_staData["TS_U"]) / 10;//地表温度
            double TS_M = Convert.ToDouble(Ht_staData["TS_M"]) / 10;//地温20
            double TS_D = Convert.ToDouble(Ht_staData["TS_D"]) / 10;//地温40
            string R_U = Ht_staData["R_U"].ToString();//总辐射
            string PAR_U = Ht_staData["PAR_U"].ToString();//光合有效辐射
            string CO2_U = Ht_staData["CO2_U"].ToString();//二氧化碳

            gaugeControl1.LinearScales[1].Pointers[0].Value = TA_CU;//空气温度1.5m
            gaugeControl2.LinearScales[1].Pointers[0].Value = TA_CD;//空气温度0.5m
            gaugeControl3.LinearScales[1].Pointers[0].Value = TS_U;//地表温度
            gaugeControl4.LinearScales[1].Pointers[0].Value = TS_M;//地温20
            gaugeControl5.LinearScales[1].Pointers[0].Value = TS_D;//地温40
            gaugeControl6.LinearScales[1].Pointers[0].Value = RH_C;//空气湿度
            textBoxX1.Text = TA_CU.ToString();
            textBoxX2.Text = TA_CD.ToString();
            textBoxX3.Text = TS_U.ToString();
            textBoxX4.Text = TS_M.ToString();
            textBoxX5.Text = TS_D.ToString();
            textBoxX6.Text = RH_C.ToString();
            textBoxX7.Text = R_U;
            textBoxX8.Text = PAR_U;
            textBoxX9.Text = CO2_U;
            labelX11.Text = id;
            labelX13.Text = time;
        }
        public void uu()//object sender, ItemCheckedEventArgs e
        {
            #region 获取listView控件中选择项的index  selectedIndex=?
            int selectedIndex = 0;
            if (listView1.FocusedItem != null)//这个if必须的，不然会得到值但会报错
            {
                if (listView1.SelectedItems != null)
                {
                    selectedIndex = Convert.ToInt32(listView1.FocusedItem.SubItems[1].Text) - 1;//获得的listView的值显示在文本框里
                    //listView1.SelectedItems[0].BackColor = Color.Red;
                }
                else
                {
                    selectedIndex = 0;
                }
            }
            #endregion

            #region 定义ImageList控件中的图片，在listView中使用。
            ImageList il = new ImageList();
            il.ImageSize = new Size(16, 16);
            listView1.SmallImageList = il;
            il.Images.Add(Image.FromFile("D://开发中心//农气中心项目//1.jpg"));
            il.Images.Add(Image.FromFile("D://开发中心//农气中心项目//2.jpg"));
            #endregion

            //listStation站点列表
            Hashtable Ht_staList = listStation();



            #region listView和ImageList控件组合，显示站点列表、状态图像和加深已选站点。
            int num = 1;

            listView1.Items.Clear();
            ArrayList akeys = new ArrayList(Ht_staList.Keys);//把哈希的key放入数组中
            akeys.Sort();//排序
            foreach (string skey in akeys)
            {
                int runType = 1;
                DateTime dt = Convert.ToDateTime(Ht_staList[skey]);
                //DateTime dt1 = Convert.ToDateTime("2012-08-24 01:16:00");
                double qqq = DateTime.Now.Subtract(dt).TotalHours;
                textBoxX10.Text = qqq.ToString();
                //textBoxX10.Text = DateTime.Now.ToString();
                if (qqq <= 1)
                {
                    runType = 0;
                }
                if (qqq > 1 && qqq < 24)
                {
                    runType = 2;
                }

                string[] staID = new string[5] { "", num.ToString(), skey.ToString(), Ht_idToName[skey.ToString().Trim()].ToString(), Convert.ToDateTime(Ht_staList[skey]).ToString() };
                ListViewItem lvi = new ListViewItem(staID);
                listView1.Items.Add(lvi);
                listView1.Items[num - 1].ImageIndex = runType;
                num++;
            }
            //foreach (DictionaryEntry de in Ht_staList)
            //{
            //    string[] staID = new string[5] { "", num.ToString(), de.Key.ToString(), Ht_idToName[de.Key.ToString().Trim()].ToString(), de.Value.ToString() };
            //    ListViewItem lvi = new ListViewItem(staID);
            //    listView1.Items.Add(lvi);
            //    listView1.Items[num - 1].ImageIndex = 1;
            //    num++;
            //}
            listView1.Focus();
            listView1.Items[selectedIndex].Focused = true;
            listView1.Items[selectedIndex].Selected = true;
            #endregion



            //返回被选中的站点名称
            string sta = ret_stationID();
            //返回单站的数据，哈希表
            Hashtable Ht_staData = ret_station_data(sta);
            string id = Ht_staData["id"].ToString();
            string time = Ht_staData["time"].ToString();
            double TA_CU = Convert.ToDouble(Ht_staData["TA_CU"]) / 10;//空气温度1.5m
            double TA_CD = Convert.ToDouble(Ht_staData["TA_CD"]) / 10;//空气温度0.5m
            double RH_C = Convert.ToDouble(Ht_staData["RH_C"]);//空气湿度
            double TS_U = Convert.ToDouble(Ht_staData["TS_U"]) / 10;//地表温度
            double TS_M = Convert.ToDouble(Ht_staData["TS_M"]) / 10;//地温20
            double TS_D = Convert.ToDouble(Ht_staData["TS_D"]) / 10;//地温40
            string R_U = Ht_staData["R_U"].ToString();//总辐射
            string PAR_U = Ht_staData["PAR_U"].ToString();//光合有效辐射
            string CO2_U = Ht_staData["CO2_U"].ToString();//二氧化碳

            gaugeControl1.LinearScales[1].Pointers[0].Value = TA_CU;//空气温度1.5m
            gaugeControl2.LinearScales[1].Pointers[0].Value = TA_CD;//空气温度0.5m
            gaugeControl3.LinearScales[1].Pointers[0].Value = TS_U;//地表温度
            gaugeControl4.LinearScales[1].Pointers[0].Value = TS_M;//地温20
            gaugeControl5.LinearScales[1].Pointers[0].Value = TS_D;//地温40
            gaugeControl6.LinearScales[1].Pointers[0].Value = RH_C;//空气湿度
            textBoxX1.Text = TA_CU.ToString();
            textBoxX2.Text = TA_CD.ToString();
            textBoxX3.Text = TS_U.ToString();
            textBoxX4.Text = TS_M.ToString();
            textBoxX5.Text = TS_D.ToString();
            textBoxX6.Text = RH_C.ToString();
            textBoxX7.Text = R_U;
            textBoxX8.Text = PAR_U;
            textBoxX9.Text = CO2_U;
            labelX11.Text = id;
            labelX13.Text = time;

            //dateTimeInput1.Value = DateTime.Now;
            //textBoxX10.Text = DateTime.Now.ToString();
        }
        /// <summary>
        /// 站点列表，站点名称对应最后资料时间，返回哈希表。
        /// </summary>
        /// <returns></returns>
        public Hashtable listStation()
        {
            //string stationID = stationID;
            string sqlHost = "127.0.0.1";
            //string sqlHost = "172.18.224.30";
            string sqlCatalog = "wfqxj";
            //string sqlCatalog = "GH_TIANJIN";
            string sqlName = "wfqxj";
            string sqlPass = "baoyu";

            Hashtable Ht_station_list = new Hashtable();

            SqlConnection zdzh_con = new SqlConnection();
            zdzh_con.ConnectionString = "data source = " + sqlHost + "; initial catalog = " + sqlCatalog + "; User ID = " + sqlName + "; Password = " + sqlPass + ";";
            SqlCommand zdzh_command = new SqlCommand();
            zdzh_command.CommandText = "SELECT top 5 id,MAX(time) AS tt FROM [wfqxj].[dbo].[GH_TIANJIN] GROUP BY id,time";
            zdzh_command.Connection = zdzh_con;
            try
            {
                zdzh_command.Connection.Open();
                SqlDataReader zdzh_reader = zdzh_command.ExecuteReader();
                while (zdzh_reader.Read())
                {
                    string id = zdzh_reader["id"].ToString();
                    string time = zdzh_reader["tt"].ToString();

                    Ht_station_list.Add(id, time);
                }
                zdzh_con.Close();
            }
            catch (Exception e)
            {

            }
            finally
            {
                zdzh_con.Close();
            }
            return Ht_station_list;
        }

        

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listView1.FocusedItem != null)//这个if必须的，不然会得到值但会报错
            {
                foreach (ListViewItem lv in listView1.Items)
                {
                    lv.BackColor = Color.White;
                    if (lv.Focused)
                    {
                        lv.BackColor = Color.LightBlue;
                        kk();
                    }
                }
            }
        }

        

        /// <summary>
        /// 返回被选中的站点名称,默认为“N0001”。
        /// </summary>
        /// <returns></returns>
        private string ret_stationID()
        {
            string sta = "N0001";
            if (listView1.FocusedItem != null)//这个if必须的，不然会得到值但会报错
            {
                if (listView1.SelectedItems != null)
                {
                    sta = listView1.FocusedItem.SubItems[2].Text;//获得的listView的值第三列中为站号
                    //textBoxX2.Text = sta;
                }
            }
            return sta;
        }

        

        private void dateTimeInput1_TextChanged(object sender, EventArgs e)
        {
            DateTime dt = dateTimeInput1.Value;
            string stationid = Ht_nameToId[comboBoxEx1.SelectedItem.ToString()].ToString();
            dddddd(stationid, dt);
            
        }

        private void comboBoxEx1_TextChanged(object sender, EventArgs e)
        {
            DateTime dt = dateTimeInput1.Value;
            string stationid = Ht_nameToId[comboBoxEx1.SelectedItem.ToString()].ToString();
            dddddd(stationid, dt);
            //textBoxX10.Text = "你选择的是:   " + comboBoxEx1.SelectedIndex.ToString();
        }



        private void buttonX5_Click(object sender, EventArgs e)
        {
            groupPanelSelect5();

            listView3.Items.Clear();
            DateTime dt = DateTime.Parse(DateTime.Now.ToShortDateString().ToString());
            string sqlHost = "127.0.0.1";
            //string sqlHost = "172.18.224.30";
            string sqlCatalog = "wfqxj";
            //string sqlCatalog = "GH_TIANJIN";
            string sqlName = "wfqxj";
            string sqlPass = "baoyu";

            int num = 1;
            SqlConnection zdzh_con = new SqlConnection();
            zdzh_con.ConnectionString = "data source = " + sqlHost + "; initial catalog = " + sqlCatalog + "; User ID = " + sqlName + "; Password = " + sqlPass + ";";
            SqlCommand zdzh_command = new SqlCommand();
            zdzh_command.CommandText = "SELECT * FROM [wfqxj].[dbo].[agr_service] where begTime < '" + dt + "' and endTime > '" + dt + "' order by agr_type";
            zdzh_command.Connection = zdzh_con;
            try
            {
                zdzh_command.Connection.Open();
                SqlDataReader zdzh_reader = zdzh_command.ExecuteReader();
                while (zdzh_reader.Read())
                {
                    string agr_type = zdzh_reader["agr_type"].ToString();
                    //string begTime = DateTime.Parse(zdzh_reader["begTime"].ToString()).ToShortDateString().ToString();
                    string begTime = DateTime.Parse(zdzh_reader["begTime"].ToString()).ToString("yyyy-MM-dd");
                    string endTime = DateTime.Parse(zdzh_reader["endTime"].ToString()).ToString("yyyy-MM-dd");
                    string norms = zdzh_reader["norms"].ToString();
                    string manage = zdzh_reader["manage"].ToString();

                    string[] staID = new string[6] { num.ToString(), agr_type, norms, begTime, endTime, manage };
                    ListViewItem lvi = new ListViewItem(staID);
                    listView3.Items.Add(lvi);
                    num++;
                }
                zdzh_con.Close();
            }
            catch (Exception e2)
            {

            }
            finally
            {
                zdzh_con.Close();
            }




        }
        private void buttonX6_Click(object sender, EventArgs e)
        {
            groupPanelSelect6();

        }
        private void buttonX7_Click(object sender, EventArgs e)
        {
            //if (listView1.FocusedItem != null)//这个if必须的，不然会得到值但会报错
            //{
            //    if (listView1.SelectedItems != null)
            //    {
            //        textBoxX2.Text = listView1.FocusedItem.SubItems[2].Text;//获得的listView的值显示在文本框里
            //        //listView1.SelectedItems[0].BackColor = Color.Red;
            //    }
            //    else
            //    {
            //        textBoxX2.Text = "N0001";
            //    }
            //}

        }

        private void buttonX8_Click(object sender, EventArgs e)
        {

        }

        private void buttonX9_Click(object sender, EventArgs e)
        {

        }

        private void buttonX10_Click(object sender, EventArgs e)
        {

        }

        private void buttonX11_Click(object sender, EventArgs e)
        {
            groupPanelSelect11();


            readNyzb();

        }

        private void buttonX15_Click(object sender, EventArgs e)
        {
            readNyzb();
        }

        private void readNyzb()
        {
            listView4.Items.Clear();
            textBoxX11.Clear();
            textBoxX12.Clear();
            textBoxX13.Clear();
            textBoxX14.Clear();
            textBoxX15.Clear();

            DateTime dt = DateTime.Parse(DateTime.Now.ToShortDateString().ToString());
            string sqlHost = "127.0.0.1";
            //string sqlHost = "172.18.224.30";
            string sqlCatalog = "wfqxj";
            //string sqlCatalog = "GH_TIANJIN";
            string sqlName = "wfqxj";
            string sqlPass = "baoyu";

            int num = 1;
            SqlConnection zdzh_con = new SqlConnection();
            zdzh_con.ConnectionString = "data source = " + sqlHost + "; initial catalog = " + sqlCatalog + "; User ID = " + sqlName + "; Password = " + sqlPass + ";";
            SqlCommand zdzh_command = new SqlCommand();
            zdzh_command.CommandText = "SELECT * FROM [wfqxj].[dbo].[agr_service] where begTime < '" + dt + "' and endTime > '" + dt + "' order by agr_type";
            zdzh_command.Connection = zdzh_con;
            try
            {
                zdzh_command.Connection.Open();
                SqlDataReader zdzh_reader = zdzh_command.ExecuteReader();
                while (zdzh_reader.Read())
                {
                    string agr_type = zdzh_reader["agr_type"].ToString();
                    //string begTime = DateTime.Parse(zdzh_reader["begTime"].ToString()).ToShortDateString().ToString();
                    string begTime = DateTime.Parse(zdzh_reader["begTime"].ToString()).ToString("yyyy-MM-dd");
                    string endTime = DateTime.Parse(zdzh_reader["endTime"].ToString()).ToString("yyyy-MM-dd");
                    string norms = zdzh_reader["norms"].ToString();
                    string manage = zdzh_reader["manage"].ToString();

                    string[] staID = new string[6] { num.ToString(), agr_type, norms, begTime, endTime, manage };
                    ListViewItem lvi = new ListViewItem(staID);
                    listView4.Items.Add(lvi);
                    num++;
                }
                zdzh_con.Close();
            }
            catch (Exception e2)
            {

            }
            finally
            {
                zdzh_con.Close();
            }
        }

        private void listView4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listView4.FocusedItem != null)//这个if必须的，不然会得到值但会报错
            {
                foreach (ListViewItem lv in listView4.Items)
                {
                    lv.BackColor = Color.White;
                    if (lv.Focused)
                    {
                        lv.BackColor = Color.LightBlue;
                        viewlistView4();
                    }
                }
            }
        }
        private void viewlistView4()
        {
            if (listView4.FocusedItem != null)//这个if必须的，不然会得到值但会报错
            {
                if (listView4.SelectedItems != null)
                {
                    string agr_type = listView4.FocusedItem.SubItems[1].Text.Trim();//获得的listView的值第二列中为站号
                    string begTime = listView4.FocusedItem.SubItems[3].Text.Trim();//获得的listView的值第二列中为站号
                    string endTime = listView4.FocusedItem.SubItems[4].Text.Trim();//获得的listView的值第二列中为站号
                    string norms = listView4.FocusedItem.SubItems[2].Text.Trim();//获得的listView的值第二列中为站号
                    string manage = listView4.FocusedItem.SubItems[5].Text.Trim();//获得的listView的值第二列中为站号
                    textBoxX11.Text = agr_type;
                    textBoxX12.Text = begTime;
                    textBoxX13.Text = endTime;
                    textBoxX14.Text = norms;
                    textBoxX15.Text = manage;
                }
            }

        }

        //删除
        private void buttonX12_Click(object sender, EventArgs e)
        {
            


        }
        //插入
        private void buttonX13_Click(object sender, EventArgs e)
        {

        }
        //修改
        private void buttonX14_Click(object sender, EventArgs e)
        {

        }

        public void Update(string agr_type, DateTime begTime, DateTime endTime, string norms, string manage,string yb_type)
        {
            string sqlHost = "127.0.0.1";
            //string sqlHost = "172.18.224.30";
            string sqlCatalog = "wfqxj";
            //string sqlCatalog = "GH_TIANJIN";
            string sqlName = "wfqxj";
            string sqlPass = "baoyu";

            int num = 1;
            SqlConnection zdzh_con = new SqlConnection();
            zdzh_con.ConnectionString = "data source = " + sqlHost + "; initial catalog = " + sqlCatalog + "; User ID = " + sqlName + "; Password = " + sqlPass + ";";
            SqlCommand zdzh_command = new SqlCommand();
            zdzh_command.CommandText = "UPDATE [wfqxj].[dbo].[agr_service] SET agr_type = '" + agr_type + "' , begTime = '" + begTime + "' , endTime = '" + endTime + "' , norms = '" + norms + "' , manage = '" + manage + "' where yb_type = '" + yb_type + "'";
            zdzh_command.Connection = zdzh_con;
            try
            {
                zdzh_command.Connection.Open();
                zdzh_command.ExecuteNonQuery();
                zdzh_con.Close();
                System.Windows.Forms.MessageBox.Show("数据更新完成！");
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message);
            }
            finally
            {
                zdzh_con.Close();
            }
        
        }
        public void Delete()
        {

        }
        public void Change()
        {

        }
        public void PamDuan()
        {

        }

    }
}
