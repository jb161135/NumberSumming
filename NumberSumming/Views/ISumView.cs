using System;
using System.Windows.Forms;

namespace NumberSumming.Views
{
    public interface ISumView
    {
        event EventHandler SumValues;
        OpenFileDialog OpenFileDialog { get; set; }
        string Sum { get; set; }
        void Show();
    }
}
