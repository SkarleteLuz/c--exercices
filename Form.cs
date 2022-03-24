public partial class Form1 : Form
{ 
    public Form1()
    {
        InitializeComponent();           
    }

    private void Form1_Resize(object sender, EventArgs e)
    {
        
    }

    private void Form1_ResizeEnd(object sender, EventArgs e)
    {
        ResponsiveEnd();
    }
    const int WM_SYSCOMMAND = 0x0112;
    const int SC_MAXIMIZE = 0xF030;
    const int SC_RESTORE = 0xF120; 
    protected override void WndProc(ref Message m)
    {
        base.WndProc(ref m);
        if (m.Msg == WM_SYSCOMMAND)
        {
            if (m.WParam == (IntPtr)SC_MAXIMIZE ||  m.WParam == (IntPtr)SC_RESTORE)
                this.OnResizeEnd(EventArgs.Empty);
        }
    }

    private void ResponsiveEnd()
    {
        if (this.Width <= 450)
        {
            tableLayoutPanel2.ColumnStyles[1].Width = 350;
        }
        else if (this.Width < 1010)
        {
            tableLayoutPanel2.ColumnStyles[1].Width = tableLayoutPanel2.Width - (chart1.Width + chart1.Margin.Right);
        }
        else
        {
            tableLayoutPanel2.ColumnStyles[1].Width = tableLayoutPanel2.Width -
                (chart1.Width + chart2.Width + chart1.Margin.Right + chart2.Margin.Right);
        }

        if (this.Height <= 775)
        {
            panel8.Height = 290;
        }
        else
        {
            panel8.Height = panel7.Height;
        }
    }