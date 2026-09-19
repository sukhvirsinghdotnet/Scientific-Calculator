namespace ScientificCalculator;

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
        components = new System.ComponentModel.Container();
           
        // Form settings
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(500, 650);
        Text = "Scientific Calculator";
        Font = new Font("Segoe UI", 10);
        StartPosition = FormStartPosition.CenterScreen;
        MaximizeBox = false;
        MinimizeBox = false;

        // Display TextBox
        displayTextBox = new TextBox();
        displayTextBox.Location = new Point(10, 10);
        displayTextBox.Size = new Size(480, 60);
        displayTextBox.Font = new Font("Segoe UI", 24, FontStyle.Bold);
        displayTextBox.ReadOnly = true;
        displayTextBox.TextAlign = HorizontalAlignment.Right;
        displayTextBox.Text = "0";
        Controls.Add(displayTextBox);

        // Memory Status Label
        memoryLabel = new Label();
        memoryLabel.Location = new Point(10, 75);
        memoryLabel.Size = new Size(480, 20);
        memoryLabel.Font = new Font("Segoe UI", 9);
        memoryLabel.ForeColor = Color.Gray;
        Controls.Add(memoryLabel);

        // Button grid
        int startX = 10, startY = 100;
        int btnWidth = 60, btnHeight = 50;
        int spacing = 5;

        // Row 1: Memory buttons + Clear
        CreateButton("MC", startX, startY, btnWidth, btnHeight, BtnMemoryClear_Click);
        CreateButton("MR", startX + (btnWidth + spacing) * 1, startY, btnWidth, btnHeight, BtnMemoryRecall_Click);
        CreateButton("M+", startX + (btnWidth + spacing) * 2, startY, btnWidth, btnHeight, BtnMemoryAdd_Click);
        CreateButton("M-", startX + (btnWidth + spacing) * 3, startY, btnWidth, btnHeight, BtnMemorySubtract_Click);
        CreateButton("C", startX + (btnWidth + spacing) * 4, startY, btnWidth, btnHeight, BtnClear_Click);

        // Row 2: Scientific functions
        startY += btnHeight + spacing;
        CreateButton("sin", startX, startY, btnWidth, btnHeight, BtnSin_Click);
        CreateButton("cos", startX + (btnWidth + spacing) * 1, startY, btnWidth, btnHeight, BtnCos_Click);
        CreateButton("tan", startX + (btnWidth + spacing) * 2, startY, btnWidth, btnHeight, BtnTan_Click);
        CreateButton("π", startX + (btnWidth + spacing) * 3, startY, btnWidth, btnHeight, BtnPi_Click);
        CreateButton("e", startX + (btnWidth + spacing) * 4, startY, btnWidth, btnHeight, BtnE_Click);

        // Row 3: More scientific
        startY += btnHeight + spacing;
        CreateButton("ln", startX, startY, btnWidth, btnHeight, BtnLn_Click);
        CreateButton("log", startX + (btnWidth + spacing) * 1, startY, btnWidth, btnHeight, BtnLog_Click);
        CreateButton("√", startX + (btnWidth + spacing) * 2, startY, btnWidth, btnHeight, BtnSqrt_Click);
        CreateButton("x²", startX + (btnWidth + spacing) * 3, startY, btnWidth, btnHeight, BtnSquare_Click);
        CreateButton("n!", startX + (btnWidth + spacing) * 4, startY, btnWidth, btnHeight, BtnFactorial_Click);

        // Row 4: Numbers and basic ops
        startY += btnHeight + spacing;
        CreateButton("7", startX, startY, btnWidth, btnHeight, BtnNumber_Click);
        CreateButton("8", startX + (btnWidth + spacing) * 1, startY, btnWidth, btnHeight, BtnNumber_Click);
        CreateButton("9", startX + (btnWidth + spacing) * 2, startY, btnWidth, btnHeight, BtnNumber_Click);
        CreateButton("/", startX + (btnWidth + spacing) * 3, startY, btnWidth, btnHeight, BtnOperator_Click);
        CreateButton("1/x", startX + (btnWidth + spacing) * 4, startY, btnWidth, btnHeight, BtnReciprocal_Click);

        // Row 5
        startY += btnHeight + spacing;
        CreateButton("4", startX, startY, btnWidth, btnHeight, BtnNumber_Click);
        CreateButton("5", startX + (btnWidth + spacing) * 1, startY, btnWidth, btnHeight, BtnNumber_Click);
        CreateButton("6", startX + (btnWidth + spacing) * 2, startY, btnWidth, btnHeight, BtnNumber_Click);
        CreateButton("*", startX + (btnWidth + spacing) * 3, startY, btnWidth, btnHeight, BtnOperator_Click);
        CreateButton("%", startX + (btnWidth + spacing) * 4, startY, btnWidth, btnHeight, BtnPercentage_Click);

        // Row 6
        startY += btnHeight + spacing;
        CreateButton("1", startX, startY, btnWidth, btnHeight, BtnNumber_Click);
        CreateButton("2", startX + (btnWidth + spacing) * 1, startY, btnWidth, btnHeight, BtnNumber_Click);
        CreateButton("3", startX + (btnWidth + spacing) * 2, startY, btnWidth, btnHeight, BtnNumber_Click);
        CreateButton("-", startX + (btnWidth + spacing) * 3, startY, btnWidth, btnHeight, BtnOperator_Click);
        CreateButton("+/-", startX + (btnWidth + spacing) * 4, startY, btnWidth, btnHeight, BtnToggleSign_Click);

        // Row 7: 0, decimal, equals
        startY += btnHeight + spacing;
        CreateButton("0", startX, startY, btnWidth * 2 + spacing, btnHeight, BtnNumber_Click);
        CreateButton(".", startX + (btnWidth + spacing) * 2, startY, btnWidth, btnHeight, BtnDecimal_Click);
        CreateButton("+", startX + (btnWidth + spacing) * 3, startY, btnWidth, btnHeight, BtnOperator_Click);
        CreateButton("=", startX + (btnWidth + spacing) * 4, startY, btnWidth, btnHeight, BtnEquals_Click);
    }

    private void CreateButton(string text, int x, int y, int width, int height, EventHandler clickHandler)
    {
        var btn = new Button();
        btn.Text = text;
        btn.Location = new Point(x, y);
        btn.Size = new Size(width, height);
        btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);
        btn.Cursor = Cursors.Hand;
        btn.BackColor = Color.LightGray;
        btn.FlatStyle = FlatStyle.Flat;
        btn.Click += clickHandler;
        Controls.Add(btn);
    }

    private TextBox displayTextBox;
    private Label memoryLabel;
    #endregion
}
