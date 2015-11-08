namespace Salvo
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.ipAddressBox = new System.Windows.Forms.TextBox();
            this.StartPrompt2 = new System.Windows.Forms.Label();
            this.StartPrompt1 = new System.Windows.Forms.Label();
            this.StartHost = new System.Windows.Forms.Button();
            this.StartClient = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(103, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "and click \"Start As Client\".";
            // 
            // ipAddressBox
            // 
            this.ipAddressBox.BackColor = System.Drawing.SystemColors.Info;
            this.ipAddressBox.Location = new System.Drawing.Point(77, 151);
            this.ipAddressBox.Name = "ipAddressBox";
            this.ipAddressBox.Size = new System.Drawing.Size(236, 20);
            this.ipAddressBox.TabIndex = 11;
            // 
            // StartPrompt2
            // 
            this.StartPrompt2.AutoSize = true;
            this.StartPrompt2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartPrompt2.Location = new System.Drawing.Point(30, 93);
            this.StartPrompt2.Name = "StartPrompt2";
            this.StartPrompt2.Size = new System.Drawing.Size(342, 17);
            this.StartPrompt2.TabIndex = 10;
            this.StartPrompt2.Text = "To connect to a host: enter an ip address in the box,";
            // 
            // StartPrompt1
            // 
            this.StartPrompt1.AutoSize = true;
            this.StartPrompt1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartPrompt1.Location = new System.Drawing.Point(30, 65);
            this.StartPrompt1.Name = "StartPrompt1";
            this.StartPrompt1.Size = new System.Drawing.Size(323, 17);
            this.StartPrompt1.TabIndex = 9;
            this.StartPrompt1.Text = "To start the game as a Host click \"Start As Host\".";
            // 
            // StartHost
            // 
            this.StartHost.BackColor = System.Drawing.SystemColors.Info;
            this.StartHost.Location = new System.Drawing.Point(33, 206);
            this.StartHost.Name = "StartHost";
            this.StartHost.Size = new System.Drawing.Size(328, 23);
            this.StartHost.TabIndex = 8;
            this.StartHost.Text = "Start As Host";
            this.StartHost.UseVisualStyleBackColor = false;
            this.StartHost.Click += new System.EventHandler(this.StartHost_Click);
            // 
            // StartClient
            // 
            this.StartClient.BackColor = System.Drawing.SystemColors.Info;
            this.StartClient.Location = new System.Drawing.Point(33, 177);
            this.StartClient.Name = "StartClient";
            this.StartClient.Size = new System.Drawing.Size(328, 23);
            this.StartClient.TabIndex = 7;
            this.StartClient.Text = "Start As Client";
            this.StartClient.UseVisualStyleBackColor = false;
            this.StartClient.Click += new System.EventHandler(this.StartClient_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe Script", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.DarkRed;
            this.label2.Location = new System.Drawing.Point(60, -9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(277, 102);
            this.label2.TabIndex = 13;
            this.label2.Text = "SALVO";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 242);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ipAddressBox);
            this.Controls.Add(this.StartPrompt2);
            this.Controls.Add(this.StartPrompt1);
            this.Controls.Add(this.StartHost);
            this.Controls.Add(this.StartClient);
            this.Controls.Add(this.label2);
            this.Name = "Form1";
            this.Text = "Salvo Game";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ipAddressBox;
        private System.Windows.Forms.Label StartPrompt2;
        private System.Windows.Forms.Label StartPrompt1;
        private System.Windows.Forms.Button StartHost;
        private System.Windows.Forms.Button StartClient;
        private System.Windows.Forms.Label label2;
    }
}

