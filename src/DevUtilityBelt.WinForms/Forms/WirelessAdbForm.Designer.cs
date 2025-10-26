namespace DevUtilityBelt.WinForms.Forms
{
    partial class WirelessAdbForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            buttonScan = new Button();
            buttonConnect = new Button();
            splitContainerAdbWireless = new SplitContainer();
            groupBoxDeviceList = new GroupBox();
            groupBoxLog = new GroupBox();
            textBoxLog = new TextBox();
            listBoxDeviceList = new ListBox();
            ((System.ComponentModel.ISupportInitialize)splitContainerAdbWireless).BeginInit();
            splitContainerAdbWireless.Panel1.SuspendLayout();
            splitContainerAdbWireless.Panel2.SuspendLayout();
            splitContainerAdbWireless.SuspendLayout();
            groupBoxDeviceList.SuspendLayout();
            groupBoxLog.SuspendLayout();
            SuspendLayout();
            // 
            // buttonScan
            // 
            buttonScan.Location = new Point(12, 12);
            buttonScan.Name = "buttonScan";
            buttonScan.Size = new Size(75, 23);
            buttonScan.TabIndex = 0;
            buttonScan.Text = "Scan";
            buttonScan.UseVisualStyleBackColor = true;
            // 
            // buttonConnect
            // 
            buttonConnect.Location = new Point(333, 12);
            buttonConnect.Name = "buttonConnect";
            buttonConnect.Size = new Size(75, 23);
            buttonConnect.TabIndex = 1;
            buttonConnect.Text = "Connect";
            buttonConnect.UseVisualStyleBackColor = true;
            // 
            // splitContainerAdbWireless
            // 
            splitContainerAdbWireless.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainerAdbWireless.Location = new Point(12, 41);
            splitContainerAdbWireless.Name = "splitContainerAdbWireless";
            splitContainerAdbWireless.Orientation = Orientation.Horizontal;
            // 
            // splitContainerAdbWireless.Panel1
            // 
            splitContainerAdbWireless.Panel1.Controls.Add(groupBoxDeviceList);
            // 
            // splitContainerAdbWireless.Panel2
            // 
            splitContainerAdbWireless.Panel2.Controls.Add(groupBoxLog);
            splitContainerAdbWireless.Size = new Size(396, 397);
            splitContainerAdbWireless.SplitterDistance = 165;
            splitContainerAdbWireless.TabIndex = 2;
            // 
            // groupBoxDeviceList
            // 
            groupBoxDeviceList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxDeviceList.Controls.Add(listBoxDeviceList);
            groupBoxDeviceList.Location = new Point(3, 3);
            groupBoxDeviceList.Name = "groupBoxDeviceList";
            groupBoxDeviceList.Size = new Size(390, 159);
            groupBoxDeviceList.TabIndex = 0;
            groupBoxDeviceList.TabStop = false;
            groupBoxDeviceList.Text = "Devices";
            // 
            // groupBoxLog
            // 
            groupBoxLog.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxLog.Controls.Add(textBoxLog);
            groupBoxLog.Location = new Point(3, 3);
            groupBoxLog.Name = "groupBoxLog";
            groupBoxLog.Size = new Size(390, 225);
            groupBoxLog.TabIndex = 0;
            groupBoxLog.TabStop = false;
            groupBoxLog.Text = "Log";
            // 
            // textBoxLog
            // 
            textBoxLog.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBoxLog.Location = new Point(6, 22);
            textBoxLog.Multiline = true;
            textBoxLog.Name = "textBoxLog";
            textBoxLog.ScrollBars = ScrollBars.Both;
            textBoxLog.Size = new Size(378, 197);
            textBoxLog.TabIndex = 1;
            // 
            // listBoxDeviceList
            // 
            listBoxDeviceList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listBoxDeviceList.FormattingEnabled = true;
            listBoxDeviceList.Location = new Point(6, 22);
            listBoxDeviceList.Name = "listBoxDeviceList";
            listBoxDeviceList.Size = new Size(378, 139);
            listBoxDeviceList.TabIndex = 0;
            // 
            // WirelessAdbForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(419, 450);
            Controls.Add(splitContainerAdbWireless);
            Controls.Add(buttonConnect);
            Controls.Add(buttonScan);
            Name = "WirelessAdbForm";
            Text = "WirelessAdbForm";
            splitContainerAdbWireless.Panel1.ResumeLayout(false);
            splitContainerAdbWireless.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerAdbWireless).EndInit();
            splitContainerAdbWireless.ResumeLayout(false);
            groupBoxDeviceList.ResumeLayout(false);
            groupBoxLog.ResumeLayout(false);
            groupBoxLog.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button buttonScan;
        private Button buttonConnect;
        private SplitContainer splitContainerAdbWireless;
        private GroupBox groupBoxDeviceList;
        private GroupBox groupBoxLog;
        private ListBox listBoxDeviceList;
        private TextBox textBoxLog;
    }
}