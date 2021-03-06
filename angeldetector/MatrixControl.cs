﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Math;

namespace angeldetector
{
    public partial class MatrixControl : UserControl
    {
        private Dictionary<string, TextBox> textBoxes = new Dictionary<string, TextBox>();

        public string Title
        {
            get { return groupBox.Text; }
            set { groupBox.Text = value; }
        }

        public MatrixControl()
        {
            InitializeComponent();
        }

        public void SetMatrix(Matrix4x4 matrix)
        {
            float[] array = matrix.ToArray();

            for (int i = 0, k = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++, k++)
                {
                    string textBoxName = string.Format("i{0}_j{1}_Box", i, j);

                    if (textBoxes.ContainsKey(textBoxName))
                    {
                        textBoxes[textBoxName].Text = FormatFloat(array[k]);
                    }
                }
            }
        }
        public Matrix4x4 GetMatricx()
        {
            Matrix4x4 ret = new Matrix4x4();

            ret.V00 = float.Parse(textBoxes["i0_j0_Box"].Text);
            ret.V01 = float.Parse(textBoxes["i0_j1_Box"].Text);
            ret.V02 = float.Parse(textBoxes["i0_j2_Box"].Text);
            ret.V03 = float.Parse(textBoxes["i0_j3_Box"].Text);
            ret.V10 = float.Parse(textBoxes["i1_j0_Box"].Text);
            ret.V11 = float.Parse(textBoxes["i1_j1_Box"].Text);
            ret.V12 = float.Parse(textBoxes["i1_j2_Box"].Text);
            ret.V13 = float.Parse(textBoxes["i1_j3_Box"].Text);
            ret.V20 = float.Parse(textBoxes["i2_j0_Box"].Text);
            ret.V21 = float.Parse(textBoxes["i2_j1_Box"].Text);
            ret.V22 = float.Parse(textBoxes["i2_j2_Box"].Text);
            ret.V23 = float.Parse(textBoxes["i2_j3_Box"].Text);
            ret.V30 = float.Parse(textBoxes["i3_j0_Box"].Text);
            ret.V31 = float.Parse(textBoxes["i3_j1_Box"].Text);
            ret.V32 = float.Parse(textBoxes["i3_j2_Box"].Text);
            ret.V33 = float.Parse(textBoxes["i3_j3_Box"].Text);

            return ret;
        }
        public void Clear()
        {
            for (int i = 0, k = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++, k++)
                {
                    string textBoxName = string.Format("i{0}_j{1}_Box", i, j);

                    if (textBoxes.ContainsKey(textBoxName))
                    {
                        textBoxes[textBoxName].Text = string.Empty;
                    }
                }
            }
        }

        private static string FormatFloat(float floatValue)
        {
            return String.Format("{0:0.####}", floatValue);
        }

        private void MatrixControl_Load(object sender, EventArgs e)
        {
            textBoxes.Clear();

            foreach (Control c in groupBox.Controls)
            {
                if (c is TextBox)
                {
                    textBoxes.Add(c.Name, (TextBox)c);
                }
            }
        }
    }
}
