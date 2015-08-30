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
using MahApps.Metro;
using MahApps.Metro.Controls;
using System.Collections;
using System.Threading;
using System.Windows.Threading;

namespace MonitorProcesos
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    /// 
    public class proceso {
        public int ID { get; set; }
        public string nombre { get; set; }
        public string estado { get; set; }
        public double memoria { get; set; }
    }
    public partial class MainWindow : MetroWindow
    {
        List<proceso> process = new List<proceso>();
        bool stop = false;
        public MainWindow()
        {
            
            InitializeComponent();
            Thread _main = new Thread(()=> Manager());
            _main.Start();
        }

        private void SetItem(proceso p) {
             
        }
        private void IndependientProcess() {

<<<<<<< HEAD
            proceso p =  new proceso { ID= Thread.CurrentThread.ManagedThreadId,nombre = Thread.CurrentThread.GetApartmentState().ToString(),estado="Iniciando",memoria=0 };
            try {
                process.Add(p);
                int lenght = process.Count - 1;
                process[lenght].memoria = 0;
                Random r = new Random();
                while (true)
                {
                    Thread.Sleep(r.Next(1000, 3000));
                    stop = true;
                    ++process[lenght].memoria;
                    process[lenght].estado = "Ejecutando";
                    stop = false;

                }
            }
            catch (InvalidOperationException e) {
                Console.Write(e);
=======
        private void updateData(proceso p) {
            process.Add(p);
           
            if (procesView.ItemsSource == null) {
                //procesView.ItemsSource = null;
                //procesView.ItemsSource = process;
>>>>>>> 142440ed0434d6eeb2abd096ebbfaf887ed3cc23
            }
        }
        private void ViewUpdate() {
            while (true) {
                Thread.Sleep(500);
                if (!stop) {
                    procesView.Dispatcher.BeginInvoke(new Action(() => {
                        try
                        {
                            procesView.ItemsSource = null;
                        }
                        catch (InvalidOperationException e)
                        {
                            Console.Write(e);
                        }

                    }), DispatcherPriority.Normal, null);
                    procesView.Dispatcher.BeginInvoke(new Action(() => {
                        try
                        {
                            procesView.ItemsSource = process;
                        }
                        catch (InvalidOperationException e)
                        {
                            Console.Write(e);
                        }

                    }), DispatcherPriority.Normal, null);
                }
                
                  
            }
            
        }
            
        private void Manager() {
            
            List<Thread> thl = new List<Thread>();
            Thread view = new Thread(ViewUpdate);
            view.Start();
            Random r = new Random();
            while (true) {
                Thread.Sleep(r.Next(1000,30000));
                Thread pro = new Thread(IndependientProcess);
                thl.Add(pro);
                pro.Start(); 
            }
        }
        private void btnINI_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
