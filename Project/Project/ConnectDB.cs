using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.OleDb;

namespace Project
{
    public class ConnectDB
    {
        private int i = 0;
        private String[] images = new string[21];
        private int[] keypoint=new int [21];
        
        private int k;
        private static Boolean []sorting=new Boolean [21];
        public String[] ConnectHere(String source)
        {
            for (int i = 0; i < 21; i++)
            {
                sorting[i] = false;
            }
            OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source='E:\OurImages.accdb'");

            OleDbCommand cmd = new OleDbCommand();

            cmd.Connection = conn;

            cmd.CommandText = "select * from Main_Pictures ";

            conn.Open();

            OleDbDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                images[i] = reader[1].ToString();

                keypoint[i] = Convert.ToInt32(reader[2].ToString());

                //sorting.Add(keypoint[i]);

                if (source == images[i])
                {

                    k = i;
                }
                i++;
            }
            conn.Close();
                                                          
           return images;
        }

        public int get_Keypoint()
        {
            return this.keypoint[k];
        }

        public String  get_The_Closest_KeyPoint()
        {
            int ours=0;
            int d=0;
            int u=0;
            int c=0;

            int min = 1000;
            int z = 0;
            for (int i = 0; i < keypoint.Length; i++)
            {
                u = keypoint [i];
                z=u-this.keypoint[k];
                d=Math.Abs(z);
           
                if ( (d < min) && (ConnectDB.sorting[i]==false) )
                {
                    
                    ours = keypoint[i];
                    c=i;
                    min = d;
                  
                }
              
              
            }
            ConnectDB.sorting[c] = true;
            if (min == 1000)
            {
                return null;
            }
            else
            {
                return images[c].ToString();
            }
                }
        /*
        public String geting_The_Closest_Image()
        {
            int ours=this.get_The_Closest_KeyPoint();
            int h=0;
            for (int j = 0; j < keypoint.Length;j++)
            {
                if (keypoint[j] == ours)
                {
                    h = j;
                    break;
                }
            }
            return images[h].ToString();
        }
         */

         }
    }