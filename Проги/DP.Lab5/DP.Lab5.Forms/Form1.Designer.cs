namespace DP.Lab5.Forms
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvGrille = new DataGridView();
            label1 = new Label();
            tbInitMessage = new TextBox();
            btnNext = new Button();
            btnPrev = new Button();
            lblEncoded = new Label();
            btnEncode = new Button();
            label2 = new Label();
            tbEncoded = new TextBox();
            lblDecoded = new Label();
            btnDecode = new Button();
            tbEncodedFromAlgorithm = new TextBox();
            tbDecodedFromAlgorithm = new TextBox();
            label3 = new Label();
            tbNormalized = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvGrille).BeginInit();
            SuspendLayout();
            // 
            // dgvGrille
            // 
            dgvGrille.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGrille.Location = new Point(106, 12);
            dgvGrille.Name = "dgvGrille";
            dgvGrille.RowTemplate.Height = 25;
            dgvGrille.Size = new Size(641, 218);
            dgvGrille.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 392);
            label1.Name = "label1";
            label1.Size = new Size(178, 15);
            label1.TabIndex = 1;
            label1.Text = "Введите исходное сообщение: ";
            // 
            // tbInitMessage
            // 
            tbInitMessage.Location = new Point(12, 410);
            tbInitMessage.Name = "tbInitMessage";
            tbInitMessage.Size = new Size(100, 23);
            tbInitMessage.TabIndex = 2;
            // 
            // btnNext
            // 
            btnNext.Location = new Point(283, 264);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(100, 40);
            btnNext.TabIndex = 3;
            btnNext.Text = "Следующий ";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // btnPrev
            // 
            btnPrev.Location = new Point(466, 264);
            btnPrev.Name = "btnPrev";
            btnPrev.Size = new Size(107, 40);
            btnPrev.TabIndex = 3;
            btnPrev.Text = "Предыдущий";
            btnPrev.UseVisualStyleBackColor = true;
            btnPrev.Click += btnPrev_Click;
            // 
            // lblEncoded
            // 
            lblEncoded.AutoSize = true;
            lblEncoded.Location = new Point(12, 516);
            lblEncoded.Name = "lblEncoded";
            lblEncoded.Size = new Size(172, 15);
            lblEncoded.TabIndex = 4;
            lblEncoded.Text = "Закодированное сообщение: ";
            // 
            // btnEncode
            // 
            btnEncode.Location = new Point(13, 448);
            btnEncode.Name = "btnEncode";
            btnEncode.Size = new Size(171, 23);
            btnEncode.TabIndex = 5;
            btnEncode.Text = "Закодировать";
            btnEncode.UseVisualStyleBackColor = true;
            btnEncode.Click += btnEncode_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(576, 388);
            label2.Name = "label2";
            label2.Size = new Size(213, 15);
            label2.TabIndex = 6;
            label2.Text = "Введите закодированное сообщение:";
            // 
            // tbEncoded
            // 
            tbEncoded.Location = new Point(575, 410);
            tbEncoded.Name = "tbEncoded";
            tbEncoded.Size = new Size(100, 23);
            tbEncoded.TabIndex = 2;
            // 
            // lblDecoded
            // 
            lblDecoded.AutoSize = true;
            lblDecoded.Location = new Point(13, 547);
            lblDecoded.Name = "lblDecoded";
            lblDecoded.Size = new Size(173, 15);
            lblDecoded.TabIndex = 4;
            lblDecoded.Text = "Декодированное сообщение: ";
            // 
            // btnDecode
            // 
            btnDecode.Location = new Point(576, 448);
            btnDecode.Name = "btnDecode";
            btnDecode.Size = new Size(171, 23);
            btnDecode.TabIndex = 5;
            btnDecode.Text = "Декодировать";
            btnDecode.UseVisualStyleBackColor = true;
            btnDecode.Click += btnDecode_Click;
            // 
            // tbEncodedFromAlgorithm
            // 
            tbEncodedFromAlgorithm.Location = new Point(199, 513);
            tbEncodedFromAlgorithm.Name = "tbEncodedFromAlgorithm";
            tbEncodedFromAlgorithm.Size = new Size(100, 23);
            tbEncodedFromAlgorithm.TabIndex = 2;
            // 
            // tbDecodedFromAlgorithm
            // 
            tbDecodedFromAlgorithm.Location = new Point(199, 542);
            tbDecodedFromAlgorithm.Name = "tbDecodedFromAlgorithm";
            tbDecodedFromAlgorithm.Size = new Size(100, 23);
            tbDecodedFromAlgorithm.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(13, 485);
            label3.Name = "label3";
            label3.Size = new Size(180, 15);
            label3.TabIndex = 7;
            label3.Text = "Нормализованное сообщение:";
            // 
            // tbNormalized
            // 
            tbNormalized.Location = new Point(199, 485);
            tbNormalized.Name = "tbNormalized";
            tbNormalized.Size = new Size(100, 23);
            tbNormalized.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(870, 583);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btnDecode);
            Controls.Add(lblDecoded);
            Controls.Add(btnEncode);
            Controls.Add(lblEncoded);
            Controls.Add(btnPrev);
            Controls.Add(tbEncoded);
            Controls.Add(btnNext);
            Controls.Add(tbDecodedFromAlgorithm);
            Controls.Add(tbNormalized);
            Controls.Add(tbEncodedFromAlgorithm);
            Controls.Add(tbInitMessage);
            Controls.Add(label1);
            Controls.Add(dgvGrille);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvGrille).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvGrille;
        private Label label1;
        private TextBox tbInitMessage;
        private Button btnNext;
        private Button btnPrev;
        private Label lblEncoded;
        private Button btnEncode;
        private Label label2;
        private TextBox tbEncoded;
        private Label lblDecoded;
        private Button btnDecode;
        private TextBox tbEncodedFromAlgorithm;
        private TextBox tbDecodedFromAlgorithm;
        private Label label3;
        private TextBox tbNormalized;
    }
}