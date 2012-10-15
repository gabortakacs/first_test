using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Encog.Neural.SOM;
using Encog.ML;
using Neural.Util;
using Traning.DataReaders.Binary;
using Traning.DataReaders.Binary.DataPartitioners;
using RightEdge.Common;
using System.IO;
using Encog.ML.Data;
using Neural.Util.Normalization;
using RandomApplications.Application;

namespace SOM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class SomMainWindow : Window
    {

        IApplication app;
        public int Seed = 5;
        private bool isFirst = true;

        public SomMainWindow()
        {
            InitializeComponent();
            this.Title = Seed.ToString();
            app = new FeatureImportanceCalculator2();
        }

        protected override void OnActivated(EventArgs e)
        {
            if (!isFirst) return;

            this.textBox1.Text = "Working!";
            try
            {
                app.Run();
                this.textBox1.Text = app.Message;
            }
            catch (Exception exc)
            {
                this.textBox1.Text = exc.Message;
            }
            finally
            {
                isFirst = false;
            }
        }
    }
}
