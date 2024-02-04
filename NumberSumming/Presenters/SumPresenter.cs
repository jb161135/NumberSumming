using NumberSumming.Models;
using NumberSumming.Views;
using System;
using System.Windows.Forms;

namespace NumberSumming.Presenters
{
    /// <summary>
    /// Class <c>SumPresenter</c> interacts with the <c>ISumView</c> and 
    /// <c>ISumModel</c> interface to pass information between the Model and View.
    /// </summary>
    public class SumPresenter
    {
        readonly ISumView sumView;
        readonly ISumModel sumModel;

        public SumPresenter(ISumView sumView, ISumModel sumModel)
        {
            this.sumView = sumView;
            this.sumModel = sumModel;
            this.sumView.SumValues += SumValues;
        }

        /// <summary>
        /// Method <c>SumValues</c> tells the <c>SumModel</c> to get the data and sum it, 
        /// and tells the <c>SumView</c> to display the result.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void SumValues(object sender, EventArgs e)
        { 
            if(sumView.OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = sumView.OpenFileDialog.FileName;
                sumModel.HandleData(fileName);
                sumView.Sum = sumModel.FormattedSum.ToString();

                if (sumModel.ErrorMessage != "")
                {
                    MessageBox.Show(sumModel.ErrorMessage);
                }
            }
        }
    }
}
