using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using System.Collections;
using System.Threading;

namespace MonitorProcesos
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    /// 
    public class proceso {
        public string nombre { get; set; }
        public string estado { get; set; }
        public double memoria { get; set; }
    }
    public partial class MainWindow : MetroWindow
    {
        [ThreadStatic]
        static List<proceso> process = new List<proceso>();
        public MainWindow()
        {
            Thread p = new Thread(processManager);
            InitializeComponent();
            /*DataGridTextColumn f = new DataGridTextColumn();
            Binding b = new Binding("Proceso");
            f.Binding = b;
            f.Header = "Proceso";
            procesView.Columns.Add(f);*/
        }
        public void updateData(proceso p) {
            process.Add(p);
            procesView.ItemsSource = null;
            procesView.ItemsSource = process;
        }
        static void processManager() {
            for (int i = 0; i < 10; i++)
            {
               
            }
            
        }
    }
}
