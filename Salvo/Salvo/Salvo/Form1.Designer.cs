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
            this.StartPrompt3 = new System.Windows.Forms.Label();
            this.ipAddressBox = new System.Windows.Forms.TextBox();
            this.StartPrompt2 = new System.Windows.Forms.Label();
            this.StartPrompt1 = new System.Windows.Forms.Label();
            this.StartHost = new System.Windows.Forms.Button();
            this.StartClient = new System.Windows.Forms.Button();
            this.Title = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // StartPrompt3
            // 
            this.StartPrompt3.AutoSize = true;
            this.StartPrompt3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartPrompt3.Location = new System.Drawing.Point(96, 119);
            this.StartPrompt3.Name = "StartPrompt3";
            this.StartPrompt3.Size = new System.Drawing.Size(175, 17);
            this.StartPrompt3.TabIndex = 12;
            this.StartPrompt3.Text = "and click \"Start As Client\".";
            // 
            // ipAddressBox
            // 
            this.ipAddressBox.BackColor = System.Drawing.SystemColors.Info;
            this.ipAddressBox.Location = new System.Drawing.Point(70, 151);
            this.ipAddressBox.Name = "ipAddressBox";
            this.ipAddressBox.Size = new System.Drawing.Size(236, 20);
            this.ipAddressBox.TabIndex = 11;
            // 
            // StartPrompt2
            // 
            this.StartPrompt2.AutoSize = true;
            this.StartPrompt2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartPrompt2.Location = new System.Drawing.Point(12, 93);
            this.StartPrompt2.Name = "StartPrompt2";
            this.StartPrompt2.Size = new System.Drawing.Size(342, 17);
            this.StartPrompt2.TabIndex = 10;
            this.StartPrompt2.Text = "To connect to a host: enter an ip address in the box,";
            // 
            // StartPrompt1
            // 
            this.StartPrompt1.AutoSize = true;
            this.StartPrompt1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartPrompt1.Location = new System.Drawing.Point(23, 65);
            this.StartPrompt1.Name = "StartPrompt1";
            this.StartPrompt1.Size = new System.Drawing.Size(323, 17);
            this.StartPrompt1.TabIndex = 9;
            this.StartPrompt1.Text = "To start the game as a Host click \"Start As Host\".";
            // 
            // StartHost
            // 
            this.StartHost.Location = new System.Drawing.Point(26, 206);
            this.StartHost.Name = "StartHost";
            this.StartHost.Size = new System.Drawing.Size(328, 23);
            this.StartHost.TabIndex = 8;
            this.StartHost.Text = "Start As Host";
            this.StartHost.UseVisualStyleBackColor = true;
            this.StartHost.Click += new System.EventHandler(this.StartHost_Click);
            // 
            // StartClient
            // 
            this.StartClient.Location = new System.Drawing.Point(26, 177);
            this.StartClient.Name = "StartClient";
            this.StartClient.Size = new System.Drawing.Size(328, 23);
            this.StartClient.TabIndex = 7;
            this.StartClient.Text = "Start As Client";
            this.StartClient.UseVisualStyleBackColor = true;
            this.StartClient.Click += new System.EventHandler(this.StartClient_Click);
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Segoe Script", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Title.ForeColor = System.Drawing.Color.DarkRed;
            this.Title.Location = new System.Drawing.Point(53, -9);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(277, 102);
            this.Title.TabIndex = 13;
            this.Title.Text = "SALVO";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(382, 242);
            this.Controls.Add(this.StartPrompt3);
            this.Controls.Add(this.ipAddressBox);
            this.Controls.Add(this.StartPrompt2);
            this.Controls.Add(this.StartPrompt1);
            this.Controls.Add(this.StartHost);
            this.Controls.Add(this.StartClient);
            this.Controls.Add(this.Title);
            this.Name = "Form1";
            this.Text = "Salvo Game";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label StartPrompt3;
        private System.Windows.Forms.TextBox ipAddressBox;
        private System.Windows.Forms.Label StartPrompt2;
        private System.Windows.Forms.Label StartPrompt1;
        private System.Windows.Forms.Button StartHost;
        private System.Windows.Forms.Button StartClient;
        private System.Windows.Forms.Label Title;
    }
}

