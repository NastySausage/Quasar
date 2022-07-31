﻿using Quasar.Common;
using System;
using System.Windows.Forms;

namespace Quasar.Server
{
    public partial class FrmRegValueEditString : Form
    {
        private readonly RegValueData _value;

        public FrmRegValueEditString(RegValueData value)
        {
            _value = value;

            InitializeComponent();

            this.valueNameTxtBox.Text = RegValueHelper.GetName(value.Name);
            this.valueDataTxtBox.Text = ByteConverter.ToString(value.Data);
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            _value.Data = ByteConverter.GetBytes(valueDataTxtBox.Text);
            this.Tag = _value;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
