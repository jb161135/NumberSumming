using NumberSumming.Models;
using NumberSumming.Presenters;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace NumberSumming.Views
{
    public partial class SumForm : Form, ISumView
    {
        private string sum = string.Empty;
        private OpenFileDialog openFileDialog;
        public event EventHandler SumValues;

        OpenFileDialog ISumView.OpenFileDialog
        {
            get => openFileDialog;
            set => openFileDialog = value;
        }

        string ISumView.Sum 
        { 
            get => sum; 
            set 
            {
                sum = value;
                txtSum.Text = sum;
            }
        }

        public SumForm()
        {
            InitializeComponent();
            openFileDialog = new OpenFileDialog();
            btnSum.Click += delegate { SumValues?.Invoke(this, EventArgs.Empty); };
            BackColor = Color.FromArgb(199, 217, 195);
            new SumPresenter(this, new SumModel());
        }
    }
}
