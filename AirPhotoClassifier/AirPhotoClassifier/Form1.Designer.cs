namespace AirPhotoClassifier
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.imageBoxOriginal = new Emgu.CV.UI.ImageBox();
            this.imageBoxSegmentation = new Emgu.CV.UI.ImageBox();
            this.buttonImportImage = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonOpenColorDialog = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.buttonStartSegmentation = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.fieldRuler = new System.Windows.Forms.NumericUpDown();
            this.trackBarRuler = new System.Windows.Forms.TrackBar();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.fieldSizeSuperpixel = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.trackBarSizeSuperpixel = new System.Windows.Forms.TrackBar();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.RandomTreeButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxOriginal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxSegmentation)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fieldRuler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRuler)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fieldSizeSuperpixel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSizeSuperpixel)).BeginInit();
            this.SuspendLayout();
            // 
            // imageBoxOriginal
            // 
            this.imageBoxOriginal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.imageBoxOriginal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageBoxOriginal.Location = new System.Drawing.Point(12, 482);
            this.imageBoxOriginal.Name = "imageBoxOriginal";
            this.imageBoxOriginal.Size = new System.Drawing.Size(263, 263);
            this.imageBoxOriginal.TabIndex = 2;
            this.imageBoxOriginal.TabStop = false;
            // 
            // imageBoxSegmentation
            // 
            this.imageBoxSegmentation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imageBoxSegmentation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageBoxSegmentation.Location = new System.Drawing.Point(293, 12);
            this.imageBoxSegmentation.Name = "imageBoxSegmentation";
            this.imageBoxSegmentation.Size = new System.Drawing.Size(595, 733);
            this.imageBoxSegmentation.TabIndex = 2;
            this.imageBoxSegmentation.TabStop = false;
            this.imageBoxSegmentation.MouseMove += new System.Windows.Forms.MouseEventHandler(this.imageBoxSegmentation_MouseMove);
            // 
            // buttonImportImage
            // 
            this.buttonImportImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonImportImage.Location = new System.Drawing.Point(6, 19);
            this.buttonImportImage.Name = "buttonImportImage";
            this.buttonImportImage.Size = new System.Drawing.Size(263, 35);
            this.buttonImportImage.TabIndex = 3;
            this.buttonImportImage.Text = "Открыть изображение";
            this.buttonImportImage.UseVisualStyleBackColor = true;
            this.buttonImportImage.Click += new System.EventHandler(this.buttonImportImage_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.RandomTreeButton);
            this.groupBox1.Controls.Add(this.buttonOpenColorDialog);
            this.groupBox1.Controls.Add(this.listView1);
            this.groupBox1.Controls.Add(this.buttonStartSegmentation);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.buttonImportImage);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(275, 464);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Параметры";
            // 
            // buttonOpenColorDialog
            // 
            this.buttonOpenColorDialog.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonOpenColorDialog.Location = new System.Drawing.Point(6, 375);
            this.buttonOpenColorDialog.Name = "buttonOpenColorDialog";
            this.buttonOpenColorDialog.Size = new System.Drawing.Size(263, 35);
            this.buttonOpenColorDialog.TabIndex = 10;
            this.buttonOpenColorDialog.Text = "Выбрать цвет";
            this.buttonOpenColorDialog.UseVisualStyleBackColor = true;
            this.buttonOpenColorDialog.Click += new System.EventHandler(this.buttonOpenColorDialog_Click);
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(6, 253);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(263, 116);
            this.listView1.TabIndex = 9;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // buttonStartSegmentation
            // 
            this.buttonStartSegmentation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonStartSegmentation.Location = new System.Drawing.Point(6, 212);
            this.buttonStartSegmentation.Name = "buttonStartSegmentation";
            this.buttonStartSegmentation.Size = new System.Drawing.Size(263, 35);
            this.buttonStartSegmentation.TabIndex = 8;
            this.buttonStartSegmentation.Text = "Сегментировать";
            this.buttonStartSegmentation.UseVisualStyleBackColor = true;
            this.buttonStartSegmentation.Click += new System.EventHandler(this.buttonStartSegmentation_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.fieldRuler);
            this.groupBox3.Controls.Add(this.trackBarRuler);
            this.groupBox3.Location = new System.Drawing.Point(6, 136);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(263, 70);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Коэффициента плавности";
            // 
            // fieldRuler
            // 
            this.fieldRuler.DecimalPlaces = 1;
            this.fieldRuler.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fieldRuler.Location = new System.Drawing.Point(172, 19);
            this.fieldRuler.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.fieldRuler.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.fieldRuler.Name = "fieldRuler";
            this.fieldRuler.Size = new System.Drawing.Size(68, 23);
            this.fieldRuler.TabIndex = 6;
            this.fieldRuler.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.fieldRuler.ValueChanged += new System.EventHandler(this.fieldRuler_ValueChanged);
            // 
            // trackBarRuler
            // 
            this.trackBarRuler.LargeChange = 10;
            this.trackBarRuler.Location = new System.Drawing.Point(6, 19);
            this.trackBarRuler.Maximum = 50;
            this.trackBarRuler.Minimum = 1;
            this.trackBarRuler.Name = "trackBarRuler";
            this.trackBarRuler.Size = new System.Drawing.Size(160, 45);
            this.trackBarRuler.TabIndex = 4;
            this.trackBarRuler.TickFrequency = 5;
            this.trackBarRuler.Value = 1;
            this.trackBarRuler.Scroll += new System.EventHandler(this.trackBarRuler_Scroll);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.fieldSizeSuperpixel);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.trackBarSizeSuperpixel);
            this.groupBox2.Location = new System.Drawing.Point(6, 60);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(263, 70);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Размер суперпикселя в пикселях";
            // 
            // fieldSizeSuperpixel
            // 
            this.fieldSizeSuperpixel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fieldSizeSuperpixel.Location = new System.Drawing.Point(172, 19);
            this.fieldSizeSuperpixel.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.fieldSizeSuperpixel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.fieldSizeSuperpixel.Name = "fieldSizeSuperpixel";
            this.fieldSizeSuperpixel.Size = new System.Drawing.Size(68, 23);
            this.fieldSizeSuperpixel.TabIndex = 7;
            this.fieldSizeSuperpixel.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.fieldSizeSuperpixel.ValueChanged += new System.EventHandler(this.fieldSizeSuperpixel_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(239, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "px";
            // 
            // trackBarSizeSuperpixel
            // 
            this.trackBarSizeSuperpixel.LargeChange = 10;
            this.trackBarSizeSuperpixel.Location = new System.Drawing.Point(6, 19);
            this.trackBarSizeSuperpixel.Maximum = 300;
            this.trackBarSizeSuperpixel.Minimum = 10;
            this.trackBarSizeSuperpixel.Name = "trackBarSizeSuperpixel";
            this.trackBarSizeSuperpixel.Size = new System.Drawing.Size(160, 45);
            this.trackBarSizeSuperpixel.TabIndex = 4;
            this.trackBarSizeSuperpixel.TickFrequency = 10;
            this.trackBarSizeSuperpixel.Value = 10;
            this.trackBarSizeSuperpixel.Scroll += new System.EventHandler(this.trackBarSizeSuperpixel_Scroll);
            // 
            // RandomTreeButton
            // 
            this.RandomTreeButton.Location = new System.Drawing.Point(12, 429);
            this.RandomTreeButton.Name = "RandomTreeButton";
            this.RandomTreeButton.Size = new System.Drawing.Size(102, 23);
            this.RandomTreeButton.TabIndex = 11;
            this.RandomTreeButton.Text = "Классификация";
            this.RandomTreeButton.UseVisualStyleBackColor = true;
            this.RandomTreeButton.Click += new System.EventHandler(this.RandomTreeButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 757);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.imageBoxSegmentation);
            this.Controls.Add(this.imageBoxOriginal);
            this.Name = "Form1";
            this.Text = "Superpixel HUITA";
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxOriginal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxSegmentation)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fieldRuler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRuler)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fieldSizeSuperpixel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSizeSuperpixel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Emgu.CV.UI.ImageBox imageBoxOriginal;
        private Emgu.CV.UI.ImageBox imageBoxSegmentation;
        private System.Windows.Forms.Button buttonImportImage;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trackBarSizeSuperpixel;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TrackBar trackBarRuler;
        private System.Windows.Forms.Button buttonStartSegmentation;
        private System.Windows.Forms.NumericUpDown fieldRuler;
        private System.Windows.Forms.NumericUpDown fieldSizeSuperpixel;
        private System.Windows.Forms.Button buttonOpenColorDialog;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Button RandomTreeButton;
    }
}

