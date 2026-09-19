namespace ScientificCalculator;

public partial class Form1 : Form
{
    private CalculatorEngine _engine;

    public Form1()
    {
        InitializeComponent();
        _engine = new CalculatorEngine();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        displayTextBox.Text = _engine.Expression;
        memoryLabel.Text = _engine.GetMemoryStatus();
    }

    // Number buttons
    private void BtnNumber_Click(object sender, EventArgs e)
    {
        var btn = sender as Button;
        _engine.AppendValue(btn.Text);
        UpdateDisplay();
    }

    // Decimal point
    private void BtnDecimal_Click(object sender, EventArgs e)
    {
        _engine.AppendValue(".");
        UpdateDisplay();
    }

    // Operators
    private void BtnOperator_Click(object sender, EventArgs e)
    {
        var btn = sender as Button;
        _engine.ApplyOperator(btn.Text);
        UpdateDisplay();
    }

    // Equals
    private void BtnEquals_Click(object sender, EventArgs e)
    {
        _engine.Calculate();
        UpdateDisplay();
    }

    // Clear
    private void BtnClear_Click(object sender, EventArgs e)
    {
        _engine.Clear();
        UpdateDisplay();
    }

    // Scientific operations
    private void BtnSqrt_Click(object sender, EventArgs e)
    {
        _engine.ApplySqrt();
        UpdateDisplay();
    }

    private void BtnSquare_Click(object sender, EventArgs e)
    {
        _engine.ApplySquare();
        UpdateDisplay();
    }

    private void BtnReciprocal_Click(object sender, EventArgs e)
    {
        _engine.ApplyReciprocal();
        UpdateDisplay();
    }

    private void BtnFactorial_Click(object sender, EventArgs e)
    {
        _engine.ApplyFactorial();
        UpdateDisplay();
    }

    private void BtnSin_Click(object sender, EventArgs e)
    {
        _engine.ApplySin();
        UpdateDisplay();
    }

    private void BtnCos_Click(object sender, EventArgs e)
    {
        _engine.ApplyCos();
        UpdateDisplay();
    }

    private void BtnTan_Click(object sender, EventArgs e)
    {
        _engine.ApplyTan();
        UpdateDisplay();
    }

    private void BtnLn_Click(object sender, EventArgs e)
    {
        _engine.ApplyLn();
        UpdateDisplay();
    }

    private void BtnLog_Click(object sender, EventArgs e)
    {
        _engine.ApplyLog10();
        UpdateDisplay();
    }

    private void BtnPi_Click(object sender, EventArgs e)
    {
        _engine.AppendValue(Math.PI.ToString());
        UpdateDisplay();
    }

    private void BtnE_Click(object sender, EventArgs e)
    {
        _engine.AppendValue(Math.E.ToString());
        UpdateDisplay();
    }

    private void BtnPercentage_Click(object sender, EventArgs e)
    {
        _engine.ApplyPercentage();
        UpdateDisplay();
    }

    private void BtnToggleSign_Click(object sender, EventArgs e)
    {
        _engine.ToggleSign();
        UpdateDisplay();
    }

    // Memory operations
    private void BtnMemoryAdd_Click(object sender, EventArgs e)
    {
        _engine.MemoryAdd();
        UpdateDisplay();
    }

    private void BtnMemorySubtract_Click(object sender, EventArgs e)
    {
        _engine.MemorySubtract();
        UpdateDisplay();
    }

    private void BtnMemoryRecall_Click(object sender, EventArgs e)
    {
        _engine.MemoryRecall();
        UpdateDisplay();
    }

    private void BtnMemoryClear_Click(object sender, EventArgs e)
    {
        _engine.MemoryClear();
        UpdateDisplay();
    }
}