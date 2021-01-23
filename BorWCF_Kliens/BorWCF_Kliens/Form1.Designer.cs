
namespace BorWCF_Kliens
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
            this.components = new System.ComponentModel.Container();
            this.borfajtaLabel = new System.Windows.Forms.Label();
            this.boralkoholLabel = new System.Windows.Forms.Label();
            this.cukorLabel = new System.Windows.Forms.Label();
            this.loginLabel = new System.Windows.Forms.Label();
            this.nevLabel = new System.Windows.Forms.Label();
            this.jelszoLabel = new System.Windows.Forms.Label();
            this.borGrid = new System.Windows.Forms.DataGridView();
            this.loginBtn = new System.Windows.Forms.Button();
            this.logoutBtn = new System.Windows.Forms.Button();
            this.loginnameTxtbox = new System.Windows.Forms.TextBox();
            this.loginpassTxtbox = new System.Windows.Forms.TextBox();
            this.fajtaTxtbox = new System.Windows.Forms.TextBox();
            this.edessegTxtbox = new System.Windows.Forms.TextBox();
            this.felvitelBtn = new System.Windows.Forms.Button();
            this.listaBtn = new System.Windows.Forms.Button();
            this.modositBtn = new System.Windows.Forms.Button();
            this.alkoholNumeric = new System.Windows.Forms.NumericUpDown();
            this.csatlLabel = new System.Windows.Forms.Label();
            this.borBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.logindefname = new System.Windows.Forms.Label();
            this.logindefpass = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.borGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alkoholNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.borBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // borfajtaLabel
            // 
            this.borfajtaLabel.AutoSize = true;
            this.borfajtaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.borfajtaLabel.Location = new System.Drawing.Point(28, 20);
            this.borfajtaLabel.Name = "borfajtaLabel";
            this.borfajtaLabel.Size = new System.Drawing.Size(57, 16);
            this.borfajtaLabel.TabIndex = 0;
            this.borfajtaLabel.Text = "Bor fajta";
            // 
            // boralkoholLabel
            // 
            this.boralkoholLabel.AutoSize = true;
            this.boralkoholLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.boralkoholLabel.Location = new System.Drawing.Point(28, 55);
            this.boralkoholLabel.Name = "boralkoholLabel";
            this.boralkoholLabel.Size = new System.Drawing.Size(53, 16);
            this.boralkoholLabel.TabIndex = 1;
            this.boralkoholLabel.Text = "Alkohol";
            // 
            // cukorLabel
            // 
            this.cukorLabel.AutoSize = true;
            this.cukorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cukorLabel.Location = new System.Drawing.Point(28, 87);
            this.cukorLabel.Name = "cukorLabel";
            this.cukorLabel.Size = new System.Drawing.Size(63, 16);
            this.cukorLabel.TabIndex = 2;
            this.cukorLabel.Text = "Édesség";
            // 
            // loginLabel
            // 
            this.loginLabel.AutoSize = true;
            this.loginLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.loginLabel.Location = new System.Drawing.Point(351, 9);
            this.loginLabel.Name = "loginLabel";
            this.loginLabel.Size = new System.Drawing.Size(127, 24);
            this.loginLabel.TabIndex = 3;
            this.loginLabel.Text = "Bejelentkezés";
            // 
            // nevLabel
            // 
            this.nevLabel.AllowDrop = true;
            this.nevLabel.AutoSize = true;
            this.nevLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nevLabel.Location = new System.Drawing.Point(393, 35);
            this.nevLabel.Name = "nevLabel";
            this.nevLabel.Size = new System.Drawing.Size(33, 16);
            this.nevLabel.TabIndex = 4;
            this.nevLabel.Text = "Név";
            // 
            // jelszoLabel
            // 
            this.jelszoLabel.AllowDrop = true;
            this.jelszoLabel.AutoSize = true;
            this.jelszoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.jelszoLabel.Location = new System.Drawing.Point(383, 82);
            this.jelszoLabel.Name = "jelszoLabel";
            this.jelszoLabel.Size = new System.Drawing.Size(47, 16);
            this.jelszoLabel.TabIndex = 5;
            this.jelszoLabel.Text = "Jelszó";
            // 
            // borGrid
            // 
            this.borGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.borGrid.Location = new System.Drawing.Point(12, 170);
            this.borGrid.Name = "borGrid";
            this.borGrid.Size = new System.Drawing.Size(549, 201);
            this.borGrid.TabIndex = 6;
            this.borGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.borGrid_CellContentClick);
            // 
            // loginBtn
            // 
            this.loginBtn.Location = new System.Drawing.Point(360, 126);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(92, 28);
            this.loginBtn.TabIndex = 7;
            this.loginBtn.Text = "Bejelentkezés";
            this.loginBtn.UseVisualStyleBackColor = true;
            this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
            // 
            // logoutBtn
            // 
            this.logoutBtn.Location = new System.Drawing.Point(469, 126);
            this.logoutBtn.Name = "logoutBtn";
            this.logoutBtn.Size = new System.Drawing.Size(92, 28);
            this.logoutBtn.TabIndex = 8;
            this.logoutBtn.Text = "Kijelentkezés";
            this.logoutBtn.UseVisualStyleBackColor = true;
            this.logoutBtn.Click += new System.EventHandler(this.logoutBtn_Click);
            // 
            // loginnameTxtbox
            // 
            this.loginnameTxtbox.Location = new System.Drawing.Point(355, 54);
            this.loginnameTxtbox.Name = "loginnameTxtbox";
            this.loginnameTxtbox.Size = new System.Drawing.Size(100, 20);
            this.loginnameTxtbox.TabIndex = 9;
            // 
            // loginpassTxtbox
            // 
            this.loginpassTxtbox.Location = new System.Drawing.Point(355, 101);
            this.loginpassTxtbox.Name = "loginpassTxtbox";
            this.loginpassTxtbox.Size = new System.Drawing.Size(100, 20);
            this.loginpassTxtbox.TabIndex = 10;
            // 
            // fajtaTxtbox
            // 
            this.fajtaTxtbox.Location = new System.Drawing.Point(116, 19);
            this.fajtaTxtbox.Name = "fajtaTxtbox";
            this.fajtaTxtbox.Size = new System.Drawing.Size(100, 20);
            this.fajtaTxtbox.TabIndex = 11;
            // 
            // edessegTxtbox
            // 
            this.edessegTxtbox.Location = new System.Drawing.Point(116, 86);
            this.edessegTxtbox.Name = "edessegTxtbox";
            this.edessegTxtbox.Size = new System.Drawing.Size(100, 20);
            this.edessegTxtbox.TabIndex = 13;
            // 
            // felvitelBtn
            // 
            this.felvitelBtn.Location = new System.Drawing.Point(127, 122);
            this.felvitelBtn.Name = "felvitelBtn";
            this.felvitelBtn.Size = new System.Drawing.Size(75, 23);
            this.felvitelBtn.TabIndex = 14;
            this.felvitelBtn.Text = "Felvitel";
            this.felvitelBtn.UseVisualStyleBackColor = true;
            this.felvitelBtn.Click += new System.EventHandler(this.felvitelBtn_Click);
            // 
            // listaBtn
            // 
            this.listaBtn.Location = new System.Drawing.Point(16, 141);
            this.listaBtn.Name = "listaBtn";
            this.listaBtn.Size = new System.Drawing.Size(75, 23);
            this.listaBtn.TabIndex = 15;
            this.listaBtn.Text = "Listázás";
            this.listaBtn.UseVisualStyleBackColor = true;
            this.listaBtn.Click += new System.EventHandler(this.listaBtn_Click);
            // 
            // modositBtn
            // 
            this.modositBtn.Location = new System.Drawing.Point(241, 19);
            this.modositBtn.Name = "modositBtn";
            this.modositBtn.Size = new System.Drawing.Size(75, 23);
            this.modositBtn.TabIndex = 16;
            this.modositBtn.Text = "Módosítás";
            this.modositBtn.UseVisualStyleBackColor = true;
            this.modositBtn.Click += new System.EventHandler(this.modositBtn_Click);
            // 
            // alkoholNumeric
            // 
            this.alkoholNumeric.Location = new System.Drawing.Point(116, 51);
            this.alkoholNumeric.Name = "alkoholNumeric";
            this.alkoholNumeric.Size = new System.Drawing.Size(100, 20);
            this.alkoholNumeric.TabIndex = 17;
            // 
            // csatlLabel
            // 
            this.csatlLabel.AutoSize = true;
            this.csatlLabel.Location = new System.Drawing.Point(196, 154);
            this.csatlLabel.Name = "csatlLabel";
            this.csatlLabel.Size = new System.Drawing.Size(104, 13);
            this.csatlLabel.TabIndex = 18;
            this.csatlLabel.Text = "Csatlakozási kísérlet";
            // 
            // borBindingSource
            // 
            this.borBindingSource.DataSource = typeof(BorWCF_Kliens.BorServiceReference.Bor);
            // 
            // logindefname
            // 
            this.logindefname.AutoSize = true;
            this.logindefname.Location = new System.Drawing.Point(498, 55);
            this.logindefname.Name = "logindefname";
            this.logindefname.Size = new System.Drawing.Size(61, 13);
            this.logindefname.TabIndex = 19;
            this.logindefname.Text = "Név: admin";
            // 
            // logindefpass
            // 
            this.logindefpass.AutoSize = true;
            this.logindefpass.Location = new System.Drawing.Point(498, 90);
            this.logindefpass.Name = "logindefpass";
            this.logindefpass.Size = new System.Drawing.Size(67, 13);
            this.logindefpass.TabIndex = 20;
            this.logindefpass.Text = "jelszó: admin";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 389);
            this.Controls.Add(this.logindefpass);
            this.Controls.Add(this.logindefname);
            this.Controls.Add(this.csatlLabel);
            this.Controls.Add(this.alkoholNumeric);
            this.Controls.Add(this.modositBtn);
            this.Controls.Add(this.listaBtn);
            this.Controls.Add(this.felvitelBtn);
            this.Controls.Add(this.edessegTxtbox);
            this.Controls.Add(this.fajtaTxtbox);
            this.Controls.Add(this.loginpassTxtbox);
            this.Controls.Add(this.loginnameTxtbox);
            this.Controls.Add(this.logoutBtn);
            this.Controls.Add(this.loginBtn);
            this.Controls.Add(this.borGrid);
            this.Controls.Add(this.jelszoLabel);
            this.Controls.Add(this.nevLabel);
            this.Controls.Add(this.loginLabel);
            this.Controls.Add(this.cukorLabel);
            this.Controls.Add(this.boralkoholLabel);
            this.Controls.Add(this.borfajtaLabel);
            this.Name = "Form1";
            this.Text = "Bor nyílvántartás";
            ((System.ComponentModel.ISupportInitialize)(this.borGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alkoholNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.borBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label borfajtaLabel;
        private System.Windows.Forms.Label boralkoholLabel;
        private System.Windows.Forms.Label cukorLabel;
        private System.Windows.Forms.Label loginLabel;
        private System.Windows.Forms.Label nevLabel;
        private System.Windows.Forms.Label jelszoLabel;
        private System.Windows.Forms.DataGridView borGrid;
        private System.Windows.Forms.BindingSource borBindingSource;
        private System.Windows.Forms.Button loginBtn;
        private System.Windows.Forms.Button logoutBtn;
        private System.Windows.Forms.TextBox loginnameTxtbox;
        private System.Windows.Forms.TextBox loginpassTxtbox;
        private System.Windows.Forms.TextBox fajtaTxtbox;
        private System.Windows.Forms.TextBox edessegTxtbox;
        private System.Windows.Forms.Button felvitelBtn;
        private System.Windows.Forms.Button listaBtn;
        private System.Windows.Forms.Button modositBtn;
        private System.Windows.Forms.NumericUpDown alkoholNumeric;
        private System.Windows.Forms.Label csatlLabel;
        private System.Windows.Forms.Label logindefname;
        private System.Windows.Forms.Label logindefpass;
    }
}

