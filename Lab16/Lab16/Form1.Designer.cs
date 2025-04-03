namespace Lab16

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
            output = new ListBox();
            welcomeText = new Label();
            inputCount = new TextBox();
            generateCollection = new Button();
            showCollection = new Button();
            selectFormat = new ComboBox();
            saveButton = new Button();
            loadButton = new Button();
            SuspendLayout();
            // 
            // output
            // 
            output.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            output.FormattingEnabled = true;
            output.ItemHeight = 21;
            output.Location = new Point(329, 115);
            output.Name = "output";
            output.Size = new Size(586, 319);
            output.TabIndex = 0;
            // 
            // welcomeText
            // 
            welcomeText.AutoSize = true;
            welcomeText.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            welcomeText.Location = new Point(32, 19);
            welcomeText.Name = "welcomeText";
            welcomeText.Size = new Size(396, 25);
            welcomeText.TabIndex = 1;
            welcomeText.Text = "Введите количество элементов в коллекции";
            welcomeText.TextAlign = ContentAlignment.TopCenter;
            // 
            // inputCount
            // 
            inputCount.Location = new Point(434, 21);
            inputCount.Name = "inputCount";
            inputCount.Size = new Size(100, 23);
            inputCount.TabIndex = 2;
            // 
            // generateCollection
            // 
            generateCollection.Location = new Point(551, 12);
            generateCollection.Name = "generateCollection";
            generateCollection.Size = new Size(98, 43);
            generateCollection.TabIndex = 3;
            generateCollection.Text = "Сгенерировать коллекцию";
            generateCollection.UseVisualStyleBackColor = true;
            generateCollection.Click += generateCollection_Click;
            // 
            // showCollection
            // 
            showCollection.Location = new Point(666, 11);
            showCollection.Name = "showCollection";
            showCollection.Size = new Size(86, 44);
            showCollection.TabIndex = 4;
            showCollection.Text = "Отобразить коллекцию";
            showCollection.UseVisualStyleBackColor = true;
            showCollection.Click += showCollection_Click;
            // 
            // selectFormat
            // 
            selectFormat.FormattingEnabled = true;
            selectFormat.Location = new Point(222, 61);
            selectFormat.Name = "selectFormat";
            selectFormat.Size = new Size(93, 23);
            selectFormat.TabIndex = 6;
            // 
            // saveButton
            // 
            saveButton.Location = new Point(758, 12);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(78, 44);
            saveButton.TabIndex = 7;
            saveButton.Text = "Сохранить";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // loadButton
            // 
            loadButton.Location = new Point(849, 14);
            loadButton.Name = "loadButton";
            loadButton.Size = new Size(79, 42);
            loadButton.TabIndex = 8;
            loadButton.Text = "Загрузить";
            loadButton.UseVisualStyleBackColor = true;
            loadButton.Click += loadButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1213, 533);
            Controls.Add(loadButton);
            Controls.Add(saveButton);
            Controls.Add(selectFormat);
            Controls.Add(showCollection);
            Controls.Add(generateCollection);
            Controls.Add(inputCount);
            Controls.Add(welcomeText);
            Controls.Add(output);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox output;
        private Label welcomeText;
        private TextBox inputCount;
        private Button generateCollection;
        private Button showCollection;
        private ComboBox selectFormat;
        private Button saveButton;
        private Button loadButton;
    }
}
