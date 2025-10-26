namespace DevUtilityBelt.WinForms.Forms
{
    partial class YarpForm
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
            labelUpstreamPort = new Label();
            numericUpstreamPort = new NumericUpDown();
            numericPublicPort = new NumericUpDown();
            labelPublicPort = new Label();
            buttonConnect = new Button();
            buttonClearLog = new Button();
            groupBox1 = new GroupBox();
            textBoxLog = new TextBox();
            ((System.ComponentModel.ISupportInitialize)numericUpstreamPort).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericPublicPort).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // labelUpstreamPort
            // 
            labelUpstreamPort.AutoSize = true;
            labelUpstreamPort.Location = new Point(18, 19);
            labelUpstreamPort.Name = "labelUpstreamPort";
            labelUpstreamPort.Size = new Size(86, 15);
            labelUpstreamPort.TabIndex = 0;
            labelUpstreamPort.Text = "Upstream Port:";
            // 
            // numericUpstreamPort
            // 
            numericUpstreamPort.Location = new Point(110, 17);
            numericUpstreamPort.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            numericUpstreamPort.Name = "numericUpstreamPort";
            numericUpstreamPort.Size = new Size(128, 23);
            numericUpstreamPort.TabIndex = 1;
            numericUpstreamPort.Value = new decimal(new int[] { 5101, 0, 0, 0 });
            // 
            // numericPublicPort
            // 
            numericPublicPort.Location = new Point(110, 46);
            numericPublicPort.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            numericPublicPort.Name = "numericPublicPort";
            numericPublicPort.Size = new Size(128, 23);
            numericPublicPort.TabIndex = 3;
            numericPublicPort.Value = new decimal(new int[] { 6101, 0, 0, 0 });
            // 
            // labelPublicPort
            // 
            labelPublicPort.AutoSize = true;
            labelPublicPort.Location = new Point(18, 48);
            labelPublicPort.Name = "labelPublicPort";
            labelPublicPort.Size = new Size(68, 15);
            labelPublicPort.TabIndex = 2;
            labelPublicPort.Text = "Public Port:";
            // 
            // buttonConnect
            // 
            buttonConnect.Location = new Point(291, 15);
            buttonConnect.Name = "buttonConnect";
            buttonConnect.Size = new Size(75, 23);
            buttonConnect.TabIndex = 4;
            buttonConnect.Text = "Connect";
            buttonConnect.UseVisualStyleBackColor = true;
            // 
            // buttonClearLog
            // 
            buttonClearLog.Location = new Point(291, 44);
            buttonClearLog.Name = "buttonClearLog";
            buttonClearLog.Size = new Size(75, 23);
            buttonClearLog.TabIndex = 5;
            buttonClearLog.Text = "Clear Log";
            buttonClearLog.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(textBoxLog);
            groupBox1.Location = new Point(12, 75);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(360, 363);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Log";
            // 
            // textBoxLog
            // 
            textBoxLog.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBoxLog.Location = new Point(6, 22);
            textBoxLog.Multiline = true;
            textBoxLog.Name = "textBoxLog";
            textBoxLog.ScrollBars = ScrollBars.Both;
            textBoxLog.Size = new Size(348, 335);
            textBoxLog.TabIndex = 0;
            // 
            // YarpForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 450);
            Controls.Add(groupBox1);
            Controls.Add(buttonClearLog);
            Controls.Add(buttonConnect);
            Controls.Add(numericPublicPort);
            Controls.Add(labelPublicPort);
            Controls.Add(numericUpstreamPort);
            Controls.Add(labelUpstreamPort);
            Name = "YarpForm";
            Text = "YarpForm";
            ((System.ComponentModel.ISupportInitialize)numericUpstreamPort).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericPublicPort).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelUpstreamPort;
        private NumericUpDown numericUpstreamPort;
        private NumericUpDown numericPublicPort;
        private Label labelPublicPort;
        private Button buttonConnect;
        private Button buttonClearLog;
        private GroupBox groupBox1;
        private TextBox textBoxLog;
    }
}